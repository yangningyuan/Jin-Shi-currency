using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PT_UserlInfo
    {
        private readonly DAL.PT_UserlInfo dal = new DAL.PT_UserlInfo();
        public PT_UserlInfo()
        { }

        /// <summary>
        /// 判断当前数据是否存在【和总的用户表匹配】
        /// </summary>
        public bool ExistsUserName(string UserName)
        {
            return dal.ExistsUserName(UserName);
        }

        /// <summary>
        /// 判断当前数据是否存在【和总的用户表匹配】
        /// </summary>
        public bool ExistsEmail(string Email)
        {
            return dal.ExistsEmail(Email);
        }

        /// <summary>
        /// 判断当前数据是否存在【和总的用户表匹配】
        /// </summary>
        public bool Login(string UserName, string Password)
        {
            return dal.Login(UserName,Password);
        }
        /// <summary>
        /// 判断当前数据是否存在【和总的用户表匹配】
        /// </summary>
        public bool Login_PlatForm(string UserName, string Password)
        {
            return dal.Login_PlatForm(UserName, Password);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.PT_UserlInfo model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Register(Model.PT_UserlInfo model)
        {
            return dal.Register(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.PT_UserlInfo model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Update_Password(string username, string password)
        {
            return dal.Update_Password(username, password);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int pt_YongHID)
        {
            return dal.Delete(pt_YongHID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.PT_UserlInfo GetModel(int pt_YongHID)
        {

            return dal.GetModel(pt_YongHID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.PT_UserlInfo GetModel(string username)
        {
            return dal.GetModel(username);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Plat_UserlInfo GetModel_PlatForm(string username)
        {
            return dal.GetModel_PlatForm(username);
        }
    }
}
