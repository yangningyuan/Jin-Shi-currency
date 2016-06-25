using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RoleMenusDetails
    {
        private DAL.RoleMenusDetails dal = new DAL.RoleMenusDetails();
        /// <summary>
        /// 批量添加角色权限
        /// </summary>
        /// <param name="list"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public string Add(List<Model.RoleMenusDetails> list, int RoleID)
        {
            return dal.Add(list, RoleID);
        }
        /// <summary>
        /// 根据角色id得到角色的菜单权限
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public List<Model.RoleMenusDetails> GetLIstByRoleID(int RoleID)
        {
            return dal.GetListByRoleId(RoleID);
        }
    }
}
