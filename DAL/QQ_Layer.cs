using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    /// <summary>
    /// 数据访问类:QQ_Layer
    /// </summary>
    public partial class QQ_Layer
    {
        public QQ_Layer()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int q_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from QQ_Layer");
            strSql.Append(" where q_id=@q_id");
            SqlParameter[] parameters = {
					new SqlParameter("@q_id", SqlDbType.Int,4)
			};
            parameters[0].Value = q_id;

            bool bl = true;
            try
            {
                object o = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                if (Convert.ToInt32(o) == 0)
                {
                    bl = false;
                }
            }
            catch (Exception ex)
            {
                bl = false;
            }

            return bl;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.QQ_Layer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QQ_Layer(");
            strSql.Append("qq_code,qq_alt,qq_paixu,qq_createdate,qq_state,qq_delete)");
            strSql.Append(" values (");
            strSql.Append("@qq_code,@qq_alt,@qq_paixu,@qq_createdate,@qq_state,@qq_delete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@qq_code", SqlDbType.NVarChar,50),
					new SqlParameter("@qq_alt", SqlDbType.NVarChar,100),
					new SqlParameter("@qq_paixu", SqlDbType.Int,4),
					new SqlParameter("@qq_createdate", SqlDbType.DateTime),
					new SqlParameter("@qq_state", SqlDbType.Int,4),
					new SqlParameter("@qq_delete", SqlDbType.Int,4)};
            parameters[0].Value = model.qq_code;
            parameters[1].Value = model.qq_alt;
            parameters[2].Value = model.qq_paixu;
            parameters[3].Value = model.qq_createdate;
            parameters[4].Value = model.qq_state;
            parameters[5].Value = model.qq_delete;

            int obj = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,CommandType.Text, strSql.ToString(), parameters);
            if (obj == 1)
            {
                return "succeeded";
            }
            else
            {
                return "error";
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.QQ_Layer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QQ_Layer set ");
            strSql.Append("qq_code=@qq_code,");
            strSql.Append("qq_alt=@qq_alt,");
            strSql.Append("qq_paixu=@qq_paixu,");
            strSql.Append("qq_createdate=@qq_createdate,");
            strSql.Append("qq_state=@qq_state,");
            strSql.Append("qq_delete=@qq_delete");
            strSql.Append(" where q_id=@q_id");
            SqlParameter[] parameters = {
					new SqlParameter("@qq_code", SqlDbType.NVarChar,50),
					new SqlParameter("@qq_alt", SqlDbType.NVarChar,100),
					new SqlParameter("@qq_paixu", SqlDbType.Int,4),
					new SqlParameter("@qq_createdate", SqlDbType.DateTime),
					new SqlParameter("@qq_state", SqlDbType.Int,4),
					new SqlParameter("@qq_delete", SqlDbType.Int,4),
					new SqlParameter("@q_id", SqlDbType.Int,4)};
            parameters[0].Value = model.qq_code;
            parameters[1].Value = model.qq_alt;
            parameters[2].Value = model.qq_paixu;
            parameters[3].Value = model.qq_createdate;
            parameters[4].Value = model.qq_state;
            parameters[5].Value = model.qq_delete;
            parameters[6].Value = model.q_id;

            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,CommandType.Text,strSql.ToString(), parameters);
            if (rows == 1)
            {
                return "succeeded";
            }
            else
            {
                return "error";
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int q_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from QQ_Layer ");
            strSql.Append(" where q_id=@q_id");
            SqlParameter[] parameters = {
					new SqlParameter("@q_id", SqlDbType.Int,4)
			};
            parameters[0].Value = q_id;

            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,CommandType.Text,strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.QQ_Layer GetModel(int q_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 q_id,qq_code,qq_alt,qq_paixu,qq_createdate,qq_state,qq_delete from QQ_Layer ");
            strSql.Append(" where q_id=@q_id");
            SqlParameter[] parameters = {
					new SqlParameter("@q_id", SqlDbType.Int,4)
			};
            parameters[0].Value = q_id;

            Model.QQ_Layer model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.QQ_Layer();
                model.q_id = int.Parse(dt.Rows[0]["q_id"].ToString());
                model.qq_code = dt.Rows[0]["qq_code"].ToString();
                model.qq_paixu = int.Parse(dt.Rows[0]["qq_paixu"].ToString());
                model.qq_alt = dt.Rows[0]["qq_alt"].ToString();
                model.qq_createdate = DateTime.Parse(dt.Rows[0]["qq_createdate"].ToString());
                model.qq_state = int.Parse(dt.Rows[0]["qq_state"].ToString());
                model.qq_delete = int.Parse(dt.Rows[0]["qq_delete"].ToString());
                return model;
            }
            else
            {
                return new Model.QQ_Layer();
            }
        }
        /// <summary>
        /// 根据条件QQ信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere, string Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   "+Top+"  q_id,qq_code,qq_alt,qq_paixu,qq_createdate,qq_state,qq_delete ");
            strSql.Append(" FROM QQ_Layer ");
            strSql.Append(" where 1=1 ");
            if (strWhere.Trim() != "")
                strSql.Append(strWhere);
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            if (dt.Rows.Count <= 0)
                return null;

            return dt;
        }
        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "QQ_Layer";
            parameters[1].Value = "q_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
