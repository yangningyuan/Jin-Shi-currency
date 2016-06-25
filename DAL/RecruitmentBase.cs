using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Data;

namespace DAL
{
    public class RecruitmentBase
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.RecruitmentBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RecruitmentBase(");
            strSql.Append("rm_ZhaoPZW,rm_RenS,rm_XueL,rm_XingB,rm_DaiY,rm_YaoQ,rm_CreatDate,rm_Status,rm_Delete,rm_PaiX,rm_GongZDD,rm_enddate");
            strSql.Append(") values (");
            strSql.Append("@rm_ZhaoPZW,@rm_RenS,@rm_XueL,@rm_XingB,@rm_DaiY,@rm_YaoQ,@rm_CreatDate,@rm_Status,@rm_Delete,@rm_PaiX,@rm_GongZDD,@rm_enddate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@rm_ZhaoPZW", SqlDbType.VarChar,100) ,
                        new SqlParameter("@rm_RenS", SqlDbType.VarChar,100) ,
                        new SqlParameter("@rm_XueL", SqlDbType.VarChar,100) ,
                        new SqlParameter("@rm_XingB", SqlDbType.VarChar,50) ,
                        new SqlParameter("@rm_DaiY", SqlDbType.VarChar,500) ,
                        new SqlParameter("@rm_YaoQ", SqlDbType.VarChar) ,
                        new SqlParameter("@rm_CreatDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@rm_Status", SqlDbType.Int,4) ,
                        new SqlParameter("@rm_Delete", SqlDbType.Int,4) ,
                        new SqlParameter("@rm_PaiX", SqlDbType.Int,4),
                        new SqlParameter("@rm_GongZDD", SqlDbType.NVarChar,100),
                        new SqlParameter("@rm_enddate",SqlDbType.DateTime)
            };
            parameters[0].Value = model.rm_ZhaoPZW;
            parameters[1].Value = model.rm_RenS;
            parameters[2].Value = model.rm_XueL;
            parameters[3].Value = model.rm_XingB;
            parameters[4].Value = model.rm_DaiY;
            parameters[5].Value = model.rm_YaoQ;
            parameters[6].Value = model.rm_CreatDate;
            parameters[7].Value = model.rm_Status;
            parameters[8].Value = model.rm_Delete;
            parameters[9].Value = model.rm_PaiX;
            parameters[10].Value = model.rm_GongZDD;
            parameters[11].Value = model.rm_enddate;
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
        /// 更新一条数据(回复)
        /// </summary>
        public string Update(Model.RecruitmentBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RecruitmentBase set ");
            strSql.Append(" rm_ZhaoPZW = @rm_ZhaoPZW , ");
            strSql.Append(" rm_RenS = @rm_RenS , ");
            strSql.Append(" rm_XueL = @rm_XueL , ");
            strSql.Append(" rm_XingB = @rm_XingB , ");
            strSql.Append(" rm_DaiY = @rm_DaiY, ");
            strSql.Append(" rm_YaoQ = @rm_YaoQ,  ");
            strSql.Append(" rm_PaiX = @rm_PaiX,  ");
            strSql.Append(" rm_CreatDate = @rm_CreatDate,  ");
            strSql.Append(" rm_GongZDD = @rm_GongZDD,  ");
            strSql.Append(" rm_enddate=@rm_enddate");

            strSql.Append(" where rm_ID=@rm_ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@rm_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@rm_ZhaoPZW", SqlDbType.VarChar,100) ,
                        new SqlParameter("@rm_RenS", SqlDbType.VarChar,100) ,
                        new SqlParameter("@rm_XueL", SqlDbType.VarChar,100) ,
                        new SqlParameter("@rm_XingB", SqlDbType.VarChar,50) ,
                        new SqlParameter("@rm_DaiY", SqlDbType.VarChar,500) ,
                        new SqlParameter("@rm_YaoQ", SqlDbType.VarChar) ,
                        new SqlParameter("@rm_PaiX", SqlDbType.Int,4),
                        new SqlParameter("@rm_CreatDate", SqlDbType.DateTime) ,  
                        new SqlParameter("@rm_GongZDD", SqlDbType.NVarChar,100),
                        new SqlParameter("@rm_enddate",SqlDbType.DateTime)
            };
            parameters[0].Value = model.rm_ID;
            parameters[1].Value = model.rm_ZhaoPZW;
            parameters[2].Value = model.rm_RenS;
            parameters[3].Value = model.rm_XueL;
            parameters[4].Value = model.rm_XingB;
            parameters[5].Value = model.rm_DaiY;
            parameters[6].Value = model.rm_YaoQ;
            parameters[7].Value = model.rm_PaiX;
            parameters[8].Value = model.rm_CreatDate;
            parameters[9].Value = model.rm_GongZDD;
            parameters[10].Value = model.rm_enddate;
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
        public string Delete(int rm_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RecruitmentBase set");
            strSql.Append(" rm_Delete=1 where rm_ID=@rm_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@rm_ID", SqlDbType.Int,4),
			};
            parameters[0].Value = rm_ID;
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
        /// 更新状态
        /// </summary>
        public string Upstatus(int rm_ID, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RecruitmentBase set");
            strSql.Append(" rm_Status=@rm_Status where rm_ID=@rm_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@rm_ID", SqlDbType.Int,4),
                    new SqlParameter("@rm_Status", SqlDbType.Int,4)
			};
            parameters[0].Value = rm_ID;
            parameters[1].Value = status;
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
        /// 得到一个对象实体
        /// </summary>
        public Model.RecruitmentBase GetModel(int rm_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select rm_ID,rm_ZhaoPZW,rm_RenS,rm_XueL,rm_XingB,rm_DaiY,rm_YaoQ,rm_CreatDate,rm_Status,rm_Delete,rm_PaiX,rm_GongZDD,rm_enddate ");
            strSql.Append("  from RecruitmentBase ");
            strSql.Append(" where rm_ID=@rm_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@rm_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = rm_ID;
            Model.RecruitmentBase model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.RecruitmentBase();
                model.rm_ID = int.Parse(dt.Rows[0]["rm_ID"].ToString());
                model.rm_ZhaoPZW = dt.Rows[0]["rm_ZhaoPZW"].ToString();
                model.rm_RenS = dt.Rows[0]["rm_RenS"].ToString();
                model.rm_XueL = dt.Rows[0]["rm_XueL"].ToString();
                model.rm_XingB = dt.Rows[0]["rm_XingB"].ToString();
                model.rm_DaiY = dt.Rows[0]["rm_DaiY"].ToString();
                model.rm_YaoQ = dt.Rows[0]["rm_YaoQ"].ToString();
                model.rm_CreatDate = DateTime.Parse(dt.Rows[0]["rm_CreatDate"].ToString());
                model.rm_Status = int.Parse(dt.Rows[0]["rm_Status"].ToString());
                model.rm_Delete = int.Parse(dt.Rows[0]["rm_Delete"].ToString());
                model.rm_PaiX = int.Parse(dt.Rows[0]["rm_PaiX"].ToString());
                model.rm_GongZDD = dt.Rows[0]["rm_GongZDD"].ToString();
                model.rm_enddate = DateTime.Parse(dt.Rows[0]["rm_enddate"].ToString());
            }
            return model;
        }
        /// <summary>
        /// 获取招聘列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from RecruitmentBase ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" where {0}", strWhere);
            }
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            return dt;
        }
    }
}

