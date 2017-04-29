using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSFramework3.Interfaces;
using CSFramework3.Business;
using CSFramework3.Business.BLL_Base;
using CSFramework3.Models;
using CSFramework.Common;

namespace CSFramework.BLL
{

    /// <summary>
    /// 生成单据的选择项目.
    /// </summary>
    public interface IGenerateItem
    {
        /// <summary>
        ///项目标题 
        /// </summary>
        string ItemCaption { get; }

        /// <summary>
        ///目标窗体名称 
        /// </summary>
        string TargetFormName { get; }

        /// <summary>
        /// 打开目标窗体对应的菜单名.
        /// </summary>
        string TargetFormMenuName { get; }

        /// <summary>
        ///目标窗体类型 
        /// </summary>
        Type TargetFormType { get; }

        /// <summary>
        /// 标志是否生成成功
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// 由其它单生成本单时需要用户输入来源单号
        /// </summary>
        bool IsDocNoRequired { get; }

        /// <summary>
        /// 检查来源单据的单号是否存在
        /// </summary>
        /// <param name="DocNo">单据号码</param>
        /// <returns></returns>
        bool IsDocNoExists(string DocNo);

        /// <summary>
        /// 自动生成数据
        /// </summary>
        /// <param name="targetBLL">目标单据的业务逻辑层</param>
        /// <returns></returns>
        bool Generate(bllBaseBusiness targetBLL);

        /// <summary>
        /// 设置来源单据的单号
        /// </summary>
        /// <param name="DocNo">业务单据号码</param>
        void SetDocNo(string DocNo);
    }

    /// <summary>
    /// 生成单据项目定义基类
    /// </summary>
    public class IGenerateItemBase : IGenerateItem
    {
        protected bool _IsDocNoRequired;
        protected string _DocNo;
        protected bool _IsSuccess = false;
        protected string _TargetFormName;
        protected Type _TargetFormType = null;
        protected string _ItemCaption;
        protected string _TargetFormMenuName;

        public IGenerateItemBase() { }
        public IGenerateItemBase(string DocNo, bool IsDocNoRequired, Type targetFormType, string targetFormName)
        {
            _DocNo = DocNo;
            _IsDocNoRequired = IsDocNoRequired;
            _TargetFormType = targetFormType;
            _TargetFormName = targetFormName;
        }

        public string TargetFormMenuName { get { return _TargetFormMenuName; } }
        public string ItemCaption { get { return _ItemCaption; } }
        public bool IsSuccess { get { return _IsSuccess; } }
        public Type TargetFormType { get { return _TargetFormType; } }
        public string TargetFormName { get { return _TargetFormName; } }
        public bool IsDocNoRequired { get { return _IsDocNoRequired; } }
        public void SetDocNo(string DocNo) { _DocNo = DocNo; }


        public virtual bool Generate(bllBaseBusiness targetBLL) { return false; }
        public virtual bool IsDocNoExists(string DocNo) { return false; }
    }


    #region 自动生成项目定义

    /// <summary>
    /// 入库单生成出库单
    /// </summary>
    public class IN_to_IO : IGenerateItemBase
    {
        public IN_to_IO(string DocNo, bool IsDocNoRequired, Type targetFormType, string targetFormName)
        {
            _DocNo = DocNo;
            _IsDocNoRequired = IsDocNoRequired;
            _TargetFormType = targetFormType;
            _TargetFormName = targetFormName;
            _TargetFormMenuName = "menuItemStockOut";
            _ItemCaption = "由入库单(IN)->生成出库(IO)";
        }

        // 由销售报价单生成销售发票
        public override bool Generate(bllBaseBusiness targetBLL)
        {
            if (targetBLL == null) throw new Exception("目标窗体的业务类没有实例化！");
            if (_TargetFormType == null) throw new Exception("没有指定目标窗体类型！");
            if (_TargetFormName == null) throw new Exception("没有指定目标窗体名称！");

            bllIN sourceBLL = new bllIN();
            DataSet sourceData = sourceBLL.GetBusinessByKey(_DocNo, false); //获取来源数据            

            DataTable targetMaster = targetBLL.BusinessTables[0]; //获取目标单据的主表对象
            DataTable targetDetail = targetBLL.BusinessTables[1];//获取目标单据的明细表对象

            DataRow target = targetMaster.NewRow();
            DataRow source = sourceData.Tables[0].Rows[0];
            targetMaster.Rows.Clear();//清除主表一条记录
            targetMaster.Rows.Add(target);

            //下面的代码将两张表关联的数据赋值
            target[tb_IO.CustomerCode] = source[tb_IN.SupplierCode];
            target[tb_IO.CustomerName] = source[tb_IN.SupplierName];
            target[tb_IO.Deliver] = source[tb_IN.Deliver];
            target[tb_IO.Department] = source[tb_IN.Department];
            target[tb_IO.DocDate] = source[tb_IN.DocDate];
            target[tb_IO.DocUser] = source[tb_IN.DocUser];
            target[tb_IO.LocationID] = source[tb_IN.LocationID];
            target[tb_IO.Remark] = source[tb_IN.Remark];
            target[tb_IO.LastUpdateDate] = DateTime.Today;
            target[tb_IO.LastUpdatedBy] = Loginer.CurrentUser.Account;
            target[tb_IO.CreatedBy] = Loginer.CurrentUser.Account;
            target[tb_IO.CreationDate] = DateTime.Today;

            //复制明细表数据
            targetDetail.Rows.Clear();
            foreach (DataRow detail in sourceData.Tables[1].Rows)
            {
                DataRow temp = targetDetail.NewRow();
                temp[tb_IOs.CreatedBy] = Loginer.CurrentUser.Account;
                temp[tb_IOs.CreationDate] = DateTime.Today;
                temp[tb_IOs.LastUpdateDate] = DateTime.Today;
                temp[tb_IOs.LastUpdatedBy] = Loginer.CurrentUser.Account;
                temp[tb_IOs.ProductCode] = detail[tb_INs.ProductCode];
                temp[tb_IOs.ProductName] = detail[tb_INs.ProductName];
                temp[tb_IOs.Quantity] = detail[tb_INs.Quantity];
                temp[tb_IOs.Queue] = detail[tb_INs.Queue];
                temp[tb_IOs.Remark] = detail[tb_INs.Remark];

                targetDetail.Rows.Add(temp);
            }

            _IsSuccess = true;
            return _IsSuccess;
        }

        //检查来源单号是否存在
        public override bool IsDocNoExists(string DocNo)
        {
            if (_IsDocNoRequired)
                return new bllIN().CheckNoExists(DocNo);
            else
                return false;
        }
    }

    #endregion

}
