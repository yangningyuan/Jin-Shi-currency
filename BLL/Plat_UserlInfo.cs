using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Plat_UserlInfo
    {

        private readonly DAL.Plat_UserlInfo dal = new DAL.Plat_UserlInfo();
        public Plat_UserlInfo()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int pt_YongHID)
        {
            return dal.Exists(pt_YongHID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.Plat_UserlInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.Plat_UserlInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int pt_YongHID)
        {
            return dal.Delete(pt_YongHID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Plat_UserlInfo GetModel(int pt_YongHID)
        {

            return dal.GetModel(pt_YongHID);
        }

    }
}
