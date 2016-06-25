using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Common;

namespace BLL
{
    public partial class CommoditySortInfo
    {

        private readonly DAL.CommoditySortInfo dal = new DAL.CommoditySortInfo();
        public CommoditySortInfo()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sp_FenLID)
        {
            return dal.Exists(sp_FenLID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.CommoditySortInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.CommoditySortInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int sp_FenLID)
        {
            return dal.Delete(sp_FenLID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.CommoditySortInfo GetModel(string sp_FenLCode)
        {
            return dal.GetModel(sp_FenLCode);
        }

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="sp_FenLCode"></param>
        /// <returns></returns>
        public string GetCommoditySortName(string sp_FenLCode)
        {
            return dal.GetCommoditySortName(sp_FenLCode);
        }

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="Strwhere"></param>
        /// <returns></returns>
        public DataTable GetCommoditySortDataTable(string sp_FCode)
        {
            return dal.GetCommoditySortDataTable(sp_FCode);
        }
        #endregion

    }
}
