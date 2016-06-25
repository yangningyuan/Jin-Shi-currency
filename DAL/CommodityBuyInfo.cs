using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
    /// <summary>
    /// 数据访问类:CommodityBuyInfo
    /// </summary>
    public partial class CommodityBuyInfo
    {
        public CommodityBuyInfo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int cb_ShangPID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CommodityBuyInfo");
            strSql.Append(" where cb_ShangPID=@cb_ShangPID");
            SqlParameter[] parameters = {
					new SqlParameter("@cb_ShangPID", SqlDbType.Int,4)
			};
            parameters[0].Value = cb_ShangPID;

            object o = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (Convert.ToInt32(o) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_Collect(int cb_ShangPID, int pt_YongHID)
        {
            bool ReturnValue = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CommodityBuyInfo");
            strSql.Append(" where cb_ShangPID=@cb_ShangPID and pt_YongHID=@pt_YongHID");
            SqlParameter[] parameters = {
					new SqlParameter("@cb_ShangPID", SqlDbType.Int,4),
                    new SqlParameter("@pt_YongHID",SqlDbType.Int,4)
			};
            parameters[0].Value = cb_ShangPID;
            parameters[0].Value = pt_YongHID;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                ReturnValue = true;
            }
            return ReturnValue;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.CommodityBuyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CommodityBuyInfo(");
            strSql.Append("pt_YongHID,cb_FenLCode,cb_ShangPMC,cb_QiuGJG,cb_ShangPJJ,cb_ShangPBZ,cb_Enabled,cb_Deleted,cb_FaBRQ,cb_LianXDZ,cb_QuYCode,cb_ShangPTP,cb_LianXR,cb_LianXDH)");
            strSql.Append(" values (");
            strSql.Append("@pt_YongHID,@cb_FenLCode,@cb_ShangPMC,@cb_QiuGJG,@cb_ShangPJJ,@cb_ShangPBZ,@cb_Enabled,@cb_Deleted,@cb_FaBRQ,@cb_LianXDZ,@cb_QuYCode,@cb_ShangPTP,@cb_LianXR,@cb_LianXDH)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4),
					new SqlParameter("@cb_FenLCode", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_ShangPMC", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_QiuGJG", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_ShangPJJ", SqlDbType.NVarChar),
					new SqlParameter("@cb_ShangPBZ", SqlDbType.NVarChar),
					new SqlParameter("@cb_Enabled", SqlDbType.Int,4),
					new SqlParameter("@cb_Deleted", SqlDbType.Int,4),
					new SqlParameter("@cb_FaBRQ", SqlDbType.DateTime),
					new SqlParameter("@cb_LianXDZ", SqlDbType.NVarChar,500),
					new SqlParameter("@cb_QuYCode", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_ShangPTP", SqlDbType.NVarChar,500),
					new SqlParameter("@cb_LianXR", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_LianXDH", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.pt_YongHID;
            parameters[1].Value = model.cb_FenLCode;
            parameters[2].Value = model.cb_ShangPMC;
            parameters[3].Value = model.cb_QiuGJG;
            parameters[4].Value = model.cb_ShangPJJ;
            parameters[5].Value = model.cb_ShangPBZ;
            parameters[6].Value = model.cb_Enabled;
            parameters[7].Value = model.cb_Deleted;
            parameters[8].Value = model.cb_FaBRQ;
            parameters[9].Value = model.cb_LianXDZ;
            parameters[10].Value = model.cb_QuYCode;
            parameters[11].Value = model.cb_ShangPTP;
            parameters[12].Value = model.cb_LianXR;
            parameters[13].Value = model.cb_LianXDH;

            try
            {
                object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                return "succeeded|" + Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return "error";
                throw;
            }

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model.CommodityBuyInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommodityBuyInfo set ");
            strSql.Append("pt_YongHID=@pt_YongHID,");
            strSql.Append("cb_FenLCode=@cb_FenLCode,");
            strSql.Append("cb_ShangPMC=@cb_ShangPMC,");
            strSql.Append("cb_QiuGJG=@cb_QiuGJG,");
            strSql.Append("cb_ShangPJJ=@cb_ShangPJJ,");
            strSql.Append("cb_ShangPBZ=@cb_ShangPBZ,");
            strSql.Append("cb_FaBRQ=@cb_FaBRQ,");
            strSql.Append("cb_LianXDZ=@cb_LianXDZ,");
            strSql.Append("cb_QuYCode=@cb_QuYCode,");
            strSql.Append("cb_ShangPTP=@cb_ShangPTP,");
            strSql.Append("cb_LianXR=@cb_LianXR,");
            strSql.Append("cb_LianXDH=@cb_LianXDH");
            strSql.Append(" where cb_ShangPID=@cb_ShangPID");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4),
					new SqlParameter("@cb_FenLCode", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_ShangPMC", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_QiuGJG", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_ShangPJJ", SqlDbType.NVarChar),
					new SqlParameter("@cb_ShangPBZ", SqlDbType.NVarChar),
					new SqlParameter("@cb_FaBRQ", SqlDbType.DateTime),
					new SqlParameter("@cb_LianXDZ", SqlDbType.NVarChar,500),
					new SqlParameter("@cb_QuYCode", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_ShangPTP", SqlDbType.NVarChar,500),
					new SqlParameter("@cb_LianXR", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_LianXDH", SqlDbType.NVarChar,50),
					new SqlParameter("@cb_ShangPID", SqlDbType.Int,4)};
            parameters[0].Value = model.pt_YongHID;
            parameters[1].Value = model.cb_FenLCode;
            parameters[2].Value = model.cb_ShangPMC;
            parameters[3].Value = model.cb_QiuGJG;
            parameters[4].Value = model.cb_ShangPJJ;
            parameters[5].Value = model.cb_ShangPBZ;
            parameters[6].Value = model.cb_FaBRQ;
            parameters[7].Value = model.cb_LianXDZ;
            parameters[8].Value = model.cb_QuYCode;
            parameters[9].Value = model.cb_ShangPTP;
            parameters[10].Value = model.cb_LianXR;
            parameters[11].Value = model.cb_LianXDH;
            parameters[12].Value = model.cb_ShangPID;

            try
            {
                object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                return "succeeded|" + model.cb_ShangPID;
            }
            catch (Exception)
            {
                return "error";
                throw;
            }
        }

        /// <summary>
        /// 修改流量数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Update_cs_LiuLS(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommodityBuyInfo set ");
            strSql.Append("cb_LiuLS=cb_LiuLS+1 ");
            strSql.Append(" where cb_ShangPID=@cb_ShangPID");
            SqlParameter[] parameters = {
					new SqlParameter("@cb_ShangPID", SqlDbType.Int,4)};
            parameters[0].Value = id;
            try
            {
                object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                return "succeeded|" + id;
            }
            catch (Exception)
            {
                return "error";
                throw;
            }
        }

        /// <summary>
        /// 修改留言数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Update_cs_LiuYS(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommodityBuyInfo set ");
            strSql.Append("cb_LiuYS=cb_LiuYS+1 ");
            strSql.Append(" where cb_ShangPID=@cb_ShangPID");
            SqlParameter[] parameters = {
					new SqlParameter("@cb_ShangPID", SqlDbType.Int,4)};
            parameters[0].Value = id;
            try
            {
                object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                return "succeeded|" + id;
            }
            catch (Exception)
            {
                return "error";
                throw;
            }
        }

        /// <summary>
        /// 禁用记录
        /// </summary>
        public bool Update_Enable(int cb_ShangPID, int isEnable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommodityBuyInfo set cb_Enabled=@cb_Enabled ");
            strSql.Append(" where cb_ShangPID=@cb_ShangPID");
            SqlParameter[] parameters = {
					new SqlParameter("@cb_ShangPID", SqlDbType.Int,4),
					new SqlParameter("@cb_Enabled", SqlDbType.Int,4)
			};
            parameters[0].Value = cb_ShangPID;
            parameters[1].Value = isEnable;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int cb_ShangPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommodityBuyInfo set cb_Deleted=1 ");
            strSql.Append(" where cb_ShangPID=@cb_ShangPID");
            SqlParameter[] parameters = {
					new SqlParameter("@cb_ShangPID", SqlDbType.Int,4)
			};
            parameters[0].Value = cb_ShangPID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string cb_ShangPIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CommodityBuyInfo ");
            strSql.Append(" where cb_ShangPID in (" + cb_ShangPIDlist + ")  ");
            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString());
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
        public Model.CommodityBuyInfo GetModel(int cb_ShangPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 cb_ShangPID,pt_YongHID,cb_FenLCode,cb_ShangPMC,cb_QiuGJG,cb_ShangPJJ,cb_ShangPBZ,cb_Enabled,cb_Deleted,cb_FaBRQ,cb_LianXDZ,cb_QuYCode,cb_ShangPTP,cb_LianXR,cb_LianXDH from CommodityBuyInfo ");
            strSql.Append(" where cb_ShangPID=@cb_ShangPID");
            SqlParameter[] parameters = {
					new SqlParameter("@cb_ShangPID", SqlDbType.Int,4)
			};
            parameters[0].Value = cb_ShangPID;

            Model.CommodityBuyInfo model = new Model.CommodityBuyInfo();
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["cb_ShangPID"] != null && ds.Tables[0].Rows[0]["cb_ShangPID"].ToString() != "")
                {
                    model.cb_ShangPID = int.Parse(ds.Tables[0].Rows[0]["cb_ShangPID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pt_YongHID"] != null && ds.Tables[0].Rows[0]["pt_YongHID"].ToString() != "")
                {
                    model.pt_YongHID = int.Parse(ds.Tables[0].Rows[0]["pt_YongHID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cb_FenLCode"] != null && ds.Tables[0].Rows[0]["cb_FenLCode"].ToString() != "")
                {
                    model.cb_FenLCode = ds.Tables[0].Rows[0]["cb_FenLCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_ShangPMC"] != null && ds.Tables[0].Rows[0]["cb_ShangPMC"].ToString() != "")
                {
                    model.cb_ShangPMC = ds.Tables[0].Rows[0]["cb_ShangPMC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_QiuGJG"] != null && ds.Tables[0].Rows[0]["cb_QiuGJG"].ToString() != "")
                {
                    model.cb_QiuGJG = ds.Tables[0].Rows[0]["cb_QiuGJG"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_ShangPJJ"] != null && ds.Tables[0].Rows[0]["cb_ShangPJJ"].ToString() != "")
                {
                    model.cb_ShangPJJ = ds.Tables[0].Rows[0]["cb_ShangPJJ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_ShangPBZ"] != null && ds.Tables[0].Rows[0]["cb_ShangPBZ"].ToString() != "")
                {
                    model.cb_ShangPBZ = ds.Tables[0].Rows[0]["cb_ShangPBZ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_Enabled"] != null && ds.Tables[0].Rows[0]["cb_Enabled"].ToString() != "")
                {
                    model.cb_Enabled = int.Parse(ds.Tables[0].Rows[0]["cb_Enabled"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cb_Deleted"] != null && ds.Tables[0].Rows[0]["cb_Deleted"].ToString() != "")
                {
                    model.cb_Deleted = int.Parse(ds.Tables[0].Rows[0]["cb_Deleted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cb_FaBRQ"] != null && ds.Tables[0].Rows[0]["cb_FaBRQ"].ToString() != "")
                {
                    model.cb_FaBRQ = DateTime.Parse(ds.Tables[0].Rows[0]["cb_FaBRQ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cb_LianXDZ"] != null && ds.Tables[0].Rows[0]["cb_LianXDZ"].ToString() != "")
                {
                    model.cb_LianXDZ = ds.Tables[0].Rows[0]["cb_LianXDZ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_QuYCode"] != null && ds.Tables[0].Rows[0]["cb_QuYCode"].ToString() != "")
                {
                    model.cb_QuYCode = ds.Tables[0].Rows[0]["cb_QuYCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_ShangPTP"] != null && ds.Tables[0].Rows[0]["cb_ShangPTP"].ToString() != "")
                {
                    model.cb_ShangPTP = ds.Tables[0].Rows[0]["cb_ShangPTP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_LianXR"] != null && ds.Tables[0].Rows[0]["cb_LianXR"].ToString() != "")
                {
                    model.cb_LianXR = ds.Tables[0].Rows[0]["cb_LianXR"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cb_LianXDH"] != null && ds.Tables[0].Rows[0]["cb_LianXDH"].ToString() != "")
                {
                    model.cb_LianXDH = ds.Tables[0].Rows[0]["cb_LianXDH"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        #endregion  Method
    }
}

