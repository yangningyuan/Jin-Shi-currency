using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DBUtility;

namespace DAL
{
    public partial class ArticleInfo
    {
        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int ai_WenZID, string ai_WenZBT, int ai_WenZLX, string ai_WenZLC, int ai_FaBR, DateTime ai_FaBRQ, int ai_Deleted)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ArticleInfo");
            strSql.Append(" where ");
            strSql.Append(" ai_WenZID = @ai_WenZID and  ");
            strSql.Append(" ai_WenZBT = @ai_WenZBT and  ");
            strSql.Append(" ai_WenZLX = @ai_WenZLX and  ");
            strSql.Append(" ai_WenZLC = @ai_WenZLC and  ");
            strSql.Append(" ai_FaBR = @ai_FaBR and  ");
            strSql.Append(" ai_FaBRQ = @ai_FaBRQ and  ");
            strSql.Append(" ai_Deleted = @ai_Deleted  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ai_WenZID", SqlDbType.Int,4),
					new SqlParameter("@ai_WenZBT", SqlDbType.NVarChar,500),
					new SqlParameter("@ai_WenZLX", SqlDbType.Int,4),
					new SqlParameter("@ai_WenZLC", SqlDbType.NVarChar),
					new SqlParameter("@ai_FaBR", SqlDbType.Int,4),
					new SqlParameter("@ai_FaBRQ", SqlDbType.DateTime),
					new SqlParameter("@ai_Deleted", SqlDbType.Int,4)			};
            parameters[0].Value = ai_WenZID;
            parameters[1].Value = ai_WenZBT;
            parameters[2].Value = ai_WenZLX;
            parameters[3].Value = ai_WenZLC;
            parameters[4].Value = ai_FaBR;
            parameters[5].Value = ai_FaBRQ;
            parameters[6].Value = ai_Deleted;


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
        public string Add(Model.ArticleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ArticleInfo(");
            strSql.Append("ai_WenZBT,ai_WenZLX,ai_WenZLC,ai_FaBR,ai_FaBRQ,ai_Deleted");
            strSql.Append(") values (");
            strSql.Append("@ai_WenZBT,@ai_WenZLX,@ai_WenZLC,@ai_FaBR,@ai_FaBRQ,@ai_Deleted");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        //new SqlParameter("@ai_WenZID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ai_WenZBT", SqlDbType.NVarChar,500) ,           
                        new SqlParameter("@ai_WenZLX", SqlDbType.Int,4) ,            
                        new SqlParameter("@ai_WenZLC", SqlDbType.NVarChar) ,            
                        new SqlParameter("@ai_FaBR", SqlDbType.Int,4) ,            
                        new SqlParameter("@ai_FaBRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@ai_Deleted", SqlDbType.Int,4)             
              
            };

            //parameters[0].Value = model.ai_WenZID;
            parameters[0].Value = model.ai_WenZBT;
            parameters[1].Value = model.ai_WenZLX;
            parameters[2].Value = model.ai_WenZLC;
            parameters[3].Value = model.ai_FaBR;
            parameters[4].Value = model.ai_FaBRQ;
            parameters[5].Value = model.ai_Deleted;
            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded|" + parameters[0].Value.ToString();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.ArticleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArticleInfo set ");

            //strSql.Append(" ai_WenZID = @ai_WenZID , ");
            strSql.Append(" ai_WenZBT = @ai_WenZBT, ");
            strSql.Append(" ai_WenZLX = @ai_WenZLX, ");
            strSql.Append(" ai_WenZLC = @ai_WenZLC ");
            //strSql.Append(" ai_FaBR = @ai_FaBR , ");
            //strSql.Append(" ai_FaBRQ = @ai_FaBRQ , ");
            //strSql.Append(" ai_Deleted = @ai_Deleted  ");
            strSql.Append(" where ai_WenZID=@ai_WenZID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ai_WenZID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ai_WenZBT", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@ai_WenZLX", SqlDbType.Int,4) ,            
                        new SqlParameter("@ai_WenZLC", SqlDbType.NVarChar)           
                        //new SqlParameter("@ai_FaBR", SqlDbType.Int,4) ,            
                        //new SqlParameter("@ai_FaBRQ", SqlDbType.DateTime) ,            
                        //new SqlParameter("@ai_Deleted", SqlDbType.Int,4)             
            };

            parameters[0].Value = model.ai_WenZID;
            parameters[1].Value = model.ai_WenZBT;
            parameters[2].Value = model.ai_WenZLX;
            parameters[3].Value = model.ai_WenZLC;
            //parameters[4].Value = model.ai_FaBR;
            //parameters[5].Value = model.ai_FaBRQ;
            //parameters[6].Value = model.ai_Deleted;
            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded|" + parameters[0].Value.ToString();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int ai_WenZID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArticleInfo set ai_Deleted=1 ");
            strSql.Append("where ai_WenZID=@ai_WenZID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ai_WenZID", SqlDbType.Int,4)};
            parameters[0].Value = ai_WenZID;

            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded|" + parameters[0].Value.ToString();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ArticleInfo GetModel(int ai_WenZID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ai_WenZID, ai_WenZBT, ai_WenZLX, ai_WenZLC, ai_FaBR, ai_FaBRQ, ai_Deleted from ArticleInfo ");
            strSql.Append(" where ai_WenZID=@ai_WenZID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ai_WenZID", SqlDbType.Int,4)};
            parameters[0].Value = ai_WenZID;

            Model.ArticleInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model = new Model.ArticleInfo();
                model.ai_WenZID = int.Parse(dt.Rows[0]["ai_WenZID"].ToString());
                model.ai_WenZBT = dt.Rows[0]["ai_WenZBT"].ToString();
                model.ai_WenZLX = int.Parse(dt.Rows[0]["ai_WenZLX"].ToString());
                model.ai_WenZLC = dt.Rows[0]["ai_WenZLC"].ToString();
                model.ai_FaBR = int.Parse(dt.Rows[0]["ai_FaBR"].ToString());
                model.ai_FaBRQ = DateTime.Parse(dt.Rows[0]["ai_FaBRQ"].ToString());
                model.ai_Deleted = int.Parse(dt.Rows[0]["ai_Deleted"].ToString());
            }
            return model;
        }
    }
}

