using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    //Placard
    public partial class Placard
    {

        private readonly DAL.Placard dal = new DAL.Placard();
        public Placard()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int pi_GongGID)
        {
            return dal.Exists(pi_GongGID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.Placard model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.Placard model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int pi_GongGID)
        {
            return dal.Delete(pi_GongGID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Placard GetModel(int pi_GongGID)
        {

            return dal.GetModel(pi_GongGID);
        }
        #endregion
    }
}