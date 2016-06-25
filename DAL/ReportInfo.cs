using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using DBUtility;
using System.Data.SqlClient;


namespace DAL
{
    public class ReportInfo
    {

        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int rt_JuBID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ReportInfo");
            strSql.Append(" where ");
            strSql.Append(" rt_JuBID = @rt_JuBID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@rt_JuBID", SqlDbType.Int,4)
			};
            parameters[0].Value = rt_JuBID;


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
        public string Add(Model.ReportInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReportInfo(");
            strSql.Append("rt_ShangPJYID,rt_JuBLX,rt_JuBNR,rt_JuBRQ,rt_YongHID,rt_Deleted,rt_JuBLB,rt_LianXDH");
            strSql.Append(") values (");
            strSql.Append("@rt_ShangPJYID,@rt_JuBLX,@rt_JuBNR,@rt_JuBRQ,@rt_YongHID,@rt_Deleted,@rt_JuBLB,@rt_LianXDH");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@rt_ShangPJYID", SqlDbType.Int,4),   
			            new SqlParameter("@rt_JuBLX", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@rt_JuBNR", SqlDbType.NVarChar) ,            
                        new SqlParameter("@rt_JuBRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@rt_YongHID", SqlDbType.Int,4) ,            
                        new SqlParameter("@rt_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@rt_JuBLB", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@rt_LianXDH", SqlDbType.NVarChar,50)             
              
            };
            parameters[0].Value = model.rt_ShangPJYID;
            parameters[1].Value = model.rt_JuBLX;
            parameters[2].Value = model.rt_JuBNR;
            parameters[3].Value = model.rt_JuBRQ;
            parameters[4].Value = model.rt_YongHID;
            parameters[5].Value = model.rt_Deleted;
            parameters[6].Value = model.rt_JuBLB;
            parameters[7].Value = model.rt_LianXDH; string result = "";
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
        public string Update(Model.ReportInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReportInfo set ");
            strSql.Append(" rt_ShangPJYID = @rt_ShangPJYID , ");
            strSql.Append(" rt_JuBLX = @rt_JuBLX , ");
            strSql.Append(" rt_JuBNR = @rt_JuBNR , ");
            strSql.Append(" rt_JuBRQ = @rt_JuBRQ , ");
            strSql.Append(" rt_YongHID = @rt_YongHID , ");
            strSql.Append(" rt_Deleted = @rt_Deleted , ");
            strSql.Append(" rt_JuBLB = @rt_JuBLB , ");
            strSql.Append(" rt_LianXDH = @rt_LianXDH  ");
            strSql.Append(" where rt_JuBID=@rt_JuBID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@rt_ShangPJYID", SqlDbType.Int,4) ,            
                        new SqlParameter("@rt_JuBLX", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@rt_JuBNR", SqlDbType.NVarChar) ,            
                        new SqlParameter("@rt_JuBRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@rt_YongHID", SqlDbType.Int,4) ,            
                        new SqlParameter("@rt_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@rt_JuBLB", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@rt_LianXDH", SqlDbType.NVarChar,50),             
                        new SqlParameter("@rt_JuBID", SqlDbType.Int,4) 
            };

            parameters[0].Value = model.rt_ShangPJYID;
            parameters[1].Value = model.rt_JuBLX;
            parameters[2].Value = model.rt_JuBNR;
            parameters[3].Value = model.rt_JuBRQ;
            parameters[4].Value = model.rt_YongHID;
            parameters[5].Value = model.rt_Deleted;
            parameters[6].Value = model.rt_JuBLB;
            parameters[7].Value = model.rt_LianXDH;
            parameters[8].Value = model.rt_JuBID;
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
        public bool Delete(int rt_JuBID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReportInfo set");
            strSql.Append(" rt_Deleted=1  where rt_JuBID=@rt_JuBID");
            SqlParameter[] parameters = {
					new SqlParameter("@rt_JuBID", SqlDbType.Int,4)
			};
            parameters[0].Value = rt_JuBID;


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
        public Model.ReportInfo GetModel(int rt_JuBID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select rt_JuBID,rt_ShangPJYID, rt_JuBLX, rt_JuBNR, rt_JuBRQ, rt_YongHID, rt_Deleted, rt_JuBLB, rt_LianXDH  ");
            strSql.Append("  from ReportInfo ");
            strSql.Append(" where rt_JuBID=@rt_JuBID");
            SqlParameter[] parameters = {
					new SqlParameter("@rt_JuBID", SqlDbType.Int,4)
			};
            parameters[0].Value = rt_JuBID;


            Model.ReportInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model = new Model.ReportInfo();
                model.rt_JuBID = int.Parse(dt.Rows[0]["rt_JuBID"].ToString());
                model.rt_ShangPJYID = int.Parse(dt.Rows[0]["rt_ShangPJYID"].ToString());
                model.rt_JuBLX = dt.Rows[0]["rt_JuBLX"].ToString();
                model.rt_JuBNR = dt.Rows[0]["rt_JuBNR"].ToString();
                model.rt_JuBRQ = DateTime.Parse(dt.Rows[0]["rt_JuBRQ"].ToString());
                model.rt_YongHID = int.Parse(dt.Rows[0]["rt_YongHID"].ToString());
                model.rt_Deleted = int.Parse(dt.Rows[0]["rt_Deleted"].ToString());
                model.rt_JuBLB = dt.Rows[0]["rt_JuBLB"].ToString();
                model.rt_LianXDH = dt.Rows[0]["rt_LianXDH"].ToString();

            }
            return model;
        }

    }
}
