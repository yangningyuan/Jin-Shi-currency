using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class WebSiteBase
    {
         private readonly DAL.WebSiteBase dal = new DAL.WebSiteBase();
         public WebSiteBase()
        { }

        #region  Method
      
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>返回结果(success和Id)</returns>
        public string Add(Model.WebSiteBase model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 得到一个实体类
        /// </summary>
        /// <returns></returns>
        public Model.WebSiteBase GetModel(int Ws_Id)
        {
            return dal.GetModel(Ws_Id);
        }
        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetModels()
        {
            return dal.GetModels();
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(Model.WebSiteBase model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ws_Id"></param>
        /// <returns></returns>
        public string DeleteById(int ws_Id)
        {
            return dal.DeleteById(ws_Id);
        }
        /// <summary>
        /// 得到所有数据
        /// </summary>
        public DataSet GetseoByLB(string bianma)
        {
            return dal.GetseoByLB(bianma);
        }
        /// <summary>
        /// 根据条件获取网站信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere, string Top)
        {
            return dal.GetDataBySql(strWhere, Top);
        }
        /// <summary>
        /// 根据查询条件获取网站信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere)
        {
            return GetDataBySql(strWhere, "");
        }
        #endregion
    }
}
