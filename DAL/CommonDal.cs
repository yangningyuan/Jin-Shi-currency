using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using System.Configuration;
using System.Data.OleDb;

namespace DAL
{
    public class CommonDal
    {
        SqlParameter[] parms;

        public CommonDal()
        { }
        /// <summary>
        /// 根据表名和where条件查询信息,当where条件非空时where子句前须加and
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// /// <param name="sqlFields">查询的字段</param>
        /// <param name="sqlWhere">where子句(须加and)</param>
        /// <returns>datatable</returns>
        public DataTable Select(string sqlTable, string sqlFields, string sqlWhere)
        {
            parms = new SqlParameter[] {
                new SqlParameter("@SqlTable",SqlDbType.NVarChar, 4000),
                new SqlParameter("@SqlFields",SqlDbType.VarChar, 20000),
                new SqlParameter("@SqlWhere", SqlDbType.NVarChar, 3000)
            };
            parms[0].Value = sqlTable;
            parms[1].Value = sqlFields;
            parms[2].Value = sqlWhere;
            DataTable dt = new DataTable();

            try
            {
                dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Common_Select", parms);
            }
            catch (Exception err)
            { }

            return dt;
        }

        /// <summary>
        ///  根据表名和where条件查询信息,当where条件非空时where子句前须加and
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// <param name="sqlFields">查询的字段</param>
        /// <param name="sqlWhere">where子句(须加and)</param>
        /// <param name="noStoredProcedure">标注是否使用存储过程的形式</param>
        /// <returns>datatable</returns>
        public DataTable Select(string sqlTable, string sqlFields, string sqlWhere, bool noStoredProcedure)
        {
            string strSQL = "Select {0} From {1} Where 1=1 {2} ";

            DataTable dt = new DataTable();

            try
            {
                dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, string.Format(strSQL, sqlFields, sqlTable, sqlWhere));
            }
            catch (Exception err)
            { }

            return dt;
        }

        /// <summary>
        /// 根据表名和where条件查询信息,当where条件非空时where子句前须加and, 用于 Servieces 数据库查询
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// /// <param name="sqlFields">查询的字段</param>
        /// <param name="sqlWhere">where子句(须加and)</param>
        /// <returns>datatable</returns>
        public DataTable Select(string sqlTable, string sqlFields, string sqlWhere, string isServicesDB)
        {
            SqlConnection connship = new SqlConnection(SqlHelper.ConnectionStringMembership);
            parms = new SqlParameter[] {
                new SqlParameter("@SqlTable",SqlDbType.VarChar, 4000),
                new SqlParameter("@SqlFields",SqlDbType.VarChar, 20000),
                new SqlParameter("@SqlWhere", SqlDbType.NVarChar, 3000)
            };
            parms[0].Value = sqlTable;
            parms[1].Value = sqlFields;
            parms[2].Value = sqlWhere;

            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataTable(connship, CommandType.StoredProcedure, "Common_Select", parms);
            }
            catch (Exception err)
            { }
            finally
            {
                connship.Close();
                connship.Dispose();
            }
            return dt;
        }
        /// <summary>
        /// 根据表名和where条件删除信息, sqlWhere 不须加 AND
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// <param name="sqlWhere">where子句</param>
        /// <param name="bl">是否物理删除</param>
        public void Delete(string sqlTable, string sqlWhere, bool bl)
        {
            parms = new SqlParameter[] {
                new SqlParameter("@SqlTable",SqlDbType.NVarChar, 50),
                new SqlParameter("@SqlWhere", SqlDbType.NVarChar, 2000),
                new SqlParameter("@bl",SqlDbType.Bit)
            };
            parms[0].Value = sqlTable;
            parms[1].Value = sqlWhere;
            parms[2].Value = bl ? 1 : 0;

            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Common_Delete", parms);
            }
            catch
            { }
        }
        /// <summary>
        /// 根据表名和 where 条件删除信息, sqlWhere 不须加 AND,  用于 Servieces 数据库查询
        /// </summary>
        /// <param name="sqlTable">数据表名</param>
        /// <param name="sqlWhere">where子句</param>
        /// <param name="bl">是否物理删除</param>
        public void Delete(string sqlTable, string sqlWhere, bool bl, string isServicesDB)
        {
            SqlConnection connship = new SqlConnection(SqlHelper.ConnectionStringMembership);
            parms = new SqlParameter[] {
                new SqlParameter("@SqlTable",SqlDbType.NVarChar, 50),
                new SqlParameter("@SqlWhere", SqlDbType.NVarChar, 2000),
                new SqlParameter("@bl",SqlDbType.Bit)
            };
            parms[0].Value = sqlTable;
            parms[1].Value = sqlWhere;
            parms[2].Value = bl ? 1 : 0;

            try
            {
                SqlHelper.ExecuteNonQuery(connship, CommandType.StoredProcedure, "Common_Delete", parms);
            }
            catch
            { }
            finally
            {
                connship.Close();
                connship.Dispose();
            }
        }
        /// <summary>
        /// 获取指定字段的值, sqlText SQL 语句, isServicesDB = True 使用 Services 为主数据库
        /// </summary>
        public object ExecuteScalar(string sqlText, bool isServicesDB)
        {
            object _obj = null;
            try
            {
                if (isServicesDB)
                    _obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringMembership, CommandType.Text, sqlText, null);
                else
                    _obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sqlText, null);
            }
            catch (Exception err)
            { err.ToString(); }

            return _obj;
        }
        /// <summary>
        /// 获取指定字段的值, sqlFields 必须为 单个字段或函数, sqlWhere 须加 AND
        /// </summary>
        public object ExecuteScalar(string sqlTable, string sqlFields, string sqlWhere)
        {
            parms = new SqlParameter[] {
                new SqlParameter("@SqlTable",SqlDbType.VarChar, 4000),
                new SqlParameter("@SqlFields",SqlDbType.VarChar, 20000),
                new SqlParameter("@SqlWhere", SqlDbType.NVarChar, 3000)
            };
            parms[0].Value = sqlTable;
            parms[1].Value = sqlFields;
            parms[2].Value = sqlWhere;

            object _obj = null;
            try
            {
                _obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Common_Select", parms);
            }
            catch (Exception err)
            { err.ToString(); }

            return _obj;
        }

        /// <summary>
        /// 获取指定字段的值, sqlFields 必须为 单个字段或函数, sqlWhere 须加 AND， isServicesDB True 使用 Services 数据库
        /// </summary>
        public object ExecuteScalar(string sqlTable, string sqlFields, string sqlWhere, bool isServicesDB)
        {
            parms = new SqlParameter[] {
                new SqlParameter("@SqlTable",SqlDbType.VarChar, 4000),
                new SqlParameter("@SqlFields",SqlDbType.VarChar, 20000),
                new SqlParameter("@SqlWhere", SqlDbType.NVarChar, 3000)
            };
            parms[0].Value = sqlTable;
            parms[1].Value = sqlFields;
            parms[2].Value = sqlWhere;

            object _obj = null;
            try
            {
                if (isServicesDB)
                    _obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringMembership, CommandType.StoredProcedure, "Common_Select", parms);
                else
                    _obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Common_Select", parms);
            }
            catch (Exception err)
            { err.ToString(); }

            return _obj;
        }

        //#region 执行MirAccessHelper的方法
        //public string Conn()
        //{
        //    string conn = ConfigurationManager.ConnectionStrings["kaigo_CRMConnectionString2"].ToString();
        //    return conn;
        //}
        //public DataTable GetDataTable(string sql)
        //{
        //    using (OleDbConnection OleDbConn = new OleDbConnection(Conn()))
        //    {
        //        return OleDbHelper.ExecuteDataTable(OleDbConn, CommandType.Text, sql);
        //    }
        //}
        //#endregion

        public DataTable GetDataTable(string sql)
        {
            throw new NotImplementedException();
        }
    }
}

