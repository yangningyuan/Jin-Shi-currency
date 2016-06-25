using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common;

using System.Collections;

namespace BLL
{
    public class CommonBLL
    {
        /// <summary>
        /// 根据表名和where条件查询信息,当where条件非空时where子句前须加and   
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// /// <param name="sqlFields">查询的字段</param>
        /// <param name="sqlWhere">where子句(须加and)</param>
        /// <returns>datatable</returns>
        public static DataTable Select(string sqlTable, string sqlFields, string sqlWhere)
        {
            if (FilterHandler.ExistBadWord(sqlWhere))
                sqlWhere = " AND 1<>1 ";
            return new DAL.CommonDal().Select(sqlTable, sqlFields, sqlWhere);
        }

        /// <summary>
        ///  根据表名和where条件查询信息,当where条件非空时where子句前须加and
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// <param name="sqlFields">查询的字段</param>
        /// <param name="sqlWhere">where子句(须加and)</param>
        /// <param name="noStoredProcedure">标注是否使用存储过程的形式</param>
        /// <returns>datatable</returns>
        public static DataTable Select(string sqlTable, string sqlFields, string sqlWhere, bool noStoredProcedure)
        {
            if (FilterHandler.ExistBadWord(sqlWhere))
                sqlWhere = " AND 1<>1 ";
            return new DAL.CommonDal().Select(sqlTable, sqlFields, sqlWhere, noStoredProcedure);
        }

        /// <summary>
        /// 根据表名和where条件查询信息,当where条件非空时where子句前须加 and
        /// isServicesDB 用于 Servieces 数据库查询
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// /// <param name="sqlFields">查询的字段</param>
        /// <param name="sqlWhere">where子句(须加and)</param>
        /// <returns>datatable</returns>
        public static DataTable Select(string sqlTable, string sqlFields, string sqlWhere, string isServicesDB)
        {
            if (FilterHandler.ExistBadWord(sqlWhere))
                sqlWhere = " AND 1<>1 ";
            return new DAL.CommonDal().Select(sqlTable, sqlFields, sqlWhere, isServicesDB);
        }

        /// <summary>
        /// 根据表名和where条件删除信息 True 为物理删除, sqlWhere 不须加 AND 
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// <param name="sqlWhere">where子句</param>
        /// <param name="bl">是否物理删除</param>
        public static void Delete(string sqlTable, string sqlWhere, bool bl)
        {
            if (FilterHandler.ExistBadWord(sqlWhere))
                sqlWhere = " AND 1<>1 ";
            new DAL.CommonDal().Delete(sqlTable, sqlWhere, bl);
        }

        /// <summary>
        /// 根据表名和where条件删除信息 True 为物理删除, sqlWhere 不须加 AND,  用于 Servieces 数据库查询
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// <param name="sqlWhere">where子句</param>
        /// <param name="bl">是否物理删除</param>
        public static void Delete(string sqlTable, string sqlWhere, bool bl, string isServicesDB)
        {
            if (FilterHandler.ExistBadWord(sqlWhere))
                sqlWhere = " AND 1<>1 ";
            new DAL.CommonDal().Delete(sqlTable, sqlWhere, bl, isServicesDB);
        }

        /// <summary>
        /// 获取指定字段的值, sqlText SQL 语句, isServicesDB = True 使用 Services 为主数据库
        /// </summary>
        public static object ExecuteScalar(string sqlText, bool isServicesDB)
        {
            if (FilterHandler.ExistBadWord(sqlText))
                return null;
            return (new DAL.CommonDal().ExecuteScalar(sqlText, isServicesDB));
        }

        /// <summary>
        /// 获取指定字段的值, sqlFields 必须为 单个字段或函数, sqlWhere 须加 AND
        /// </summary>
        public static object ExecuteScalar(string sqlTable, string sqlFields, string sqlWhere)
        {
            if (FilterHandler.ExistBadWord(sqlWhere))
                sqlWhere = " AND 1<>1 ";
            return (new DAL.CommonDal().ExecuteScalar(sqlTable, sqlFields, sqlWhere));
        }
        /// <summary>
        /// 获取指定字段的值, sqlFields 必须为 单个字段或函数, sqlWhere 须加 AND，isServicesDB = True 使用 Services 为主数据库
        /// </summary>
        public static object ExecuteScalar(string sqlTable, string sqlFields, string sqlWhere, bool isServicesDB)
        {
            if (FilterHandler.ExistBadWord(sqlWhere))
                sqlWhere = " AND 1<>1 ";
            return (new DAL.CommonDal().ExecuteScalar(sqlTable, sqlFields, sqlWhere, isServicesDB));
        }


        /// <summary>
        /// 获取数据表(Access)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            if (FilterHandler.ExistBadWord(sql))
                return new DataTable();
            return (new DAL.CommonDal().GetDataTable(sql));
        }

        private string _TabName = "";
        private string _Condition;
        private string _selectDataField = "*";
        private string _Datakeyfield = "";
        private string _orderby;
        private int _PageIndex = 1;
        private int _PageSize = 25;
        private Hashtable _FieldsParameter;
        private int _recordCount = -1;

        /// <summary>
        /// 表名  不能为空
        /// </summary>
        public string TabName
        {
            set { _TabName = value; }
            get { return _TabName; }
        }
        /// <summary>
        /// 查询条件 如：and name!='' and id>5
        /// </summary>
        public string Condition
        {
            set { _Condition = value; }
            get { return _Condition; }
        }
        /// <summary>
        /// 查询字段
        /// </summary>
        public string selectDataField
        {
            set { _selectDataField = value; }
            get { return _selectDataField; }
        }
        /// <summary>
        /// 主键
        /// </summary>
        public string Datakeyfield
        {
            set { _Datakeyfield = value; }
            get { return _Datakeyfield; }
        }
        /// <summary>
        /// 排序条件 (可以为空)
        /// </summary>
        public string orderby
        {
            set { _orderby = value; }
            get { return _orderby; }
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            set { _PageIndex = value; }
            get { return _PageIndex; }
        }
        /// <summary>
        /// 页大小 默认25
        /// </summary>
        public int PageSize
        {
            set { _PageSize = value; }
            get { return _PageSize; }
        }
        /// <summary>
        /// Hashtable key：列名,value：值 ht.add("title","%abc%") (可以为空)
        /// </summary>
        public Hashtable FieldsParameter
        {
            set { _FieldsParameter = value; }
            get { return _FieldsParameter; }
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }
        private string _testSql = "";
        public string testSql
        {
            get { return _testSql; }
            set { _testSql = value; }
        }



        /// 得到DataSet 适用各种情况
        /// <summary>
        /// 得到DataSet 适用各种情况
        /// </summary>
        /// <param name="TabName">表名</param>
        /// <param name="Condition">条件 如：and name!='' and id>5 </param>
        /// <param name="selectDataField">要查找的字段</param>
        /// <param name="Datakeyfield">主键</param>
        /// <param name="orderby">排序</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize0">每页记录数</param>
        /// <returns></returns>
        //public DataSet GetPageDataSet()
        //{
        //    //0<pagesize0>1<Datafield>2<tab_name>3<Datakeyfield>4<Condition>5<pagesize*(nowpage-1)>6<_order>
        //    string sql = string.Format("select top {0} {1} from {2} where 1=1 {3} and {4} not in (select top {5} {4} from {2} where 1=1 {3} {6}){6}", PageSize.ToString(), selectDataField, TabName, Condition, Datakeyfield, (PageSize * (PageIndex - 1)).ToString(), orderby);

        //    DataSet ds = null;
        //    dataWork dw = new dataWork();

        //    testSql += sql;
        //    if (FieldsParameter != null)
        //    {
        //        ds = dw.GetDS(FieldsParameter, sql);
        //    }
        //    else
        //    {
        //        ds = dw.GetDS(sql);
        //    }
        //    GetPageCount();
        //    return ds;
        //}
        //private void GetPageCount()
        //{
        //    string sql = string.Format("select count(1) from {0} where 1=1 {1}", TabName, Condition);

        //    RecordCount = new dataWork().SelectCount(sql);
        //}
    }
}
