using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class MenuInfo
    {
        DAL.MenuInfo dal = new DAL.MenuInfo();
        #region 方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.MenuInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.MenuInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MenuID)
        {
            return dal.Delete(MenuID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MenuInfo GetModel(int MenuID)
        {
            return dal.GetModel(MenuID);
        }
        #endregion
        #region  ExtensionMethod
        /// <summary>
        /// 获取菜单名称
        /// </summary>
        /// <param name="id">菜单id</param>
        public string GetName(int id)
        {
            return dal.GetName(id);
        }
        /// <summary>
        /// 根据查询条件获取菜单信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere, string Top)
        {
            return dal.GetDataBySql(strWhere, Top);
        }
        /// <summary>
        /// 根据查询条件获取菜单信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere)
        {
            return GetDataBySql(strWhere, "");
        }
        #endregion  ExtensionMethod
    }
}
