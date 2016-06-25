using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class RecruitmentBase
    {
        private readonly DAL.RecruitmentBase dal = new DAL.RecruitmentBase();
        public RecruitmentBase()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.RecruitmentBase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.RecruitmentBase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int rm_ID)
        {
            return dal.Delete(rm_ID);
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        public string Upstatus(int rm_ID,int status)
        {
            return dal.Upstatus(rm_ID, status);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.RecruitmentBase GetModel(int rm_ID)
        {
            return dal.GetModel(rm_ID);
        }
         /// <summary>
        /// 获取招聘列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        #endregion
    }
}
