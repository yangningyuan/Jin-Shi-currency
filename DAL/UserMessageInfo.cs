using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
using System.IO;
using System.Collections.Generic;

namespace DAL
{
    public partial class UserMessageInfo
    {
        public UserMessageInfo()
        { }
        #region  Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.UserMessageInfo model)
        {
            string result = "";
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into UserMessageInfo(");
                strSql.Append("pt_YongHID,um_LiuYNR,um_JIaoYID,um_JiaoYLX,um_LiuYRQ,um_Deleted)");
                strSql.Append(" values (");
                strSql.Append("@pt_YongHID,@um_LiuYNR,@um_JIaoYID,@um_JiaoYLX,@um_LiuYRQ,@um_Deleted)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4),
					new SqlParameter("@um_LiuYNR", SqlDbType.NVarChar),
					new SqlParameter("@um_JIaoYID", SqlDbType.Int,4),
					new SqlParameter("@um_JiaoYLX", SqlDbType.Int,4),
					new SqlParameter("@um_LiuYRQ", SqlDbType.DateTime),
					new SqlParameter("@um_Deleted", SqlDbType.Int,4)};
                parameters[0].Value = model.pt_YongHID;
                parameters[1].Value = model.um_LiuYNR;
                parameters[2].Value = model.um_JIaoYID;
                parameters[3].Value = model.um_JiaoYLX;
                parameters[4].Value = model.um_LiuYRQ;
                parameters[5].Value = model.um_Deleted;

                object id = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded|" + id.ToString();
            }
            catch (Exception e)
            {
                result = "error|" + e.Message;
            }
            return result;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.UserMessageInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserMessageInfo set ");
            strSql.Append(" pt_YongHID = @pt_YongHID , ");
            strSql.Append(" um_LiuYNR = @um_LiuYNR , ");
            strSql.Append(" um_JIaoYID = @um_JIaoYID , ");
            strSql.Append(" um_JiaoYLX = @um_JiaoYLX ");
            strSql.Append(" um_LiuYRQ = @um_LiuYRQ , ");
            strSql.Append(" um_Deleted = @um_Deleted  ");
            strSql.Append(" where um_LiuYID=@um_LiuYID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@um_LiuYID", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_YongHID", SqlDbType.Int,4) ,            
                        new SqlParameter("@um_LiuYNR", SqlDbType.NVarChar) ,            
                        new SqlParameter("@um_JIaoYID", SqlDbType.Int,4) ,            
                        new SqlParameter("@um_JiaoYLX", SqlDbType.Int,4) ,            
                        new SqlParameter("@um_LiuYRQ", SqlDbType.DateTime) ,
                        new SqlParameter("@um_Deleted", SqlDbType.Int,4) 
              
            };

            parameters[0].Value = model.um_LiuYID;
            parameters[1].Value = model.pt_YongHID;
            parameters[2].Value = model.um_LiuYNR;
            parameters[3].Value = model.um_JIaoYID;
            parameters[4].Value = model.um_JiaoYLX;
            parameters[5].Value = model.um_LiuYRQ;
            parameters[6].Value = model.um_Deleted;
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
        public bool Delete(int um_LiuYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserMessageInfo set um_Deleted=1 ");
            strSql.Append(" where um_LiuYID=@um_LiuYID");
            SqlParameter[] parameters = {
					new SqlParameter("@um_LiuYID", SqlDbType.Int,4)
			};
            parameters[0].Value = um_LiuYID;

            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        ///// <summary>
        /////  物理 删除一条数据
        ///// </summary>
        //public bool Delete(int um_LiuYID)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append(" delete from UserMessageInfo");
        //    strSql.Append(" where um_LiuYID=@um_LiuYID ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@um_LiuYID", SqlDbType.Int,4)			};
        //    parameters[0].Value = um_LiuYID;

        //    int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UserMessageInfo GetModel(int um_LiuYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select um_LiuYID, pt_YongHID, um_LiuYNR, um_JIaoYID, um_JiaoYLX, um_LiuYRQ,um_Deleted  ");
            strSql.Append("  from UserMessageInfo ");
            strSql.Append(" where um_LiuYID=@um_LiuYID ");
            SqlParameter[] parameters = {
					new SqlParameter("@um_LiuYID", SqlDbType.Int,4)	};
            parameters[0].Value = um_LiuYID;


            Model.UserMessageInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model = new Model.UserMessageInfo();
                model.um_LiuYID = int.Parse(dt.Rows[0]["um_LiuYID"].ToString());
                model.pt_YongHID = int.Parse(dt.Rows[0]["pt_YongHID"].ToString());
                model.um_LiuYNR = dt.Rows[0]["um_LiuYNR"].ToString();
                model.um_JIaoYID = int.Parse(dt.Rows[0]["um_JIaoYID"].ToString());
                model.um_JiaoYLX = int.Parse(dt.Rows[0]["um_JiaoYLX"].ToString());
                model.um_LiuYRQ = DateTime.Parse(dt.Rows[0]["um_LiuYRQ"].ToString());
                model.um_Deleted = int.Parse(dt.Rows[0]["um_Deleted"].ToString());
            }
            return model;
        }


        /// <summary>
        /// 获取留言信息
        /// </summary>
        /// <param name="um_JIaoYID"></param>
        /// <returns></returns>
        public DataTable GetDataTalbe(int um_JIaoYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 5 * ");
            strSql.Append("  from UserMessageInfo ");
            strSql.Append(" where um_Deleted=0 and um_JIaoYID=@um_JIaoYID ");
            SqlParameter[] parameters = {
					new SqlParameter("@um_JIaoYID", SqlDbType.Int,4)	};
            parameters[0].Value = um_JIaoYID;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            return dt;
        }
        #endregion  Method
    }
}
