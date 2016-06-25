using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using DBUtility;

namespace DAL
{
    public class RecoverInfo
    {

        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int sr_HuiSID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RecoverInfo");
            strSql.Append(" where ");
            strSql.Append(" sr_HuiSID = @sr_HuiSID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@sr_HuiSID", SqlDbType.Int,4)
			};
            parameters[0].Value = sr_HuiSID;
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
        public string Add(Model.RecoverInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RecoverInfo(");
            strSql.Append("sr_XinXBT,sr_XinXNR,pt_YongHID,sr_FaBRQ,sr_Deleted,sr_LianXDZ,sr_LianXDH,sr_LianXR");
            strSql.Append(") values (");
            strSql.Append("@sr_XinXBT,@sr_XinXNR,@pt_YongHID,@sr_FaBRQ,@sr_Deleted,@sr_LianXDZ,@sr_LianXDH,@sr_LianXR");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@sr_XinXBT", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_XinXNR", SqlDbType.NVarChar) ,            
                        new SqlParameter("@pt_YongHID", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_FaBRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@sr_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_LianXDZ", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_LianXDH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sr_LianXR", SqlDbType.NVarChar,50)             
              
            };
            parameters[0].Value = model.sr_XinXBT;
            parameters[1].Value = model.sr_XinXNR;
            parameters[2].Value = model.pt_YongHID;
            parameters[3].Value = model.sr_FaBRQ;
            parameters[4].Value = model.sr_Deleted;
            parameters[5].Value = model.sr_LianXDZ;
            parameters[6].Value = model.sr_LianXDH;
            parameters[7].Value = model.sr_LianXR; string result = "";
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
        public string Update(Model.RecoverInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RecoverInfo set ");
            strSql.Append(" sr_XinXBT = @sr_XinXBT , ");
            strSql.Append(" sr_XinXNR = @sr_XinXNR , ");
            strSql.Append(" sr_LianXDZ = @sr_LianXDZ , ");
            strSql.Append(" sr_LianXDH = @sr_LianXDH , ");
            strSql.Append(" sr_LianXR = @sr_LianXR  ");
            strSql.Append(" where sr_HuiSID=@sr_HuiSID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@sr_HuiSID", SqlDbType.Int,4) ,            
                        new SqlParameter("@sr_XinXBT", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_XinXNR", SqlDbType.NVarChar) ,                      
                        new SqlParameter("@sr_LianXDZ", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@sr_LianXDH", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@sr_LianXR", SqlDbType.NVarChar,50)             
            };
            parameters[0].Value = model.sr_HuiSID;
            parameters[1].Value = model.sr_XinXBT;
            parameters[2].Value = model.sr_XinXNR;
            parameters[3].Value = model.sr_LianXDZ;
            parameters[4].Value = model.sr_LianXDH;
            parameters[5].Value = model.sr_LianXR;
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
        public string Delete(int sr_HuiSID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RecoverInfo set");
            strSql.Append(" sr_Deleted=1  where sr_HuiSID=@sr_HuiSID");
            SqlParameter[] parameters = {
					new SqlParameter("@sr_HuiSID", SqlDbType.Int,4)
			};
            parameters[0].Value = sr_HuiSID;
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
        public Model.RecoverInfo GetModel(int sr_HuiSID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sr_HuiSID, sr_XinXBT, sr_XinXNR, pt_YongHID, sr_FaBRQ, sr_Deleted, sr_LianXDZ, sr_LianXDH, sr_LianXR  ");
            strSql.Append("  from RecoverInfo ");
            strSql.Append(" where sr_HuiSID=@sr_HuiSID");
            SqlParameter[] parameters = {
					new SqlParameter("@sr_HuiSID", SqlDbType.Int,4)
			};
            parameters[0].Value = sr_HuiSID;
            Model.RecoverInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.RecoverInfo();
                model.sr_HuiSID = int.Parse(dt.Rows[0]["sr_HuiSID"].ToString());
                model.sr_XinXBT = dt.Rows[0]["sr_XinXBT"].ToString();
                model.sr_XinXNR = dt.Rows[0]["sr_XinXNR"].ToString();
                model.pt_YongHID = int.Parse(dt.Rows[0]["pt_YongHID"].ToString());
                model.sr_FaBRQ = DateTime.Parse(dt.Rows[0]["sr_FaBRQ"].ToString());
                model.sr_Deleted = int.Parse(dt.Rows[0]["sr_Deleted"].ToString());
                model.sr_LianXDZ = dt.Rows[0]["sr_LianXDZ"].ToString();
                model.sr_LianXDH = dt.Rows[0]["sr_LianXDH"].ToString();
                model.sr_LianXR = dt.Rows[0]["sr_LianXR"].ToString();
            }
            return model;
        }


        /// <summary>
        /// 获取回收信息列表
        /// </summary>
        /// <param name="sr_HuiSID"></param>
        /// <returns></returns>
        public DataTable GetRecoverInfo(int sr_HuiSID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from vw_RecoverInfo  ");
            strSql.Append(" where sr_HuiSID=@sr_HuiSID");
            SqlParameter[] parameters = {
					new SqlParameter("@sr_HuiSID", SqlDbType.Int,4)
			};
            parameters[0].Value = sr_HuiSID;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            return dt;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetRecoverList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  top 15 * ");
            strSql.Append(" FROM vw_RecoverInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sr_FaBRQ desc ");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            return dt;
        }
    }
}
