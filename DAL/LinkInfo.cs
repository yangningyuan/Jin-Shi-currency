using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace DAL
{
    public class LinkInfo
    {
        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int li_LinKID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LinkInfo");
            strSql.Append(" where ");
            strSql.Append(" li_LinKID = @li_LinKID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@li_LinKID", SqlDbType.Int,4)
			};
            parameters[0].Value = li_LinKID;
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
        public string Add(Model.LinkInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LinkInfo(");
            strSql.Append("li_LinkMC,li_LinKDZ,li_LinkTPDZ,li_Delete,li_CaoZR,li_CaoZRQ,li_LinkPX");
            strSql.Append(") values (");
            strSql.Append("@li_LinkMC,@li_LinKDZ,@li_LinkTPDZ,@li_Delete,@li_CaoZR,@li_CaoZRQ,@li_LinkPX");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@li_LinkMC", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@li_LinKDZ", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@li_LinkTPDZ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@li_Delete", SqlDbType.Int,4) ,            
                        new SqlParameter("@li_CaoZR", SqlDbType.Int,4) ,            
                        new SqlParameter("@li_CaoZRQ", SqlDbType.DateTime),
                        new SqlParameter("@li_LinkPX",SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.li_LinkMC;
            parameters[1].Value = model.li_LinKDZ;
            parameters[2].Value = model.li_LinkTPDZ;
            parameters[3].Value = model.li_Delete;
            parameters[4].Value = model.li_CaoZR;
            parameters[5].Value = model.li_CaoZRQ;
            parameters[6].Value = model.li_LinkPX; string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded";
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
        public string Update(Model.LinkInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LinkInfo set ");

            strSql.Append(" li_LinkMC = @li_LinkMC , ");
            strSql.Append(" li_LinKDZ = @li_LinKDZ , ");
            strSql.Append(" li_LinkTPDZ = @li_LinkTPDZ,");
            strSql.Append(" li_LinkPX = @li_LinkPX  ");
            strSql.Append(" where li_LinKID=@li_LinKID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@li_LinKID", SqlDbType.Int,4) ,            
                        new SqlParameter("@li_LinkMC", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@li_LinKDZ", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@li_LinkTPDZ", SqlDbType.NVarChar,50),
                        new SqlParameter("@li_LinkPX",SqlDbType.Int,4)            
            };
            parameters[0].Value = model.li_LinKID;
            parameters[1].Value = model.li_LinkMC;
            parameters[2].Value = model.li_LinKDZ;
            parameters[3].Value = model.li_LinkTPDZ;
            parameters[4].Value = model.li_LinkPX;
            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded";
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
        public bool Delete(int li_LinKID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LinkInfo set");
            strSql.Append(" li_Delete=1  where li_LinKID=@li_LinKID");
            SqlParameter[] parameters = {
					new SqlParameter("@li_LinKID", SqlDbType.Int,4)
			};
            parameters[0].Value = li_LinKID;
            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
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
        public Model.LinkInfo GetModel(int li_LinKID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select li_LinKID, li_LinkMC, li_LinKDZ, li_LinkTPDZ, li_Delete, li_CaoZR, li_CaoZRQ,li_LinkPX ");
            strSql.Append("  from LinkInfo ");
            strSql.Append(" where li_LinKID=@li_LinKID");
            SqlParameter[] parameters = {
					new SqlParameter("@li_LinKID", SqlDbType.Int,4)
			};
            parameters[0].Value = li_LinKID;


            Model.LinkInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model = new Model.LinkInfo();
                model.li_LinKID = int.Parse(dt.Rows[0]["li_LinKID"].ToString());
                model.li_LinkMC = dt.Rows[0]["li_LinkMC"].ToString();
                model.li_LinKDZ = dt.Rows[0]["li_LinKDZ"].ToString();
                model.li_LinkTPDZ = dt.Rows[0]["li_LinkTPDZ"].ToString();
                model.li_Delete = int.Parse(dt.Rows[0]["li_Delete"].ToString());
                model.li_CaoZR = int.Parse(dt.Rows[0]["li_CaoZR"].ToString());
                model.li_CaoZRQ = DateTime.Parse(dt.Rows[0]["li_CaoZRQ"].ToString());
                if (!String.IsNullOrEmpty(dt.Rows[0]["li_LinkPX"].ToString()))
                {
                    model.li_LinkPX = int.Parse(dt.Rows[0]["li_LinkPX"].ToString());
                }
                else model.li_LinkPX = 0;
            }
            return model;
        }

        /// <summary>
        /// 根据条件加载友情链接信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere, string Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Top + " *  ");
            strSql.Append("  from LinkInfo ");
            strSql.Append(" where 1=1 ");
            if (strWhere.Trim() != "")
                strSql.Append(strWhere);
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            if (dt.Rows.Count <= 0)
                return null;

            return dt;
        }
    }
}
