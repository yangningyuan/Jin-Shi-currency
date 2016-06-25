using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class RecoverInfo
    {
        private readonly DAL.RecoverInfo dal = new DAL.RecoverInfo();
        public RecoverInfo()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sr_HuiSID)
        {
            return dal.Exists(sr_HuiSID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.RecoverInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.RecoverInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int sr_HuiSID)
        {
            return dal.Delete(sr_HuiSID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.RecoverInfo GetModel(int sr_HuiSID)
        {

            return dal.GetModel(sr_HuiSID);
        }

        /// <summary>
        /// 获取回收信息列表
        /// </summary>
        /// <param name="sr_HuiSID"></param>
        /// <returns></returns>
        public DataTable GetRecoverInfo(int sr_HuiSID)
        {
            return dal.GetRecoverInfo(sr_HuiSID);
        }

        /// <summary>
        /// 获取信息列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetRecoverList(string strWhere)
        {
            return dal.GetRecoverList(strWhere);
        }

        public Model.RecoverInfo GetModel(string HuiSID)
        {
            throw new NotImplementedException();
        }
    }
}
