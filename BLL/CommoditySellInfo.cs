using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;
namespace BLL
{
	/// <summary>
	/// CommoditySellInfo
	/// </summary>
	public partial class CommoditySellInfo
	{
		private readonly DAL.CommoditySellInfo dal=new DAL.CommoditySellInfo();
		public CommoditySellInfo()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cs_ZhuangRID)
		{
			return dal.Exists(cs_ZhuangRID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string  Add(Model.CommoditySellInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public string Update(Model.CommoditySellInfo model)
		{
			return dal.Update(model);
		}
        /// <summary>
        /// 更新：启用禁用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        public string Update_Enable(int id, int isEnable)
        {
            return dal.Update_Enable(id, isEnable);
        }

        /// <summary>
        /// 修改浏览数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Update_cs_LiuLS(int id)
        {
             dal.Update_cs_LiuLS(id);
        }

        /// <summary>
        /// 修改留言数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Update_cs_LiuYS(int id)
        {
             dal.Update_cs_LiuYS(id);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int cs_ZhuangRID)
		{
			
			return dal.Delete(cs_ZhuangRID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string cs_ZhuangRIDlist )
		{
			return dal.DeleteList(cs_ZhuangRIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.CommoditySellInfo GetModel(int cs_ZhuangRID)
		{
			
			return dal.GetModel(cs_ZhuangRID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.CommoditySellInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.CommoditySellInfo> DataTableToList(DataTable dt)
		{
			List<Model.CommoditySellInfo> modelList = new List<Model.CommoditySellInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.CommoditySellInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Model.CommoditySellInfo();
					if(dt.Rows[n]["cs_ZhuangRID"]!=null && dt.Rows[n]["cs_ZhuangRID"].ToString()!="")
					{
						model.cs_ZhuangRID=int.Parse(dt.Rows[n]["cs_ZhuangRID"].ToString());
					}
					if(dt.Rows[n]["pt_YongHID"]!=null && dt.Rows[n]["pt_YongHID"].ToString()!="")
					{
						model.pt_YongHID=int.Parse(dt.Rows[n]["pt_YongHID"].ToString());
					}
					if(dt.Rows[n]["cs_FengLCode"]!=null && dt.Rows[n]["cs_FengLCode"].ToString()!="")
					{
					model.cs_FenLCode=dt.Rows[n]["cs_FengLCode"].ToString();
					}
					if(dt.Rows[n]["cs_ShangPMC"]!=null && dt.Rows[n]["cs_ShangPMC"].ToString()!="")
					{
					model.cs_ShangPMC=dt.Rows[n]["cs_ShangPMC"].ToString();
					}
					if(dt.Rows[n]["cs_ZhuangRJG"]!=null && dt.Rows[n]["cs_ZhuangRJG"].ToString()!="")
					{
					model.cs_ZhuangRJG=dt.Rows[n]["cs_ZhuangRJG"].ToString();
					}
					if(dt.Rows[n]["cs_ShangPJJ"]!=null && dt.Rows[n]["cs_ShangPJJ"].ToString()!="")
					{
					model.cs_ShangPJJ=dt.Rows[n]["cs_ShangPJJ"].ToString();
					}
					if(dt.Rows[n]["cs_ShangPBZ"]!=null && dt.Rows[n]["cs_ShangPBZ"].ToString()!="")
					{
					model.cs_ShangPBZ=dt.Rows[n]["cs_ShangPBZ"].ToString();
					}
					if(dt.Rows[n]["cs_Enabled"]!=null && dt.Rows[n]["cs_Enabled"].ToString()!="")
					{
						model.cs_Enabled=int.Parse(dt.Rows[n]["cs_Enabled"].ToString());
					}
					if(dt.Rows[n]["cs_Deleted"]!=null && dt.Rows[n]["cs_Deleted"].ToString()!="")
					{
						model.cs_Deleted=int.Parse(dt.Rows[n]["cs_Deleted"].ToString());
					}
					if(dt.Rows[n]["cs_FaBRQ"]!=null && dt.Rows[n]["cs_FaBRQ"].ToString()!="")
					{
						model.cs_FaBRQ=DateTime.Parse(dt.Rows[n]["cs_FaBRQ"].ToString());
					}
					if(dt.Rows[n]["cs_LianXDZ"]!=null && dt.Rows[n]["cs_LianXDZ"].ToString()!="")
					{
					model.cs_LianXDZ=dt.Rows[n]["cs_LianXDZ"].ToString();
					}
					if(dt.Rows[n]["cs_QuYCode"]!=null && dt.Rows[n]["cs_QuYCode"].ToString()!="")
					{
					model.cs_QuYCode=dt.Rows[n]["cs_QuYCode"].ToString();
					}
					if(dt.Rows[n]["cs_ShangPTPLJ"]!=null && dt.Rows[n]["cs_ShangPTPLJ"].ToString()!="")
					{
					model.cs_ShangPTPLJ=dt.Rows[n]["cs_ShangPTPLJ"].ToString();
					}
					if(dt.Rows[n]["cs_LianXR"]!=null && dt.Rows[n]["cs_LianXR"].ToString()!="")
					{
					model.cs_LianXR=dt.Rows[n]["cs_LianXR"].ToString();
					}
					if(dt.Rows[n]["cs_LianXDH"]!=null && dt.Rows[n]["cs_LianXDH"].ToString()!="")
					{
					model.cs_LianXDH=dt.Rows[n]["cs_LianXDH"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		#endregion  Method
	}
}

