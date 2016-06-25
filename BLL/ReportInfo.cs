using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace BLL
{
    public class ReportInfo
    {
        private readonly DAL.ReportInfo dal = new DAL.ReportInfo();
        public ReportInfo()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int rt_JuBID)
        {
            return dal.Exists(rt_JuBID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.ReportInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.ReportInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int rt_JuBID)
        {
            return dal.Delete(rt_JuBID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ReportInfo GetModel(int rt_JuBID)
        {

            return dal.GetModel(rt_JuBID);
        }

    }
}
