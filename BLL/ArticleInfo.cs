using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ArticleInfo
    {
        private readonly DAL.ArticleInfo dal = new DAL.ArticleInfo();
        public ArticleInfo()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ai_WenZID, string ai_WenZBT, int ai_WenZLX, string ai_WenZLC, int ai_FaBR, DateTime ai_FaBRQ, int ai_Deleted)
        {
            return dal.Exists(ai_WenZID, ai_WenZBT, ai_WenZLX, ai_WenZLC, ai_FaBR, ai_FaBRQ, ai_Deleted);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.ArticleInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.ArticleInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int ai_WenZID)
        {
            return dal.Delete(ai_WenZID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ArticleInfo GetModel(int ai_WenZID)
        {
            return dal.GetModel(ai_WenZID);
        }

        #endregion

    }
}
