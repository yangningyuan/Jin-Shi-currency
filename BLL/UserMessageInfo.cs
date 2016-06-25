using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public partial class UserMessageInfo
    {
        private readonly DAL.UserMessageInfo dal = new DAL.UserMessageInfo();
        public UserMessageInfo()
        { }

        #region  Method
      
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.UserMessageInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.UserMessageInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据(物理)
        /// </summary>
        public bool Delete(int um_LiuYID)
        {
            return dal.Delete(um_LiuYID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UserMessageInfo GetModel(int um_LiuYID)
        {
            return dal.GetModel(um_LiuYID);
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="um_JIaoYID"></param>
        /// <returns></returns>
        public DataTable GetDataTable(int um_JIaoYID)
        {
            return dal.GetDataTalbe(um_JIaoYID);
        }
        #endregion
    }
}
