
///*************************************************************************/
///*
///* 文件名    ：bllGroupAuthority.cs    
///*
///* 程序说明  : 用户组及组权限业务逻辑
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using CSFramework.Common;
using CSFramework3.Models;
using CSFramework3.Interfaces;
using CSFramework3.Business.Security;
using CSFramework.Core;
using CSFramework3.Business.BLL_Base;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework3.Bridge;



namespace CSFramework3.Business.Security
{
    /// <summary>
    /// 用户组及组权限业务逻辑
    /// </summary>
    public class bllGroupAuthority : bllBase
    {
        private IBridge_UserGroup _MyBridge;//中间层(桥接功能)接口
        private TreeView _treeAuthority;//权限树视图
        private Control _groupName;//组名输入框
        private DataTable _AuthorityItem = null;//功能点数据表
        private DataTable _FormTagCustomName = null;//窗体按钮列表(自定义按钮名)

        public bllGroupAuthority()
        {
            _MyBridge = BridgeFactory.CreateUserGroupBridge();//创建中间层实例
            _AuthorityItem = _MyBridge.GetAuthorityItem(); //获取权限功能点数据字典
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="treeAuthority">权限树视图</param>
        /// <param name="groupName">组名输入框</param>
        public bllGroupAuthority(TreeView treeAuthority, Control groupName)
            : this()
        {
            _treeAuthority = treeAuthority;
            _groupName = groupName;
        }

        /// <summary>
        /// 增加一条用户组的主表记录
        /// </summary>
        /// <param name="summary"></param>
        public void AddSummary(DataTable summary)
        {
            DataRow newrow = summary.NewRow();
            summary.Rows.Add(newrow);
        }

        /// <summary>
        /// 初始化功能点树结点
        /// </summary>
        /// <param name="node">功能点所在的树结点</param>
        /// <param name="menuItem">菜单项</param>
        private void InitAction(TreeNode node, ToolStripItem menuItem)
        {
            if (menuItem.Tag == null || !(menuItem.Tag is MenuItemTag)) return; //功能菜单没有分配权限，不处理

            MenuItemTag menuItemTag = menuItem.Tag as MenuItemTag;//取菜单的功能权限对象

            if (menuItemTag.MenuType != MenuType.DataForm) return;//只处理数据窗体
            if (menuItemTag.FormAuthorities == 0) return; //此菜单对应的窗体没有分配权限(功能点)

            //取当前菜单权限.SystemAuthentication.UserAuthorities当前用户的权限数据
            DataRow auth = GetDataRowByMenuName(SystemAuthentication.UserAuthorities, menuItemTag.ModuleID, menuItem.Name);

            int userAuths = auth == null ? 0 : ConvertEx.ToInt(auth[TUserRole.Authorities]);//当前用户拥有此菜单的权限
            int formAuths = menuItemTag.FormAuthorities; //窗体可用的功能点
            bool isAdmin = Loginer.CurrentUser.IsAdmin();//是否系统管理员

            foreach (DataRow row in _AuthorityItem.Rows) //循环所有功能点.
            {
                int value = int.Parse(row["AuthorityValue"].ToString());//功能点权限值
                if (value == 0) continue;//不显示权限值为0的功能点

                //用每个功能点的值与窗体的最大权限进行逻辑"与"运算, 但不能超出当前用户的权限．
                if (((value & formAuths) == value) && (isAdmin || ((value & userAuths) == value)))
                {
                    string caption = row["AuthorityName"].ToString(); //取功能点名称
                    DataRow tagNameRow = GetCustomTagName(menuItem.Name, value); //取功能点的自定义名称资料行
                    if (tagNameRow != null) caption = tagNameRow["TagName"].ToString();//如果有自定义名称，则取定义名

                    //构建一个树结点Tag属性的引用对象，Node.Tag=引用对象
                    ActionNodeTag tag = new ActionNodeTag(value, auth);
                    tag.TagMenuNameRef = menuItem.Name;
                    tag.TagNameTable = _FormTagCustomName;
                    tag.TagNameDataRow = tagNameRow;
                    tag.TagNameOld = caption; //按钮标题                    

                    TreeNode actionNode = new TreeNode(caption, 0, 0);//新增树结点
                    actionNode.Tag = tag;//绑定引用的对象
                    actionNode.ImageIndex = 2;
                    actionNode.SelectedImageIndex = 2;

                    node.Nodes.Add(actionNode);
                }
            }
        }

        /// <summary>
        /// 取按钮自定义名称
        /// </summary>
        /// <param name="menuName">菜单名</param>
        /// <param name="tagValue">按钮对应的功能点编号</param>
        /// <returns></returns>
        private DataRow GetCustomTagName(string menuName, int tagValue)
        {
            DataRow[] rows = _FormTagCustomName.Select("MenuName='" + menuName + "' AND TagValue=" + tagValue.ToString());

            if (rows.Length > 0)
                return rows[0];
            else
                return null;
        }

        /// <summary>
        /// 取组权限
        /// </summary>
        /// <param name="detailGroupAuths">所有组权限的数据表</param>
        /// <param name="moduleID">模块编号</param>
        /// <param name="menuName">菜单名</param>
        /// <returns></returns>
        public static DataRow GetDataRowByMenuName(DataTable detailGroupAuths, int moduleID, string menuName)
        {
            DataRow[] rows = detailGroupAuths.Select(string.Format("AuthorityID='{0}' and ModuleID={1}", menuName, moduleID));

            if (rows != null && rows.Length > 0)
                return rows[0];
            else
                return null;
        }

        /// <summary>
        /// 增加菜单权限
        /// </summary>
        /// <param name="auths">权限表</param>
        /// <param name="node">当前处理的树结点</param>
        private void AddAuthority(DataTable auths, TreeNode node)
        {
            int actions = 0;
            int moduleID = 0;

            AuthNodeTag tag = node.Tag as AuthNodeTag; //取树结点的引用对象

            //新增组权限记录
            DataRow newrow = auths.NewRow();
            newrow[TUserRole.GroupCode] = _groupName.Text;
            newrow[TUserRole.AuthorityID] = tag.AuthID;

            if (tag.MenuItem.Tag != null && tag.MenuItem.Tag is MenuItemTag)
            {
                //取当前处理的树结点所有权限值加总
                actions = this.GetActions(node);
                moduleID = (tag.MenuItem.Tag as MenuItemTag).ModuleID;//模块编号
            }

            newrow[TUserRole.Authorities] = actions;
            newrow[TUserRole.ModuleID] = moduleID;
            auths.Rows.Add(newrow);
        }

        /// <summary>
        /// 枚举树视图，生成保存用的临时数据。
        /// 思路：枚举树视图中所有树结点，跟据树结点的操作状态(新增,修改)生成资料行(DataRow)
        ///        新增：结点没绑定DataRow且结点打勾. 为新增权限
        ///        修改: 结点有绑定DataRow且结点没有打勾. 为删除权限
        /// </summary>
        /// <param name="auths">树视图绑定的权限数据</param>
        /// <returns></returns>
        private DataTable GetGroupAuthorityChanges(DataTable auths)
        {
            foreach (TreeNode node in _treeAuthority.Nodes)
            {
                AuthNodeTag tag = node.Tag as AuthNodeTag;

                //结点没绑定DataRow且结点打勾. 为新增权限
                if (tag.DataRow == null && node.Checked)
                    AddAuthority(auths, node);

                //结点有绑定DataRow且结点没有打勾. 为删除权限
                else if (tag.DataRow != null && !node.Checked)
                    tag.DataRow.Delete();

                //递归处理子结点
                if (node.Nodes.Count > 0)
                    GetGroupAuthorityChangesChild(node, auths);

            }

            //返回修改的记录
            DataTable ret = auths.GetChanges();
            return ret == null ? auths.Clone() : ret;
        }

        /// <summary>
        /// 递归处理子结点，GetGroupAuthorityChanges方法的子程序。
        /// </summary>
        /// <param name="node">父结点</param>
        /// <param name="auths">树视图绑定的权限数据</param>
        private void GetGroupAuthorityChangesChild(TreeNode node, DataTable auths)
        {
            foreach (TreeNode n in node.Nodes)
            {
                if ((n.Tag == null) || (!(n.Tag is AuthNodeTag))) continue; //非菜单项.                

                AuthNodeTag tag = n.Tag as AuthNodeTag;//树结点的引用对象

                if (tag.DataRow == null && n.Checked) // 此结点是新增的，勾选状态
                    AddAuthority(auths, n);
                else if (tag.DataRow != null && n.Checked) //处理勾选状态的结点
                {
                    int changed = GetActions(n);//累加权限值
                    int oringed = int.Parse(tag.DataRow[TUserRole.Authorities].ToString());//取原始权限值
                    if (changed != oringed) tag.DataRow[TUserRole.Authorities] = changed;//如权限有修改，更新最新的权限值
                }
                else if (tag.DataRow != null && !n.Checked) //结点非勾选状态，表示已删除
                    tag.DataRow.Delete();//删除资料行

                if (n.Nodes.Count > 0)
                    GetGroupAuthorityChangesChild(n, auths);
            }
        }

        /// <summary>
        /// 获取树结点已勾选权限值的加总
        /// </summary>
        /// <param name="node">树结点</param>
        /// <returns></returns>
        private int GetActions(TreeNode node)
        {
            int actions = 0;
            foreach (TreeNode n in node.Nodes)
            {
                if (n.Checked && n.Tag != null && n.Tag is ActionNodeTag)
                {
                    actions += (n.Tag as ActionNodeTag).ActionValue;
                }
            }
            return actions;
        }

        /// <summary>
        /// 生成用于保存的临时数据，获取已选择的用户数据，
        /// </summary>
        /// <param name="currentBusiness">权限业务数据</param>
        /// <param name="lbAvailableUser">所有用户选择列表</param>
        /// <param name="lbSelectedUser">已选择的用户列表</param>
        /// <returns></returns>
        private DataTable GetGroupUserChanges(DataSet currentBusiness, ListBox lbAvailableUser, ListBox lbSelectedUser)
        {
            DataTable AvaliableUser = currentBusiness.Tables[BusinessDataSetIndex.GroupAvailableUser].Copy();//当前组可选用户
            DataTable SelectedUser = currentBusiness.Tables[BusinessDataSetIndex.GroupUsers].Copy();//当前组已选用户

            //检查已删除的用户
            foreach (ItemObject item in lbAvailableUser.Items)
            {
                DataRow row = (item as ItemObject).Value as DataRow;
                if (row.Table.TableName.ToUpper() != AvaliableUser.TableName.ToUpper())
                {
                    DataRow[] rows = SelectedUser.Select(string.Format("Account='{0}'", row[TUser.Account]));
                    if (rows.Length > 0) rows[0].Delete();//删除组的用户
                }
            }

            //检查新增的用户
            foreach (ItemObject item in lbSelectedUser.Items)
            {
                DataRow row = (item as ItemObject).Value as DataRow;
                if (row.Table.TableName.ToUpper() != SelectedUser.TableName.ToUpper())
                {
                    DataRow newrow = SelectedUser.NewRow();
                    newrow[TUserGroupRe.Account] = row[TUser.Account];
                    newrow[TUserGroupRe.GroupCode] = this._groupName.Text;
                    SelectedUser.Rows.Add(newrow);//增加用户
                }
            }

            DataTable ret = SelectedUser.GetChanges();
            return ret == null ? SelectedUser.Clone() : ret;
        }

        /// <summary>
        /// 树结点勾选后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeAuthorityAfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Checked == true)
                {
                    TreeNodeSelectedChild(e.Node, true);
                    TreeNodeParentSelected(e.Node, true);
                }
                else if (e.Node.Checked == false)
                {
                    TreeNodeSelectedChild(e.Node, false);
                    TreeNodeChildsUnSelected(e.Node);
                }
            }
        }

        /// <summary>
        /// 树结点勾选前触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeAuthorityBeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
            {
                Form form = _treeAuthority.FindForm();
                if (form != null && form is IDataOperatable)
                {
                    UpdateType type = (form as IDataOperatable).UpdateType;
                    e.Cancel = !(type == UpdateType.Modify || type == UpdateType.Add);
                }
            }
        }

        /// <summary>
        /// 生成权限管理树视图 - 第一级树结点
        /// </summary>
        public void InitAuthorityTree()
        {
            try
            {
                //取按钮自定义名称数据表
                _FormTagCustomName = _MyBridge.GetFormTagCustomName();

                this._treeAuthority.BeforeCheck += new TreeViewCancelEventHandler(OnTreeAuthorityBeforeCheck);
                this._treeAuthority.AfterCheck -= new TreeViewEventHandler(OnTreeAuthorityAfterCheck);
                this._treeAuthority.Nodes.Clear();
                this._treeAuthority.BeginUpdate();

                IMdiForm mainForm = (IMdiForm)_treeAuthority.FindForm().ParentForm;//取MDI主窗体的主菜单

                //枚举主窗体的菜单
                foreach (ToolStripItem item in mainForm.MainMenu.Items)
                {
                    if (item is ToolStripSeparator) continue; //菜单分隔符不处理
                    if (item.Tag != null && item.Tag.ToString().ToUpper() == "IsSystemMenu".ToUpper()) continue; //系统菜单不处理

                    if (!Loginer.CurrentUser.IsAdmin() && !item.Enabled) continue; //没菜单权限(菜单不可用).不加载树

                    AuthNodeTag tag = new AuthNodeTag(item.Name, null, item);

                    TreeNode node = new TreeNode(item.Text, 0, 0);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    node.Tag = tag; //标记

                    this._treeAuthority.Nodes.Add(node);

                    //处理子菜单
                    if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                    {
                        InitAuthorityTreeChild(item as ToolStripMenuItem, node);
                        node.Expand();
                    }
                }

                this._treeAuthority.EndUpdate();
                if (this._treeAuthority.Nodes.Count == 1) this._treeAuthority.Nodes[0].Expand();
            }
            finally
            {
                this._treeAuthority.AfterCheck += new TreeViewEventHandler(OnTreeAuthorityAfterCheck);
            }
        }

        /// <summary>
        /// 生成权限管理树视图 - 子级树结点
        /// </summary>
        private void InitAuthorityTreeChild(ToolStripMenuItem parent, TreeNode parentNode)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (item is ToolStripSeparator) continue; //分隔符不在树显示
                if (!Loginer.CurrentUser.IsAdmin() && !item.Enabled) continue; //没菜单权限.不加载树

                AuthNodeTag tag = new AuthNodeTag(item.Name, null, item);
                TreeNode node = new TreeNode(item.Text, 0, 0);                
                node.Tag = tag;
                parentNode.Nodes.Add(node);

                if (item.Tag != null && item.Tag is MenuItemTag) //数据窗体菜单
                {
                    if ((item.Tag as MenuItemTag).FormAuthorities > 0)//窗体有权限
                    {
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                        InitAction(node, item); //生成功能点结点
                    }
                    else
                    {
                        node.ImageIndex = 3; //signle form
                        node.SelectedImageIndex = 3;
                    }
                }
                else
                {
                    node.ImageIndex = 3; //signle form
                    node.SelectedImageIndex = 3;
                }

                //处理子菜单
                if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                    InitAuthorityTreeChild(item as ToolStripMenuItem, node);
            }
        }

        /// <summary>
        /// 显示组的权限
        /// </summary>
        /// <param name="detailGroupAuths"></param>
        public void ShowGroupAutority(DataTable detailGroupAuths)
        {
            try
            {
                _treeAuthority.AfterCheck -= new TreeViewEventHandler(OnTreeAuthorityAfterCheck);
                //一级结点,模块的主菜单
                foreach (TreeNode node in _treeAuthority.Nodes)
                {
                    AuthNodeTag tag = node.Tag as AuthNodeTag;
                    if (tag.MenuItem.Tag != null && tag.MenuItem.Tag is MenuItemTag)
                    {
                        int moduleTag = (tag.MenuItem.Tag as MenuItemTag).ModuleID;
                        DataRow row = GetDataRowByMenuName(detailGroupAuths, moduleTag, tag.AuthID);
                        tag.DataRow = row;
                        node.Checked = row != null;

                        if (node.Nodes.Count > 0)
                            ShowGroupAuthorityChild(node, detailGroupAuths);
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
            finally
            {
                _treeAuthority.AfterCheck += new TreeViewEventHandler(OnTreeAuthorityAfterCheck);
            }
        }

        /// <summary>
        /// 显示组的权限,ShowGroupAutority方法的子程序
        /// </summary>
        /// <param name="node"></param>
        /// <param name="detailGroupAuths"></param>
        private void ShowGroupAuthorityChild(TreeNode node, DataTable detailGroupAuths)
        {
            foreach (TreeNode n in node.Nodes)
            {
                AuthNodeTag tag = n.Tag as AuthNodeTag;

                if (tag.MenuItem.Tag != null && tag.MenuItem.Tag is MenuItemTag)
                {
                    int moduleID = (tag.MenuItem.Tag as MenuItemTag).ModuleID;
                    DataRow row = GetDataRowByMenuName(detailGroupAuths, moduleID, tag.AuthID);
                    tag.DataRow = row;
                    n.Checked = row != null;
                    if (n.Checked) this.TreeNodeParentSelected(n, true);

                    if (tag.MenuType == MenuType.DataForm)//show the business Actions
                        ShowAction(n, row);
                    else
                        if (n.Nodes.Count > 0) ShowGroupAuthorityChild(n, detailGroupAuths);
                }
            }
        }

        /// <summary>
        /// 显示功能点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="row"></param>
        private void ShowAction(TreeNode node, DataRow row)
        {
            if (node == null) return;

            int auth = 0;

            if (row != null) auth = int.Parse(row[TUserRole.Authorities].ToString());//用户拥有当前菜单的权限

            foreach (TreeNode n in node.Nodes)
            {
                if (auth != 0)
                {
                    int value = (n.Tag as ActionNodeTag).ActionValue;
                    n.Checked = (value & auth) == value;
                }
                else
                {
                    n.Checked = false;
                }
            }
        }

        /// <summary>
        /// 显示组的用户
        /// </summary>
        /// <param name="list"></param>
        /// <param name="users"></param>
        public void ShowUsers(ListBox list, DataTable users)
        {
            list.Items.Clear();
            foreach (DataRow row in users.Rows)
            {
                string factory = string.Empty;
                ItemObject item = new ItemObject(row[TUser.UserName].ToString() + factory, row);
                list.Items.Add(item);
            }
        }

        // selected subnode
        public void TreeNodeSelectedChild(TreeNode thChild, bool isChecked)
        {
            foreach (TreeNode tnChildNext in thChild.Nodes)
            {
                tnChildNext.Checked = isChecked;
                TreeNodeSelectedChild(tnChildNext, isChecked);
            }
        }
        // selected parentnode
        private void TreeNodeParentSelected(TreeNode tnChild, bool isChecked)
        {
            if (tnChild.Parent != null)
            {
                tnChild.Parent.Checked = isChecked;
                TreeNodeParentSelected(tnChild.Parent, isChecked);
            }
        }

        //当所有子结点去掉勾选时,父结点也去掉勾选
        private void TreeNodeChildsUnSelected(TreeNode tnChild)
        {
            if (tnChild.Parent == null) return;

            foreach (TreeNode n in tnChild.Parent.Nodes)
                if (n.Checked) return;

            tnChild.Parent.Checked = false;
        }

        /// <summary>
        /// 创建保存用的临时数据
        /// </summary>
        /// <param name="currentBusiness">业务数据(组,组的用户，组的权限，功能点的自定义名称)</param>
        /// <param name="lbAvailableUser"></param>
        /// <param name="lbSelectedUser"></param>
        /// <returns></returns>
        public DataSet CreateSaveData(DataSet currentBusiness, ListBox lbAvailableUser, ListBox lbSelectedUser)
        {
            DataSet save = new DataSet();
            DataRowState state = currentBusiness.Tables[BusinessDataSetIndex.Groups].Rows[0].RowState;

            currentBusiness.Tables[BusinessDataSetIndex.Groups].AcceptChanges();
            DataTable summary = currentBusiness.Tables[BusinessDataSetIndex.Groups].Copy();

            if (state == DataRowState.Added)
                summary.Rows[0].SetAdded();
            else if (state == DataRowState.Modified)
                summary.Rows[0].SetModified();

            DataTable auths = GetGroupAuthorityChanges(currentBusiness.Tables[BusinessDataSetIndex.GroupAuthorities]).Copy();
            DataTable user = GetGroupUserChanges(currentBusiness, lbAvailableUser, lbSelectedUser);
            DataTable tagNames = _FormTagCustomName.GetChanges();

            save.Tables.Add(summary); //用户组
            save.Tables.Add(user); //用户数据                
            save.Tables.Add(auths == null ? currentBusiness.Tables[BusinessDataSetIndex.GroupAuthorities].Clone() : auths); //权限数据
            save.Tables.Add(tagNames == null ? _FormTagCustomName.Clone() : tagNames); //功能点的自定义名称

            return save;
        }

        public DataTable GetUserGroup()
        {
            return _MyBridge.GetUserGroup();
        }

        /// <summary>
        /// 检查关键字是否已存在
        /// </summary>
        public bool CheckNoExists(string groupCode)
        {
            return _MyBridge.CheckNoExists(groupCode);
        }

        public DataSet GetGroupDataByKey(string groupName)
        {
            return _MyBridge.GetUserGroup(groupName);
        }

        public bool DeleteGroupByKey(string groupName)
        {
            return _MyBridge.DeleteGroupByKey(groupName);
        }

        public bool SaveGroup(DataSet save)
        {
            IBridge_DataDict dataDict = BridgeFactory.CreateDataDictBridge(typeof(TUserGroup));
            return dataDict.Update(save);
        }

        public int GetFormAuthority(string account, int moduleID, string menuName)
        {
            return _MyBridge.GetFormAuthority(account, moduleID, menuName);
        }
    }




}
