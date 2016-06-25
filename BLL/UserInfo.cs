using System;
using System.Data;
using System.Collections.Generic;
using Model;
using DAL;

namespace BLL
{
	/// <summary>
	/// UserInfo
	/// </summary>
	public partial class UserInfo
	{
		private readonly DAL.UserInfo dal=new DAL.UserInfo();
		public UserInfo()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Model.UserInfo model)
		{
            return dal.Exists(model);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string  Add(Model.UserInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public string Update(Model.UserInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserID)
		{
			return dal.Delete(UserID);
		}

        /// <summary>
        /// 禁用启用
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IsEnable"></param>
        /// <returns></returns>
        public bool IsEnable(int UserID, int IsEnable)
        {
            return dal.IsEnabled(UserID, IsEnable);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool IsResetPassword(int UserID, string Password)
        {
            return dal.IsResetPassword(UserID, Password);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.UserInfo GetModel(int UserID)
		{
			return dal.GetModel(UserID);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UserInfo GetModel(Model.UserInfo model)
        {
            return dal.GetModel(model);
        }
		#endregion  Method
        #region 2012/11/14 张瑞丹
        /// <summary>
        /// 获取后台用户名
        /// </summary>
        public static DataTable GetUsername(int id)
        {
            return new DAL.UserInfo().GetUsername(id);
        }
        #endregion
	}
}

