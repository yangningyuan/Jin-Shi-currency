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
    public class CommodityCollectInfo
    {
        /// <summary>
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists(int cc_ShouCID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CommodityCollectInfo");
            strSql.Append(" where ");
            strSql.Append(" cc_ShouCID = @cc_ShouCID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@cc_ShouCID", SqlDbType.Int,4)
			};
            parameters[0].Value = cc_ShouCID;
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
        /// 判断当前数据是否存在
        /// </summary>
        public bool Exists_Collect(int cc_ShangPID, int cc_YongHID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CommodityCollectInfo");
            strSql.Append(" where ");
            strSql.Append(" cc_ShangPID = @cc_ShangPID  and cc_YongHID=@cc_YongHID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@cc_ShangPID", SqlDbType.Int,4),
                    new SqlParameter("@cc_YongHID",SqlDbType.Int,4)
			};
            parameters[0].Value = cc_ShangPID;
            parameters[1].Value = cc_YongHID;
            bool ReturnValue = false;
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
        public string Add(Model.CommodityCollectInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CommodityCollectInfo(");
            strSql.Append("cc_ShangPID,cc_YongHID,cc_ShouCRQ,cc_Deleted,cc_ShouCLX");
            strSql.Append(") values (");
            strSql.Append("@cc_ShangPID,@cc_YongHID,@cc_ShouCRQ,@cc_Deleted,@cc_ShouCLX");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@cc_ShangPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@cc_YongHID", SqlDbType.Int,4) ,            
                        new SqlParameter("@cc_ShouCRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@cc_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@cc_ShouCLX", SqlDbType.Int,4)             
              
            };
            parameters[0].Value = model.cc_ShangPID;
            parameters[1].Value = model.cc_YongHID;
            parameters[2].Value = model.cc_ShouCRQ;
            parameters[3].Value = model.cc_Deleted;
            parameters[4].Value = model.cc_ShouCLX; string result = "";
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
        public string Update(Model.CommodityCollectInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommodityCollectInfo set ");

            strSql.Append(" cc_ShangPID = @cc_ShangPID , ");
            strSql.Append(" cc_YongHID = @cc_YongHID , ");
            strSql.Append(" cc_ShouCRQ = @cc_ShouCRQ , ");
            strSql.Append(" cc_Deleted = @cc_Deleted , ");
            strSql.Append(" cc_ShouCLX = @cc_ShouCLX  ");
            strSql.Append(" where cc_ShouCID=@cc_ShouCID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@cc_ShouCID", SqlDbType.Int,4) ,            
                        new SqlParameter("@cc_ShangPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@cc_YongHID", SqlDbType.Int,4) ,            
                        new SqlParameter("@cc_ShouCRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@cc_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@cc_ShouCLX", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.cc_ShouCID;
            parameters[1].Value = model.cc_ShangPID;
            parameters[2].Value = model.cc_YongHID;
            parameters[3].Value = model.cc_ShouCRQ;
            parameters[4].Value = model.cc_Deleted;
            parameters[5].Value = model.cc_ShouCLX;
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
        public bool Delete(int cc_ShouCID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CommodityCollectInfo set");
            strSql.Append(" cc_Deleted=1  where cc_ShouCID=@cc_ShouCID");
            SqlParameter[] parameters = {
					new SqlParameter("@cc_ShouCID", SqlDbType.Int,4)
			};
            parameters[0].Value = cc_ShouCID;
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
        public Model.CommodityCollectInfo GetModel(int cc_ShouCID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cc_ShouCID, cc_ShangPID, cc_YongHID, cc_ShouCRQ, cc_Deleted, cc_ShouCLX  ");
            strSql.Append("  from CommodityCollectInfo ");
            strSql.Append(" where cc_ShouCID=@cc_ShouCID");
            SqlParameter[] parameters = {
					new SqlParameter("@cc_ShouCID", SqlDbType.Int,4)
			};
            parameters[0].Value = cc_ShouCID;
            Model.CommodityCollectInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.CommodityCollectInfo();
                model.cc_ShouCID = int.Parse(dt.Rows[0]["cc_ShouCID"].ToString());
                model.cc_ShangPID = int.Parse(dt.Rows[0]["cc_ShangPID"].ToString());
                model.cc_YongHID = int.Parse(dt.Rows[0]["cc_YongHID"].ToString());
                model.cc_ShouCRQ = DateTime.Parse(dt.Rows[0]["cc_ShouCRQ"].ToString());
                model.cc_Deleted = int.Parse(dt.Rows[0]["cc_Deleted"].ToString());
                model.cc_ShouCLX = int.Parse(dt.Rows[0]["cc_ShouCLX"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetCommodityList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  top 15 * ");
            strSql.Append(" FROM vw_Commodity_UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by cc_ShouCRQ desc ");
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            return dt;
        }

    }
}
