using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
namespace BLL
{
    public class AreaInfo
    {
        private readonly DAL.AreaInfo dal = new DAL.AreaInfo();
        public AreaInfo()
        { }

        #region  Method
        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int IndustryID)
        //{
        //    return dal.Exists(IndustryID);
        //}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.AreaInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.AreaInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ai_QuYID)
        {
            return dal.Delete(ai_QuYID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.AreaInfo GetModel(string ai_QuYCode)
        {
            return dal.GetModel(ai_QuYCode);
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="it_HangYFlCode"></param>
        /// <returns></returns>
        public string GetIndustryName(string ai_QuYCode)
        {
            return dal.GetIndustryName(ai_QuYCode);
        }

        #endregion
    }
}
