using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;
namespace BLL
{
	/// <summary>
	/// CommodityBuyInfo
	/// </summary>
	public partial class CommodityBuyInfo
	{
		private readonly DAL.CommodityBuyInfo dal=new DAL.CommodityBuyInfo();
		public CommodityBuyInfo()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cb_ShangPID)
		{
			return dal.Exists(cb_ShangPID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string  Add(Model.CommodityBuyInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public string Update(Model.CommodityBuyInfo model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 禁用记录
        /// </summary>
        public bool Update_Enable(int cb_ShangPID,int isEnable)
        {
            return dal.Update_Enable(cb_ShangPID, isEnable);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int cb_ShangPID)
		{
			return dal.Delete(cb_ShangPID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string cb_ShangPIDlist )
		{
			return dal.DeleteList(cb_ShangPIDlist );
		}

        /// <summary>
        /// 修改留言数量
        /// </summary>
        /// <param name="ID"></param>
        public void Update_LiuYS(int ID)
        {
            dal.Update_cs_LiuLS(ID);
        }

        /// <summary>
        /// 修改浏览数量
        /// </summary>
        /// <param name="ID"></param>
        public void Update_LiuLS(int ID)
        {
            dal.Update_cs_LiuLS(ID);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.CommodityBuyInfo GetModel(int cb_ShangPID)
		{
			
			return dal.GetModel(cb_ShangPID);
		}

		#endregion  Method
	}
}

