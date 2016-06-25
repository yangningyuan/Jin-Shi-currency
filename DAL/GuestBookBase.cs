using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace DAL
{
    public class GuestBookBase
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.GuestBookBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GuestBookBase(");
            strSql.Append("gb_XingM,gb_DianH,gb_YouX,gb_LiuYNR,gb_LiuYRQ,gb_HuiFZT,gb_Delete,gb_Title");
            strSql.Append(") values (");
            strSql.Append("@gb_XingM,@gb_DianH,@gb_YouX,@gb_LiuYNR,@gb_LiuYRQ,@gb_HuiFZT,@gb_Delete,@gb_Title");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@gb_XingM", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@gb_DianH", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@gb_YouX", SqlDbType.VarChar,200) ,                  
                        new SqlParameter("@gb_LiuYNR", SqlDbType.NVarChar) ,            
                        new SqlParameter("@gb_LiuYRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@gb_HuiFZT", SqlDbType.Int,4) ,
                        new SqlParameter("@gb_Delete", SqlDbType.Int,4) ,
                        new SqlParameter("@gb_Title", SqlDbType.NVarChar,100)      
            };
            parameters[0].Value = model.gb_XingM;
            parameters[1].Value = model.gb_DianH;
            parameters[2].Value = model.gb_YouX;
            parameters[3].Value = model.gb_LiuYNR;
            parameters[4].Value = model.gb_LiuYRQ;
            parameters[5].Value = model.gb_HuiFZT;
            parameters[6].Value = model.gb_Delete;
            parameters[7].Value = model.gb_Title;
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
        public string Update(Model.GuestBookBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GuestBookBase set ");
            strSql.Append(" gb_HuiFZID = @gb_HuiFZID , ");
            strSql.Append(" gb_HuiFNR = @gb_HuiFNR , ");
            strSql.Append(" gb_HuiFRQ = @gb_HuiFRQ , ");
            strSql.Append(" gb_HuiFZT = @gb_HuiFZT  ");

            strSql.Append(" where gb_LiuYID=@gb_LiuYID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@gb_LiuYID", SqlDbType.Int,4) ,            
                        new SqlParameter("@gb_HuiFZID", SqlDbType.Int,4) ,            
                        new SqlParameter("@gb_HuiFNR", SqlDbType.NVarChar) ,                      
                        new SqlParameter("@gb_HuiFRQ", SqlDbType.DateTime) ,            
                        new SqlParameter("@gb_HuiFZT", SqlDbType.Int,4)            
            };
            parameters[0].Value = model.gb_LiuYID;
            parameters[1].Value = model.gb_HuiFZID;
            parameters[2].Value = model.gb_HuiFNR;
            parameters[3].Value = model.gb_HuiFRQ;
            parameters[4].Value = model.gb_HuiFZT;
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
        public string Delete(int gb_LiuYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GuestBookBase set");
            strSql.Append(" gb_Delete=1  where gb_LiuYID=@gb_LiuYID");
            SqlParameter[] parameters = {
					new SqlParameter("@gb_LiuYID", SqlDbType.Int,4)
			};
            parameters[0].Value = gb_LiuYID;
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
        public Model.GuestBookBase GetModel(int gb_LiuYID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select gb_LiuYID,gb_XingM,gb_DianH,gb_YouX,gb_DiZ,gb_LiuYNR,gb_LiuYRQ,gb_HuiFZID,gb_HuiFNR,gb_HuiFRQ,gb_HuiFZT,gb_Delete,gb_Title ");
            strSql.Append("  from GuestBookBase ");
            strSql.Append(" where gb_LiuYID=@gb_LiuYID");
            SqlParameter[] parameters = {
					new SqlParameter("@gb_LiuYID", SqlDbType.Int,4)
			};
            parameters[0].Value = gb_LiuYID;
            Model.GuestBookBase model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.GuestBookBase();
                model.gb_LiuYID = int.Parse(dt.Rows[0]["gb_LiuYID"].ToString());
                model.gb_XingM = dt.Rows[0]["gb_XingM"].ToString();
                model.gb_DianH = dt.Rows[0]["gb_DianH"].ToString();
                model.gb_YouX = dt.Rows[0]["gb_YouX"].ToString();
                model.gb_DiZ = dt.Rows[0]["gb_DiZ"].ToString();
                model.gb_LiuYNR = dt.Rows[0]["gb_LiuYNR"].ToString();
                model.gb_LiuYRQ = DateTime.Parse(dt.Rows[0]["gb_LiuYRQ"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["gb_HuiFZID"].ToString()))
                { model.gb_HuiFZID = int.Parse(dt.Rows[0]["gb_HuiFZID"].ToString()); }
                model.gb_HuiFNR = dt.Rows[0]["gb_HuiFNR"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["gb_HuiFRQ"].ToString()))
                { model.gb_HuiFRQ = DateTime.Parse(dt.Rows[0]["gb_HuiFRQ"].ToString()); }
                model.gb_HuiFZT = int.Parse(dt.Rows[0]["gb_HuiFZT"].ToString());
                model.gb_Delete = int.Parse(dt.Rows[0]["gb_Delete"].ToString());
                model.gb_Title = dt.Rows[0]["gb_Title"].ToString();
            }
            return model;
        }
    }
}
