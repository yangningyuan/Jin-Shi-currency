using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class GuestBookBase
    {
        private readonly DAL.GuestBookBase dal = new DAL.GuestBookBase();
        public GuestBookBase()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.GuestBookBase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.GuestBookBase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int gb_LiuYID)
        {
            return dal.Delete(gb_LiuYID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.GuestBookBase GetModel(int gb_LiuYID)
        {

            return dal.GetModel(gb_LiuYID);
        }
        #endregion
    }
}

