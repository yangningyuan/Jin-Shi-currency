using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Model;


namespace BLL
{
    public partial class CommodityCollectInfo
    {

        private readonly DAL.CommodityCollectInfo dal = new DAL.CommodityCollectInfo();
        public CommodityCollectInfo()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int cc_ShouCID)
        {
            return dal.Exists(cc_ShouCID);
        }

        /// <summary>
        /// 是否存在该收藏记录
        /// </summary>
        /// <param name="cc_ShouCID"></param>
        /// <param name="cc_YongHID"></param>
        /// <returns></returns>
        public bool Exists_Collect(int cc_ShangPID, int cc_YongHID)
        {
            return dal.Exists_Collect(cc_ShangPID, cc_YongHID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.CommodityCollectInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.CommodityCollectInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int cc_ShouCID)
        {
            return dal.Delete(cc_ShouCID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.CommodityCollectInfo GetModel(int cc_ShouCID)
        {

            return dal.GetModel(cc_ShouCID);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetCommodityList(string strWhere)
        {
            return dal.GetCommodityList(strWhere);
        }

        #endregion

    }
}
