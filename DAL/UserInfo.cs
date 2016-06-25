using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
using System.IO;
using System.Collections.Generic;
namespace DAL
{
    /// <summary>
    /// 数据访问类:UserInfo
    /// </summary>
    public partial class UserInfo
    {
        public UserInfo()
        { }
        #region  Method
        /// <summary>
        /// 是否存在用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where ui_YongHDLMC=@ui_YongHDLMC  and ui_YongHDLMM=@ui_YongHDLMM and ui_Deleted=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@ui_YongHDLMC", SqlDbType.VarChar,256),
                    new SqlParameter("@ui_YongHDLMM",SqlDbType.VarChar,256)};
            parameters[0].Value = model.ui_YongHDLMC;
            parameters[1].Value = model.ui_YongHDLMM;
            object o = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (Convert.ToInt32(o) > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.UserInfo model)
        {
            string result = "";
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into UserInfo(");
                strSql.Append("ui_YongHDLMC,ui_YongHDLMM,ui_JueSID,ui_Enalbed,ui_Deleted,ui_YongHBZ)");
                strSql.Append(" values (");
                strSql.Append("@ui_YongHDLMC,@ui_YongHDLMM,@ui_JueSID,@ui_Enalbed,@ui_Deleted,@ui_YongHBZ)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@ui_YongHDLMC", SqlDbType.NVarChar,50),
					new SqlParameter("@ui_YongHDLMM", SqlDbType.NVarChar,50),
					new SqlParameter("@ui_JueSID", SqlDbType.Int,4),
					new SqlParameter("@ui_Enalbed", SqlDbType.Int,4),
					new SqlParameter("@ui_Deleted", SqlDbType.Int,4),
					new SqlParameter("@ui_YongHBZ", SqlDbType.NVarChar)};
                parameters[0].Value = model.ui_YongHDLMC;
                parameters[1].Value = model.ui_YongHDLMM;
                parameters[2].Value = model.ui_JueSID;
                parameters[3].Value = model.ui_Enalbed;
                parameters[4].Value = model.ui_Deleted;
                parameters[5].Value = model.ui_YongHBZ;

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
        public string Update(Model.UserInfo model)
        {
            string result = "";
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update UserInfo set ");
                strSql.Append("ui_YongHDLMC=@ui_YongHDLMC,");
                strSql.Append("ui_YongHDLMM=@ui_YongHDLMM,");
                strSql.Append("ui_JueSID=@ui_JueSID,");
                strSql.Append("ui_Enalbed=@ui_Enalbed,");
                strSql.Append("ui_Deleted=@ui_Deleted,");
                strSql.Append("ui_YongHBZ=@ui_YongHBZ");
                strSql.Append(" where ui_YongHID=@ui_YongHID");
                SqlParameter[] parameters = {
					new SqlParameter("@ui_YongHDLMC", SqlDbType.NVarChar,50),
					new SqlParameter("@ui_YongHDLMM", SqlDbType.NVarChar,50),
					new SqlParameter("@ui_JueSID", SqlDbType.Int,4),
					new SqlParameter("@ui_Enalbed", SqlDbType.Int,4),
					new SqlParameter("@ui_Deleted", SqlDbType.Int,4),
					new SqlParameter("@ui_YongHBZ", SqlDbType.NVarChar),
					new SqlParameter("@ui_YongHID", SqlDbType.Int,4)};
                parameters[0].Value = model.ui_YongHDLMC;
                parameters[1].Value = model.ui_YongHDLMM;
                parameters[2].Value = model.ui_JueSID;
                parameters[3].Value = model.ui_Enalbed;
                parameters[4].Value = model.ui_Deleted;
                parameters[5].Value = model.ui_YongHBZ;
                parameters[6].Value = model.ui_YongHID;

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded|" + model.ui_YongHID;
            }
            catch (Exception e)
            {
                result = "error|" + e.Message;
            }
            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ui_Deleted=1 ");
            strSql.Append(" where ui_YongHID=@ui_YongHID");
            SqlParameter[] parameters = {
					new SqlParameter("@ui_YongHID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

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

        /// <summary>
        /// 禁用启用用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IsEnabled"></param>
        /// <returns></returns>
        public bool IsEnabled(int UserID, int IsEnabled)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ui_Enalbed=@ui_Enalbed ");
            strSql.Append(" where ui_YongHID=@ui_YongHID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ui_Enalbed",SqlDbType.Int,4),
					new SqlParameter("@ui_YongHID", SqlDbType.Int,4)
                };
            parameters[0].Value = IsEnabled;
            parameters[1].Value = UserID;

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

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool IsResetPassword(int UserID, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ui_YongHDLMM=@ui_YongHDLMM ");
            strSql.Append(" where ui_YongHID=@ui_YongHID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ui_YongHDLMM",SqlDbType.NVarChar,50),
					new SqlParameter("@ui_YongHID", SqlDbType.Int,4)
                };
            parameters[0].Value = Password;
            parameters[1].Value = UserID;

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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>  
        public Model.UserInfo GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ui_YongHID,ui_YongHDLMC,ui_YongHDLMM,ui_JueSID,ui_Enalbed,ui_Deleted,ui_YongHBZ from UserInfo ");
            strSql.Append(" where ui_YongHID=@ui_YongHID and ui_Deleted=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@ui_YongHID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;
            Model.UserInfo model = new Model.UserInfo();
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ui_YongHID"] != null && ds.Tables[0].Rows[0]["ui_YongHID"].ToString() != "")
                {
                    model.ui_YongHID = int.Parse(ds.Tables[0].Rows[0]["ui_YongHID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ui_YongHDLMC"] != null && ds.Tables[0].Rows[0]["ui_YongHDLMC"].ToString() != "")
                {
                    model.ui_YongHDLMC = ds.Tables[0].Rows[0]["ui_YongHDLMC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ui_YongHDLMM"] != null && ds.Tables[0].Rows[0]["ui_YongHDLMM"].ToString() != "")
                {
                    model.ui_YongHDLMM = ds.Tables[0].Rows[0]["ui_YongHDLMM"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ui_JueSID"] != null && ds.Tables[0].Rows[0]["ui_JueSID"].ToString() != "")
                {
                    model.ui_JueSID = int.Parse(ds.Tables[0].Rows[0]["ui_JueSID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ui_Enalbed"] != null && ds.Tables[0].Rows[0]["ui_Enalbed"].ToString() != "")
                {
                    model.ui_Enalbed = int.Parse(ds.Tables[0].Rows[0]["ui_Enalbed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ui_Deleted"] != null && ds.Tables[0].Rows[0]["ui_Deleted"].ToString() != "")
                {
                    model.ui_Deleted = int.Parse(ds.Tables[0].Rows[0]["ui_Deleted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ui_YongHBZ"] != null && ds.Tables[0].Rows[0]["ui_YongHBZ"].ToString() != "")
                {
                    model.ui_YongHBZ = ds.Tables[0].Rows[0]["ui_YongHBZ"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>  
        public Model.UserInfo GetModel(Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ui_YongHID,ui_YongHDLMC,ui_YongHDLMM,ui_JueSID,ui_Enalbed,ui_Deleted,ui_YongHBZ from UserInfo ");
            strSql.Append(" where ui_YongHDLMC=@ui_YongHDLMC and ui_YongHDLMM=@ui_YongHDLMM and ui_Deleted=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@ui_YongHDLMC", SqlDbType.NVarChar,50),
					new SqlParameter("@ui_YongHDLMM", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = model.ui_YongHDLMC;
            parameters[1].Value = model.ui_YongHDLMM;

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ui_YongHID"] != null && ds.Tables[0].Rows[0]["ui_YongHID"].ToString() != "")
                {
                    model.ui_YongHID = int.Parse(ds.Tables[0].Rows[0]["ui_YongHID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ui_YongHDLMC"] != null && ds.Tables[0].Rows[0]["ui_YongHDLMC"].ToString() != "")
                {
                    model.ui_YongHDLMC = ds.Tables[0].Rows[0]["ui_YongHDLMC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ui_YongHDLMM"] != null && ds.Tables[0].Rows[0]["ui_YongHDLMM"].ToString() != "")
                {
                    model.ui_YongHDLMM = ds.Tables[0].Rows[0]["ui_YongHDLMM"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ui_JueSID"] != null && ds.Tables[0].Rows[0]["ui_JueSID"].ToString() != "")
                {
                    model.ui_JueSID = int.Parse(ds.Tables[0].Rows[0]["ui_JueSID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ui_Enalbed"] != null && ds.Tables[0].Rows[0]["ui_Enalbed"].ToString() != "")
                {
                    model.ui_Enalbed = int.Parse(ds.Tables[0].Rows[0]["ui_Enalbed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ui_Deleted"] != null && ds.Tables[0].Rows[0]["ui_Deleted"].ToString() != "")
                {
                    model.ui_Deleted = int.Parse(ds.Tables[0].Rows[0]["ui_Deleted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ui_YongHBZ"] != null && ds.Tables[0].Rows[0]["ui_YongHBZ"].ToString() != "")
                {
                    model.ui_YongHBZ = ds.Tables[0].Rows[0]["ui_YongHBZ"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="TableName"></param>
        /// <param name="SqlFiled"></param>
        /// <param name="PrimaryKey"></param>
        /// <param name="SqlOrder"></param>
        /// <param name="ZCount"></param>
        /// <returns></returns>
        public List<Model.UserInfo> GetUserInfo(string strWhere, int PageSize, int PageIndex, string TableName, string SqlFiled, string PrimaryKey, string SqlOrder, out int ZCount)
        {
            List<Model.UserInfo> UserInfoModel = new List<Model.UserInfo>();
            SqlParameter[] parms = new SqlParameter[]
            { 
                new SqlParameter("@SqlWhere", SqlDbType.VarChar,8000),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@SqlTable", SqlDbType.VarChar,8000),
                new SqlParameter("@SqlField", SqlDbType.VarChar,8000),
                new SqlParameter("@SqlPK", SqlDbType.VarChar,50),
                new SqlParameter("@SqlOrder", SqlDbType.VarChar),
                new SqlParameter("@Count", SqlDbType.Int),
            };
            parms[0].Value = strWhere;
            parms[1].Value = PageSize;
            parms[2].Value = PageIndex;
            parms[3].Value = TableName;
            parms[4].Value = SqlFiled;
            parms[5].Value = PrimaryKey;
            parms[6].Value = SqlOrder;
            parms[7].Direction = ParameterDirection.Output;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "pagination", parms);
            ZCount = int.Parse(parms[7].Value.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model.UserInfo _UserInfo = new Model.UserInfo();
                _UserInfo.ui_YongHID = int.Parse(dt.Rows[i]["ui_YongHID"].ToString());
                _UserInfo.ui_YongHDLMC = dt.Rows[i]["ui_YongHDLMC"].ToString();
                _UserInfo.ui_YongHDLMM = dt.Rows[i]["ui_YongHDLMM"].ToString();
                _UserInfo.ui_JueSID = int.Parse(dt.Rows[i]["ui_JueSID"].ToString());
                _UserInfo.ui_Enalbed = int.Parse(dt.Rows[i]["ui_Enalbed"].ToString());
                _UserInfo.ui_Deleted = int.Parse(dt.Rows[i]["ui_Deleted"].ToString());
                _UserInfo.ui_YongHBZ = dt.Rows[i]["ui_YongHBZ"].ToString();
                UserInfoModel.Add(_UserInfo);
            }
            return UserInfoModel;
        }

        #endregion  Method

        #region
        /// <summary>
        /// 获取后台用户名称
        /// </summary>
        public DataTable GetUsername(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ui_YongHID,ui_YongHDLMC from UserInfo ");
            strSql.Append(" where ui_Deleted=0 and ui_YongHID=@ui_YongHID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ui_YongHID", SqlDbType.Int,4)};
            parameters[0].Value = id;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            return dt;
        }
        #endregion
    }
}

