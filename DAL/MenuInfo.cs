using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
    /// <summary>
    /// 数据访问类:MenuInfo
    /// </summary>
    public partial class MenuInfo
    {
        public MenuInfo()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.MenuInfo model)
        {
            string result = "";
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into MenuInfo(");
                strSql.Append("mi_CaiDMC,mi_CaiDDZ,mi_ChuangJRQ,mi_CaiDJB,mi_CaiDFID,mi_CaiDPX,mi_Delete,mi_NewType)");
                strSql.Append(" values (");
                strSql.Append("@mi_CaiDMC,@mi_CaiDDZ,@mi_ChuangJRQ,@mi_CaiDJB,@mi_CaiDFID,@mi_CaiDPX,@mi_Delete,@mi_NewType)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@mi_CaiDMC", SqlDbType.NVarChar,50),
					new SqlParameter("@mi_CaiDDZ", SqlDbType.NVarChar,50),
					new SqlParameter("@mi_ChuangJRQ", SqlDbType.DateTime),
					new SqlParameter("@mi_CaiDJB", SqlDbType.Int,4),
					new SqlParameter("@mi_CaiDFID", SqlDbType.Int,4),
					new SqlParameter("@mi_CaiDPX", SqlDbType.Int,4),
					new SqlParameter("@mi_Delete", SqlDbType.Int,4),
                    new SqlParameter("@mi_NewType", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.mi_CaiDMC;
                parameters[1].Value = model.mi_CaiDDZ;
                parameters[2].Value = model.mi_ChuangJRQ;
                parameters[3].Value = model.mi_CaiDJB;
                parameters[4].Value = model.mi_CaiDFID;
                parameters[5].Value = model.mi_CaiDPX;
                parameters[6].Value = model.mi_Delete;
                parameters[7].Value = model.mi_NewType == null ? "" : model.mi_NewType;
                object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded|" + obj.ToString();
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
        public string Update(Model.MenuInfo model)
        {
            string result = "";
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update MenuInfo set ");
                strSql.Append("mi_CaiDMC=@mi_CaiDMC,");
                strSql.Append("mi_CaiDDZ=@mi_CaiDDZ,");
                strSql.Append("mi_ChuangJRQ=@mi_ChuangJRQ,");
                strSql.Append("mi_CaiDJB=@mi_CaiDJB,");
                strSql.Append("mi_CaiDFID=@mi_CaiDFID,");
                strSql.Append("mi_CaiDPX=@mi_CaiDPX,");
                strSql.Append("mi_Delete=@mi_Delete,");
                strSql.Append("mi_NewType=@mi_NewType");
                strSql.Append(" where mi_CaiDID=@mi_CaiDID");
                SqlParameter[] parameters = {
					new SqlParameter("@mi_CaiDMC", SqlDbType.NVarChar,50),
					new SqlParameter("@mi_CaiDDZ", SqlDbType.NVarChar,50),
					new SqlParameter("@mi_ChuangJRQ", SqlDbType.DateTime),
					new SqlParameter("@mi_CaiDJB", SqlDbType.Int,4),
					new SqlParameter("@mi_CaiDFID", SqlDbType.Int,4),
					new SqlParameter("@mi_CaiDPX", SqlDbType.Int,4),
					new SqlParameter("@mi_Delete", SqlDbType.Int,4),
                    new SqlParameter("@mi_NewType", SqlDbType.NVarChar,50),
					new SqlParameter("@mi_CaiDID", SqlDbType.Int,4)};
                parameters[0].Value = model.mi_CaiDMC;
                parameters[1].Value = model.mi_CaiDDZ;
                parameters[2].Value = model.mi_ChuangJRQ;
                parameters[3].Value = model.mi_CaiDJB;
                parameters[4].Value = model.mi_CaiDFID;
                parameters[5].Value = model.mi_CaiDPX;
                parameters[6].Value = model.mi_Delete;
                parameters[7].Value = model.mi_NewType;
                parameters[8].Value = model.mi_CaiDID;

                int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                result = "succeeded|" + model.mi_CaiDID;
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
        public bool Delete(int MenuID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  MenuInfo set mi_Delete=1 ");
            strSql.Append(" where mi_CaiDID=@mi_CaiDID");
            SqlParameter[] parameters = {
					new SqlParameter("@mi_CaiDID", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuID;

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
        public Model.MenuInfo GetModel(int MenuID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 mi_CaiDID,mi_CaiDMC,mi_CaiDDZ,mi_ChuangJRQ,mi_CaiDJB,mi_CaiDFID,mi_CaiDPX,mi_Delete,mi_NewType from MenuInfo ");
            strSql.Append(" where mi_CaiDID=@mi_CaiDID");
            SqlParameter[] parameters = {
					new SqlParameter("@mi_CaiDID", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuID;

            Model.MenuInfo model = new Model.MenuInfo();
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["mi_CaiDID"] != null && ds.Tables[0].Rows[0]["mi_CaiDID"].ToString() != "")
                {
                    model.mi_CaiDID = int.Parse(ds.Tables[0].Rows[0]["mi_CaiDID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mi_CaiDMC"] != null && ds.Tables[0].Rows[0]["mi_CaiDMC"].ToString() != "")
                {
                    model.mi_CaiDMC = ds.Tables[0].Rows[0]["mi_CaiDMC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["mi_CaiDDZ"] != null && ds.Tables[0].Rows[0]["mi_CaiDDZ"].ToString() != "")
                {
                    model.mi_CaiDDZ = ds.Tables[0].Rows[0]["mi_CaiDDZ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["mi_ChuangJRQ"] != null && ds.Tables[0].Rows[0]["mi_ChuangJRQ"].ToString() != "")
                {
                    model.mi_ChuangJRQ = DateTime.Parse(ds.Tables[0].Rows[0]["mi_ChuangJRQ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mi_CaiDJB"] != null && ds.Tables[0].Rows[0]["mi_CaiDJB"].ToString() != "")
                {
                    model.mi_CaiDJB = int.Parse(ds.Tables[0].Rows[0]["mi_CaiDJB"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mi_CaiDFID"] != null && ds.Tables[0].Rows[0]["mi_CaiDFID"].ToString() != "")
                {
                    model.mi_CaiDFID = int.Parse(ds.Tables[0].Rows[0]["mi_CaiDFID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mi_CaiDPX"] != null && ds.Tables[0].Rows[0]["mi_CaiDPX"].ToString() != "")
                {
                    model.mi_CaiDPX = int.Parse(ds.Tables[0].Rows[0]["mi_CaiDPX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mi_Delete"] != null && ds.Tables[0].Rows[0]["mi_Delete"].ToString() != "")
                {
                    model.mi_Delete = int.Parse(ds.Tables[0].Rows[0]["mi_Delete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mi_NewType"] != null && ds.Tables[0].Rows[0]["mi_NewType"].ToString() != "")
                {
                    model.mi_NewType = ds.Tables[0].Rows[0]["mi_NewType"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Method

        #region  ExtensionMethod
        /// <summary>
        /// 获取菜单名称
        /// </summary>
        /// <param name="id">菜单id</param>
        public string GetName(int id)
        {
            string names = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 mi_CaiDID,mi_CaiDMC,mi_CaiDDZ,mi_ChuangJRQ,mi_CaiDJB,mi_CaiDFID,mi_CaiDPX,mi_Delete,mi_NewType from MenuInfo ");
            strSql.AppendFormat(" where mi_CaiDID={0}", id);
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                names = ds.Tables[0].Rows[0]["mi_CaiDMC"].ToString();
            }
            return names;
        }

        /// <summary>
        /// 根据查询条件获取菜单
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="Top"></param>
        /// <returns></returns>
        public DataTable GetDataBySql(string strWhere, string Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + Top + " mi_CaiDID,mi_CaiDMC,mi_CaiDDZ,mi_ChuangJRQ,mi_CaiDJB,mi_CaiDFID,mi_CaiDPX,mi_Delete,mi_NewType  ");
            strSql.Append("  from MenuInfo ");
            strSql.Append(" where 1=1 ");
            if (strWhere.Trim() != "")
                strSql.Append(strWhere);
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            if (dt.Rows.Count <= 0)
                return null;

            return dt;
        }
        #endregion  ExtensionMethod
    }
}

