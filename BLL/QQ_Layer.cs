using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    /// <summary>
    /// QQ_Layer
    /// </summary>
    public partial class QQ_Layer
    {
        private readonly DAL.QQ_Layer dal = new DAL.QQ_Layer();
        public QQ_Layer()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int q_id)
        {
            return dal.Exists(q_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.QQ_Layer model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.QQ_Layer model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int q_id)
        {

            return dal.Delete(q_id);
        }

        public DataTable GetDataBySql(string strWhere, string Top) 
        {
            return dal.GetDataBySql(strWhere,Top);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.QQ_Layer GetModel(int q_id) 
        {
            return dal.GetModel(q_id);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
