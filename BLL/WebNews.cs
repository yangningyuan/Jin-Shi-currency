using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;
namespace BLL
{
    /// <summary>
    /// WebNews
    /// </summary>
    public partial class WebNews
    {
        private readonly DAL.WebNews dal = new DAL.WebNews();
        public WebNews()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.WebNews model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.WebNews model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.WebNews GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.WebNews> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.WebNews> DataTableToList(DataTable dt)
        {
            List<Model.WebNews> modelList = new List<Model.WebNews>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.WebNews model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string UpdateTop(int id, int status)
        {
            return dal.UpdateTop(id,status);
        }
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UpdateTop(int id)
        {
            return dal.UpdateTop(id, 1);
        }
        /// <summary>
        /// 获取置顶信息实体
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public Model.WebNews GetTopModel(int typeId)
        {
            return dal.GetTopModel(typeId);
        }

        public DataTable GetProAndNextList(string strWhere, string orderby, int newId, string rowNumber)
        {
            return dal.GetProAndNextList(strWhere, orderby, newId, rowNumber);
        }
        /// <summary>
        /// 获取当前行号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public int GetCurrentRowNumber(string strWhere, string orderBy, int newsid)
        {
            return dal.GetCurrentRowNumber(strWhere, orderBy, newsid);
        }
        /// <summary>
        /// 获取上一行下一行
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="OrderBy"></param>
        /// <param name="newId"></param>
        /// <returns></returns>
        public DataTable GetProAndNextList(string strWhere, string OrderBy, int newId, out int currentRow)
        {

            currentRow = GetCurrentRowNumber(strWhere, OrderBy, newId);

            string rowList = (currentRow - 1) + "," + (currentRow + 1);

            return GetProAndNextList(strWhere, OrderBy, newId, rowList);
        }
        #endregion  ExtensionMethod
    }
}

