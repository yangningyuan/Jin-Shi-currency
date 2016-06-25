using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace DAL
{
    public partial class WebSiteBase
    {
        public WebSiteBase()
        { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Add(Model.WebSiteBase model)
        {
            string result = "";
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into WebSiteBase(");
                strSql.Append("ws_LeiB,ws_MingC,ws_BianM,ws_NeiR)");
                strSql.Append(" values (");
                strSql.Append("@Ws_LeiB,@Ws_MingC,@Ws_BianM,@Ws_NeiR)");
                SqlParameter[] parameters = {
					new SqlParameter("@Ws_LeiB", SqlDbType.NVarChar,20),
					new SqlParameter("@Ws_MingC", SqlDbType.VarChar,30),
					new SqlParameter("@Ws_BianM", SqlDbType.VarChar,30),
					new SqlParameter("@Ws_NeiR", SqlDbType.NVarChar,1000)};
                parameters[0].Value = model.Ws_LeiB;
                parameters[1].Value = model.Ws_MingC;
                parameters[2].Value = model.Ws_BianM;
                parameters[3].Value = model.Ws_NeiR;

                object id = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded|" + id.ToString();
            }
            catch (Exception e)
            {
                result = e.ToString();
            }
            return result;
        }

        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <returns></returns>
        public Model.WebSiteBase GetModel(int ws_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ws_Id, ws_MingC, ws_BianM, ws_LeiB, ws_NeiR ");
            strSql.Append("  from WebSiteBase ");
            strSql.Append(" where ws_Id=@ws_Id ");
             SqlParameter[] parameters = {
                                             	new SqlParameter("@ws_Id", SqlDbType.Int,4)	};
             parameters[0].Value = ws_Id;
         
            Model.WebSiteBase model = null;
           DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               model = new Model.WebSiteBase();
               model.Ws_Id = int.Parse(dt.Rows[0]["ws_Id"].ToString());
               model.Ws_BianM = dt.Rows[0]["ws_BianM"].ToString();
               model.Ws_LeiB = dt.Rows[0]["ws_LeiB"].ToString();
               model.Ws_MingC = dt.Rows[0]["ws_MingC"].ToString();
               model.Ws_NeiR = dt.Rows[0]["ws_NeiR"].ToString();
            }
            return model;
        }

        public DataSet GetModels()
        {
            string sql = "select * from WebSiteBase ";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql);
            return ds;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(Model.WebSiteBase model)
        {
            string sql = string.Format("update WebSiteBase set ws_MingC='{0}' ,ws_BianM='{1}', ws_NeiR='{2}',ws_LeiB='{3}' where ws_Id={4}", model.Ws_MingC, model.Ws_BianM, model.Ws_NeiR, model.Ws_LeiB, model.Ws_Id);


            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString());
                result = "succeeded";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }

        public string DeleteById(int ws_Id)
        {
            string sql = string.Format("delete from  WebSiteBase where ws_Id={0}", ws_Id);


            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString());
                result = "succeeded";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }
        /// <summary>
        /// 通过类别得title，描述，关键
        /// </summary>
        public DataSet GetseoByLB(string bianma)
        {
            string sql = "select * from WebSiteBase where ws_BianM='" + bianma + "'";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql);
            return ds;
        }

        /// <summary>
        /// 根据查询条件获取网站信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere, string Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Top + " *  ");
            strSql.Append("  from WebSiteBase ");
            strSql.Append(" where 1=1 ");
            if (strWhere.Trim() != "")
                strSql.Append(strWhere);
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            if (dt.Rows.Count <= 0)
                return null;

            return dt;
        }

        #endregion  Method
    }
}

