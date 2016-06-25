using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class AboutUsInfo
    {
        private readonly DAL.AboutUsInfo dal = new DAL.AboutUsInfo();
        public AboutUsInfo()
        { }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int au_XinXID)
        {
            return dal.Exists(au_XinXID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.AboutUsInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.AboutUsInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int au_XinXID)
        {
            return dal.Delete(au_XinXID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.AboutUsInfo GetModel(int au_XinXID)
        {

            return dal.GetModel(au_XinXID);
        }
        /// <summary>
        /// 更新栏目
        /// </summary>
        public string Update_lanmu(Model.AboutUsInfo model)
        {
            return dal.Update_lanmu(model);
        }
        /// <summary>
        /// 更新内容
        /// </summary>
        public string Update_neirong(Model.AboutUsInfo model)
        {
            return dal.Update_neirong(model);
        }
    }
}
