using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class AdvertiInfo
    {
        private readonly DAL.AdvertiInfo dal = new DAL.AdvertiInfo();
        public AdvertiInfo()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int gg_GongGID)
        {
            return dal.Exists(gg_GongGID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.AdvertiInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.AdvertiInfo model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 启用禁用
        /// </summary>
        /// <param name="gg_ID"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        public string Update_Enable(int gg_ID, int isEnable)
        {
            return dal.Update_Enable(gg_ID, isEnable);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int gg_GongGID)
        {
            return dal.Delete(gg_GongGID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.AdvertiInfo GetModel(int gg_GongGID)
        {

            return dal.GetModel(gg_GongGID);
        }

        /// <summary>
        /// 获取相关数据表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere, string Top)
        {
            return dal.GetDataBySql(strWhere, Top);
        }

        /// <summary>
        /// 获取幻灯片信息
        /// </summary>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable GetPPT(int Top,string strWeiZ)
        {
            return GetDataBySql(" AND gg_Delete=0 and gg_GongGWZ='" + strWeiZ + "' order by gg_Enabled asc,gg_GongGID desc ", " TOP " + Top);
        }
    }
}
