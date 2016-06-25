using System;
using System.Data;
using System.Collections.Generic;
using DAL;

namespace BLL
{
	/// <summary>
	/// RoleInfo
	/// </summary>
	public partial class RoleInfo
	{
        private readonly DAL.RoleInfo dal = new DAL.RoleInfo();
		public RoleInfo()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string  Add(Model.RoleInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public string Update(Model.RoleInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RoleID)
		{
			return dal.Delete(RoleID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.RoleInfo GetModel(int RoleID)
		{
			return dal.GetModel(RoleID);
		}

		#endregion  Method
	}
}

