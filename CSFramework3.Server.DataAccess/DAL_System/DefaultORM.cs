using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework3.Server.DataAccess.DAL_System
{
    /// <summary>
    /// 说明：自定义特性，指定用于更新的ORM类. 
    /// 功能：跟据ORM类自动查询用于更新的数据层.
    /// </summary>
    public class DefaultORM_UpdateMode : Attribute
    {
        private Type _ORM = null;
        private bool _IsOverrideClass = false;

        /// <summary>
        /// 预设用于更新的ORM类
        /// </summary>
        public Type ORM { get { return _ORM; } set { _ORM = value; } }

        /// <summary>
        /// 子类重写了父类的方法，True:必须由具体类(子类)更新．
        /// </summary>
        public bool IsOverrideClass { get { return _IsOverrideClass; } set { _IsOverrideClass = value; } }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="ORM">预设用于更新的ORM类</param>
        /// <param name="ORM">ORM类</param>
        /// <param name="isOverrideClass">子类重写了父类的方法，True:必须由具体类(子类)更新．</param>
        public DefaultORM_UpdateMode(Type ORM, bool isOverrideClass)
        {
            _ORM = ORM;
            _IsOverrideClass = isOverrideClass;
        }
    }

}
