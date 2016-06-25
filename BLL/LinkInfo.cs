using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class LinkInfo
    {

        private readonly DAL.LinkInfo dal = new DAL.LinkInfo();
        public LinkInfo()
        { }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int li_LinKID)
        {
            return dal.Exists(li_LinKID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.LinkInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.LinkInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int li_LinKID)
        {
            return dal.Delete(li_LinKID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.LinkInfo GetModel(int li_LinKID)
        {
            return dal.GetModel(li_LinKID);
        }
        /// <summary>
        /// 根据条件获链接信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere, string Top)
        {
            return dal.GetDataBySql(strWhere, Top);
        }
    }
}
