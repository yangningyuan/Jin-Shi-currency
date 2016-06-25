using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
namespace DAL
{
    /// <summary>
    /// 数据访问类:CommoditySellInfo
    /// </summary>
    public partial class CommoditySellInfo
    {
        public CommoditySellInfo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int cs_ZhuangRID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CommoditySellInfo");
            strSql.Append(" where cs_ZhuangRID=@cs_ZhuangRID");
            SqlParameter[] parameters = {
					new SqlParameter("@cs_ZhuangRID", SqlDbType.Int,4)
			};
            parameters[0].Value = cs_ZhuangRID;

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
        public string Add(Model.CommoditySellInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CommoditySellInfo(");
            strSql.Append("pt_YongHID,cs_FenLCode,cs_ShangPMC,cs_ZhuangRJG,cs_ShangPJJ,cs_ShangPBZ,cs_Enabled,cs_Deleted,cs_FaBRQ,cs_LianXDZ,cs_QuYCode,cs_ShangPTPLJ,cs_LianXR,cs_LianXDH,cs_XinJCD,cs_Rescommend,cs_LiuLS,cs_LiuYS)");
            strSql.Append(" values (");
            strSql.Append("@pt_YongHID,@cs_FenLCode,@cs_ShangPMC,@cs_ZhuangRJG,@cs_ShangPJJ,@cs_ShangPBZ,@cs_Enabled,@cs_Deleted,@cs_FaBRQ,@cs_LianXDZ,@cs_QuYCode,@cs_ShangPTPLJ,@cs_LianXR,@cs_LianXDH,@cs_XinJCD,@cs_Rescommend,@cs_LiuLS,@cs_LiuYS)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4),
					new SqlParameter("@cs_FenLCode", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ShangPMC", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ZhuangRJG", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ShangPJJ", SqlDbType.NVarChar),
					new SqlParameter("@cs_ShangPBZ", SqlDbType.NVarChar),
					new SqlParameter("@cs_Enabled", SqlDbType.Int,4),
					new SqlParameter("@cs_Deleted", SqlDbType.Int,4),
					new SqlParameter("@cs_FaBRQ", SqlDbType.DateTime),
					new SqlParameter("@cs_LianXDZ", SqlDbType.NVarChar,500),
					new SqlParameter("@cs_QuYCode", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ShangPTPLJ", SqlDbType.NVarChar,500),
					new SqlParameter("@cs_LianXR", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_LianXDH", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_XinJCD", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_Rescommend", SqlDbType.Int,4),
					new SqlParameter("@cs_LiuLS", SqlDbType.Int,4),
					new SqlParameter("@cs_LiuYS", SqlDbType.Int,4)};
            parameters[0].Value = model.pt_YongHID;
            parameters[1].Value = model.cs_FenLCode;
            parameters[2].Value = model.cs_ShangPMC;
            parameters[3].Value = model.cs_ZhuangRJG;
            parameters[4].Value = model.cs_ShangPJJ;
            parameters[5].Value = model.cs_ShangPBZ;
            parameters[6].Value = model.cs_Enabled;
            parameters[7].Value = model.cs_Deleted;
            parameters[8].Value = model.cs_FaBRQ;
            parameters[9].Value = model.cs_LianXDZ;
            parameters[10].Value = model.cs_QuYCode;
            parameters[11].Value = model.cs_ShangPTPLJ;
            parameters[12].Value = model.cs_LianXR;
            parameters[13].Value = model.cs_LianXDH;
            parameters[14].Value = model.cs_XinJCD;
            parameters[15].Value = model.cs_Rescommend;
            parameters[16].Value = model.cs_LiuLS;
            parameters[17].Value = model.cs_LiuYS;

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
        public string Update(Model.CommoditySellInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommoditySellInfo set ");
            strSql.Append("pt_YongHID=@pt_YongHID,");
            strSql.Append("cs_FenLCode=@cs_FenLCode,");
            strSql.Append("cs_ShangPMC=@cs_ShangPMC,");
            strSql.Append("cs_ZhuangRJG=@cs_ZhuangRJG,");
            strSql.Append("cs_ShangPJJ=@cs_ShangPJJ,");
            strSql.Append("cs_ShangPBZ=@cs_ShangPBZ,");
            strSql.Append("cs_FaBRQ=@cs_FaBRQ,");
            strSql.Append("cs_LianXDZ=@cs_LianXDZ,");
            strSql.Append("cs_QuYCode=@cs_QuYCode,");
            strSql.Append("cs_ShangPTPLJ=@cs_ShangPTPLJ,");
            strSql.Append("cs_LianXR=@cs_LianXR,");
            strSql.Append("cs_LianXDH=@cs_LianXDH,");
            strSql.Append("cs_XinJCD=@cs_XinJCD ");
            strSql.Append(" where cs_ZhuangRID=@cs_ZhuangRID");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4),
					new SqlParameter("@cs_FenLCode", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ShangPMC", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ZhuangRJG", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ShangPJJ", SqlDbType.NVarChar),
					new SqlParameter("@cs_ShangPBZ", SqlDbType.NVarChar),
					new SqlParameter("@cs_FaBRQ", SqlDbType.DateTime),
					new SqlParameter("@cs_LianXDZ", SqlDbType.NVarChar,500),
					new SqlParameter("@cs_QuYCode", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ShangPTPLJ", SqlDbType.NVarChar,500),
					new SqlParameter("@cs_LianXR", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_LianXDH", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_XinJCD", SqlDbType.NVarChar,50),
					new SqlParameter("@cs_ZhuangRID", SqlDbType.Int,4)};
            parameters[0].Value = model.pt_YongHID;
            parameters[1].Value = model.cs_FenLCode;
            parameters[2].Value = model.cs_ShangPMC;
            parameters[3].Value = model.cs_ZhuangRJG;
            parameters[4].Value = model.cs_ShangPJJ;
            parameters[5].Value = model.cs_ShangPBZ;
            parameters[6].Value = model.cs_FaBRQ;
            parameters[7].Value = model.cs_LianXDZ;
            parameters[8].Value = model.cs_QuYCode;
            parameters[9].Value = model.cs_ShangPTPLJ;
            parameters[10].Value = model.cs_LianXR;
            parameters[11].Value = model.cs_LianXDH;
            parameters[12].Value = model.cs_LianXDH;
            parameters[13].Value = model.cs_ZhuangRID;

            try
            {
                object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                return "succeeded|" + model.cs_ZhuangRID;
            }
            catch (Exception)
            {
                return "error";
                throw;
            }
        }

        public string Update_Enable(int id, int isEnable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommoditySellInfo set ");
            strSql.Append("cs_Enabled=@cs_Enabled");
            strSql.Append(" where cs_ZhuangRID=@cs_ZhuangRID");
            SqlParameter[] parameters = {
					
					new SqlParameter("@cs_Enabled", SqlDbType.Int,4),
					new SqlParameter("@cs_ZhuangRID", SqlDbType.Int,4)};
            parameters[0].Value = isEnable;
            parameters[1].Value = id;


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
        /// 修改流量数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Update_cs_LiuLS(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommoditySellInfo set ");
            strSql.Append("cs_LiuLS=cs_LiuLS+1 ");
            strSql.Append(" where cs_ZhuangRID=@cs_ZhuangRID");
            SqlParameter[] parameters = {
					new SqlParameter("@cs_ZhuangRID", SqlDbType.Int,4)};
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
            strSql.Append("update CommoditySellInfo set ");
            strSql.Append("cs_LiuYS=cs_LiuYS+1 ");
            strSql.Append(" where cs_ZhuangRID=@cs_ZhuangRID");
            SqlParameter[] parameters = {
					new SqlParameter("@cs_ZhuangRID", SqlDbType.Int,4)};
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int cs_ZhuangRID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommoditySellInfo set cs_Deleted=1 ");
            strSql.Append(" where cs_ZhuangRID=@cs_ZhuangRID");
            SqlParameter[] parameters = {
					new SqlParameter("@cs_ZhuangRID", SqlDbType.Int,4)
			};
            parameters[0].Value = cs_ZhuangRID;

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
        public bool DeleteList(string cs_ZhuangRIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CommoditySellInfo ");
            strSql.Append(" where cs_ZhuangRID in (" + cs_ZhuangRIDlist + ")  ");
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
        public Model.CommoditySellInfo GetModel(int cs_ZhuangRID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 cs_ZhuangRID,pt_YongHID,cs_FenLCode,cs_ShangPMC,cs_ZhuangRJG,cs_ShangPJJ,cs_ShangPBZ,cs_Enabled,cs_Deleted,cs_FaBRQ,cs_LianXDZ,cs_QuYCode,cs_ShangPTPLJ,cs_LianXR,cs_LianXDH,cs_XinJCD,cs_Rescommend,cs_LiuLS,cs_LiuYS  from CommoditySellInfo ");
            strSql.Append(" where cs_ZhuangRID=@cs_ZhuangRID");
            SqlParameter[] parameters = {
					new SqlParameter("@cs_ZhuangRID", SqlDbType.Int,4)
			};
            parameters[0].Value = cs_ZhuangRID;

            Model.CommoditySellInfo model = new Model.CommoditySellInfo();
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["cs_ZhuangRID"] != null && ds.Tables[0].Rows[0]["cs_ZhuangRID"].ToString() != "")
                {
                    model.cs_ZhuangRID = int.Parse(ds.Tables[0].Rows[0]["cs_ZhuangRID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pt_YongHID"] != null && ds.Tables[0].Rows[0]["pt_YongHID"].ToString() != "")
                {
                    model.pt_YongHID = int.Parse(ds.Tables[0].Rows[0]["pt_YongHID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cs_FenLCode"] != null && ds.Tables[0].Rows[0]["cs_FenLCode"].ToString() != "")
                {
                    model.cs_FenLCode = ds.Tables[0].Rows[0]["cs_FenLCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_ShangPMC"] != null && ds.Tables[0].Rows[0]["cs_ShangPMC"].ToString() != "")
                {
                    model.cs_ShangPMC = ds.Tables[0].Rows[0]["cs_ShangPMC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_ZhuangRJG"] != null && ds.Tables[0].Rows[0]["cs_ZhuangRJG"].ToString() != "")
                {
                    model.cs_ZhuangRJG = ds.Tables[0].Rows[0]["cs_ZhuangRJG"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_ShangPJJ"] != null && ds.Tables[0].Rows[0]["cs_ShangPJJ"].ToString() != "")
                {
                    model.cs_ShangPJJ = ds.Tables[0].Rows[0]["cs_ShangPJJ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_ShangPBZ"] != null && ds.Tables[0].Rows[0]["cs_ShangPBZ"].ToString() != "")
                {
                    model.cs_ShangPBZ = ds.Tables[0].Rows[0]["cs_ShangPBZ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_Enabled"] != null && ds.Tables[0].Rows[0]["cs_Enabled"].ToString() != "")
                {
                    model.cs_Enabled = int.Parse(ds.Tables[0].Rows[0]["cs_Enabled"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cs_Deleted"] != null && ds.Tables[0].Rows[0]["cs_Deleted"].ToString() != "")
                {
                    model.cs_Deleted = int.Parse(ds.Tables[0].Rows[0]["cs_Deleted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cs_FaBRQ"] != null && ds.Tables[0].Rows[0]["cs_FaBRQ"].ToString() != "")
                {
                    model.cs_FaBRQ = DateTime.Parse(ds.Tables[0].Rows[0]["cs_FaBRQ"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cs_LianXDZ"] != null && ds.Tables[0].Rows[0]["cs_LianXDZ"].ToString() != "")
                {
                    model.cs_LianXDZ = ds.Tables[0].Rows[0]["cs_LianXDZ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_QuYCode"] != null && ds.Tables[0].Rows[0]["cs_QuYCode"].ToString() != "")
                {
                    model.cs_QuYCode = ds.Tables[0].Rows[0]["cs_QuYCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_ShangPTPLJ"] != null && ds.Tables[0].Rows[0]["cs_ShangPTPLJ"].ToString() != "")
                {
                    model.cs_ShangPTPLJ = ds.Tables[0].Rows[0]["cs_ShangPTPLJ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_LianXR"] != null && ds.Tables[0].Rows[0]["cs_LianXR"].ToString() != "")
                {
                    model.cs_LianXR = ds.Tables[0].Rows[0]["cs_LianXR"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_LianXDH"] != null && ds.Tables[0].Rows[0]["cs_LianXDH"].ToString() != "")
                {
                    model.cs_LianXDH = ds.Tables[0].Rows[0]["cs_LianXDH"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_XinJCD"] != null && ds.Tables[0].Rows[0]["cs_XinJCD"].ToString() != "")
                {
                    model.cs_XinJCD = ds.Tables[0].Rows[0]["cs_XinJCD"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cs_Rescommend"] != null && ds.Tables[0].Rows[0]["cs_Rescommend"].ToString() != "")
                {
                    model.cs_Rescommend = int.Parse(ds.Tables[0].Rows[0]["cs_Rescommend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cs_LiuLS"] != null && ds.Tables[0].Rows[0]["cs_LiuLS"].ToString() != "")
                {
                    model.cs_LiuLS = int.Parse(ds.Tables[0].Rows[0]["cs_LiuLS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cs_LiuYS"] != null && ds.Tables[0].Rows[0]["cs_LiuYS"].ToString() != "")
                {
                    model.cs_LiuYS = int.Parse(ds.Tables[0].Rows[0]["cs_LiuYS"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cs_ZhuangRID,pt_YongHID,cs_FenLCode,cs_ShangPMC,cs_ZhuangRJG,cs_ShangPJJ,cs_ShangPBZ,cs_Enabled,cs_Deleted,cs_FaBRQ,cs_LianXDZ,cs_QuYCode,cs_ShangPTPLJ,cs_LianXR,cs_LianXDH,cs_XinJCD,cs_Rescommend,cs_LiuLS,cs_LiuYS ");
            strSql.Append(" FROM CommoditySellInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" cs_ZhuangRID,pt_YongHID,cs_FenLCode,cs_ShangPMC,cs_ZhuangRJG,cs_ShangPJJ,cs_ShangPBZ,cs_Enabled,cs_Deleted,cs_FaBRQ,cs_LianXDZ,cs_QuYCode,cs_ShangPTPLJ,cs_LianXR,cs_LianXDH,cs_XinJCD,cs_Rescommend,cs_LiuLS,cs_LiuYS ");
            strSql.Append(" FROM CommoditySellInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString());
        }

        #endregion  Method
    }
}

