using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace DAL
{
    public class PT_UserlInfo
    {
        /// <summary>
        /// 判断当前数据是否存在【和总的用户表匹配】
        /// </summary>
        public bool ExistsUserName(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Plat_UserlInfo");
            strSql.Append(" where ");
            strSql.Append(" pt_DengLMC = @pt_DengLMC  ");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = UserName;
            bool bl = true;
            try
            {
                object o = SqlHelper.ExecuteScalar(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
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
        /// 判断当前数据是否存在【和总的用户表匹配】
        /// </summary>
        public bool ExistsEmail(string Email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Plat_UserlInfo");
            strSql.Append(" where ");
            strSql.Append(" pt_YonghYX = @pt_YonghYX  ");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YonghYX", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = Email;
            bool bl = true;
            try
            {
                object o = SqlHelper.ExecuteScalar(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
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
        /// 判断当前数据是否存在【和总的用户表匹配】
        /// </summary>
        public bool Login_PlatForm(string UserName, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Plat_UserlInfo");
            strSql.Append(" where ");
            strSql.Append(" pt_DengLMC = @pt_DengLMC ");
            strSql.Append(" and pt_DengLMM = @pt_DengLMM");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50),
					new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = UserName;
            parameters[1].Value = Password;
            bool bl = true;
            try
            {
                object o = SqlHelper.ExecuteScalar(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
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
        /// 判断当前数据是否存在【和本系统用户表匹配】
        /// </summary>
        public bool Login(string UserName, string Password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PT_UserlInfo");
            strSql.Append(" where ");
            strSql.Append(" pt_DengLMC = @pt_DengLMC ");
            strSql.Append(" and pt_DengLMM = @pt_DengLMM");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50),
					new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = UserName;
            parameters[1].Value = Password;
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
        public string Add(Model.PT_UserlInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PT_UserlInfo(");
            strSql.Append("pt_TongXDZ,pt_LianXR,pt_YongHLX,pt_DengLMC,pt_DengLMM,pt_ZhuCSJ,pt_Enabled,pt_Deleted,pt_YonghMC,pt_YonghYX,pt_YiDDH");
            strSql.Append(") values (");
            strSql.Append("@pt_TongXDZ,@pt_LianXR,@pt_YongHLX,@pt_DengLMC,@pt_DengLMM,@pt_ZhuCSJ,@pt_Enabled,@pt_Deleted,@pt_YonghMC,@pt_YonghYX,@pt_YiDDH");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@pt_TongXDZ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_LianXR", SqlDbType.NVarChar,1) ,            
                        new SqlParameter("@pt_YongHLX", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_ZhuCSJ", SqlDbType.DateTime) ,            
                        new SqlParameter("@pt_Enabled", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_YonghMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_YonghYX", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@pt_YiDDH", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.pt_TongXDZ;
            parameters[1].Value = model.pt_LianXR;
            parameters[2].Value = model.pt_YongHLX;
            parameters[3].Value = model.pt_DengLMC;
            parameters[4].Value = model.pt_DengLMM;
            parameters[5].Value = model.pt_ZhuCSJ;
            parameters[6].Value = model.pt_Enabled;
            parameters[7].Value = model.pt_Deleted;
            parameters[8].Value = model.pt_YonghMC;
            parameters[9].Value = model.pt_YonghYX;
            parameters[10].Value = model.pt_YiDDH; string result = "";
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
        /// 注册帐号【本地和总库同时添加】
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Register(Model.PT_UserlInfo model)
        {
            //先存总表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Plat_UserlInfo(");
            strSql.Append("pt_DengLMC,pt_DengLMM,pt_ZhuCSJ,pt_Enabled,pt_Deleted,pt_ZCBZ,pt_YonghYX");
            strSql.Append(") values (");
            strSql.Append("@pt_DengLMC,@pt_DengLMM,@pt_ZhuCSJ,@pt_Enabled,@pt_Deleted,@pt_ZCBZ,@pt_YonghYX");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_ZhuCSJ", SqlDbType.DateTime) ,            
                        new SqlParameter("@pt_Enabled", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_Deleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_ZCBZ", SqlDbType.NVarChar,50),          
                        new SqlParameter("@pt_YonghYX", SqlDbType.NVarChar,50)             
              
            };
            parameters[0].Value = model.pt_DengLMC;
            parameters[1].Value = model.pt_DengLMM;
            parameters[2].Value = model.pt_ZhuCSJ;
            parameters[3].Value = model.pt_Enabled;
            parameters[4].Value = model.pt_Deleted;
            parameters[5].Value = "1";
            parameters[6].Value = model.pt_YonghYX;


            //再存分表
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into PT_UserlInfo(");
            strSql2.Append("pt_DengLMC,pt_DengLMM,pt_ZhuCSJ,pt_Enabled,pt_Deleted,pt_YonghYX");
            strSql2.Append(") values (");
            strSql2.Append("@pt_DengLMC,@pt_DengLMM,@pt_ZhuCSJ,@pt_Enabled,@pt_Deleted,@pt_YonghYX");
            strSql2.Append(") ");
            strSql2.Append(";select @@IDENTITY");
            SqlParameter[] parameters2 = {
			            new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_ZhuCSJ", SqlDbType.DateTime) ,            
                        new SqlParameter("@pt_Enabled", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_Deleted", SqlDbType.Int,4),          
                        new SqlParameter("@pt_YonghYX", SqlDbType.NVarChar,50)             
              
            };
            parameters2[0].Value = model.pt_DengLMC;
            parameters2[1].Value = model.pt_DengLMM;
            parameters2[2].Value = model.pt_ZhuCSJ;
            parameters2[3].Value = model.pt_Enabled;
            parameters2[4].Value = model.pt_Deleted;
            parameters2[5].Value = model.pt_YonghYX;

            string result = "";
            object zhuid = new object();
            try
            {
                 zhuid = SqlHelper.ExecuteScalar(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
                 SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql2.ToString(), parameters2);

                result = "succeeded";
            }
            catch (Exception ex)
            {
                if (zhuid != null)
                {
                    Delete(Convert.ToInt16(zhuid.ToString()));
                }
                result = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// 更新一条数据[值更新本地的库]
        /// </summary>
        public string Update(Model.PT_UserlInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PT_UserlInfo set ");
            strSql.Append(" pt_TongXDZ = @pt_TongXDZ , ");
            strSql.Append(" pt_LianXR = @pt_LianXR , ");
            strSql.Append(" pt_YongHLX = @pt_YongHLX , ");
            strSql.Append(" pt_DengLMC = @pt_DengLMC , ");
            strSql.Append(" pt_YonghMC = @pt_YonghMC , ");
            strSql.Append(" pt_YonghYX = @pt_YonghYX , ");
            strSql.Append(" pt_YiDDH = @pt_YiDDH  ");
            strSql.Append(" where pt_YongHID=@pt_YongHID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@pt_YongHID", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_TongXDZ", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_LianXR", SqlDbType.NVarChar,1) ,            
                        new SqlParameter("@pt_YongHLX", SqlDbType.Int,4) ,            
                        new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50) ,          
                        new SqlParameter("@pt_YonghMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_YonghYX", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@pt_YiDDH", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.pt_YongHID;
            parameters[1].Value = model.pt_TongXDZ;
            parameters[2].Value = model.pt_LianXR;
            parameters[3].Value = model.pt_YongHLX;
            parameters[4].Value = model.pt_DengLMC;
            parameters[5].Value = model.pt_YonghMC;
            parameters[6].Value = model.pt_YonghYX;
            parameters[7].Value = model.pt_YiDDH;
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
        /// 修改密码
        /// </summary>
        /// <param name="usernname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Update_Password(string usernname, string password)
        {
            //本系统中的库
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PT_UserlInfo set ");
            strSql.Append(" pt_DengLMM = @pt_DengLMM  ");
            strSql.Append(" where pt_DengLMC=@pt_DengLMC ");
            SqlParameter[] parameters = {          
                        new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50)             
              
            };
            parameters[0].Value = usernname;
            parameters[1].Value = password;

            //总用户的库
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update Plat_UserlInfo set ");
            strSql2.Append(" pt_DengLMM = @pt_DengLMM  ");
            strSql2.Append(" where pt_DengLMC=@pt_DengLMC ");

            SqlParameter[] parameters2 = {          
                        new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@pt_DengLMM", SqlDbType.NVarChar,50)             
              
            };
            parameters2[0].Value = usernname;
            parameters2[1].Value = password;

            string result = "";
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);

                SqlHelper.ExecuteNonQuery(SqlHelper.Connection_PlatForm, CommandType.Text, strSql2.ToString(), parameters2);
                result = "succeeded";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// 删除一条数据【两个同时删除】
        /// </summary>
        public bool Delete(int pt_YongHID)
        {
            //删除本系统
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update PT_UserlInfo set");
            strSql2.Append(" pt_Deleted=1  where pt_YongHID=@pt_YongHID");
            SqlParameter[] parameters2 = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4)
			};
            parameters2[0].Value = pt_YongHID;

            int rows2 = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql2.ToString(), parameters2);

            //删除总的用户表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Plat_UserlInfo set");
            strSql.Append(" pt_Deleted=1  where pt_YongHID=@pt_YongHID");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4)
			};
            parameters[0].Value = pt_YongHID;


            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0 && rows2 > 0)
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
        public Model.PT_UserlInfo GetModel(int pt_YongHID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pt_YongHID, pt_TongXDZ, pt_LianXR, pt_YongHLX, pt_DengLMC, pt_DengLMM, pt_ZhuCSJ, pt_Enabled, pt_Deleted, pt_YonghMC, pt_YonghYX, pt_YiDDH  ");
            strSql.Append("  from PT_UserlInfo ");
            strSql.Append(" where pt_YongHID=@pt_YongHID");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_YongHID", SqlDbType.Int,4)
			};
            parameters[0].Value = pt_YongHID;


            Model.PT_UserlInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model = new Model.PT_UserlInfo();
                model.pt_YongHID = int.Parse(dt.Rows[0]["pt_YongHID"].ToString());
                model.pt_TongXDZ = dt.Rows[0]["pt_TongXDZ"].ToString();
                model.pt_LianXR = dt.Rows[0]["pt_LianXR"].ToString();
                model.pt_YongHLX = int.Parse(dt.Rows[0]["pt_YongHLX"].ToString());
                model.pt_DengLMC = dt.Rows[0]["pt_DengLMC"].ToString();
                model.pt_DengLMM = dt.Rows[0]["pt_DengLMM"].ToString();
                model.pt_ZhuCSJ = DateTime.Parse(dt.Rows[0]["pt_ZhuCSJ"].ToString());
                model.pt_Enabled = int.Parse(dt.Rows[0]["pt_Enabled"].ToString());
                model.pt_Deleted = int.Parse(dt.Rows[0]["pt_Deleted"].ToString());
                model.pt_YonghMC = dt.Rows[0]["pt_YonghMC"].ToString();
                model.pt_YonghYX = dt.Rows[0]["pt_YonghYX"].ToString();
                model.pt_YiDDH = dt.Rows[0]["pt_YiDDH"].ToString();

            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.PT_UserlInfo GetModel(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pt_YongHID, pt_TongXDZ, pt_LianXR, pt_YongHLX, pt_DengLMC, pt_DengLMM, pt_ZhuCSJ, pt_Enabled, pt_Deleted, pt_YonghMC, pt_YonghYX, pt_YiDDH  ");
            strSql.Append("  from PT_UserlInfo ");
            strSql.Append(" where pt_DengLMC=@pt_DengLMC ");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = username;


            Model.PT_UserlInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);

            if (dt.Rows.Count > 0)
            {
                model = new Model.PT_UserlInfo();
                model.pt_YongHID = int.Parse(dt.Rows[0]["pt_YongHID"].ToString());
                model.pt_TongXDZ = dt.Rows[0]["pt_TongXDZ"].ToString();
                model.pt_LianXR = dt.Rows[0]["pt_LianXR"].ToString();
                model.pt_YongHLX = int.Parse(dt.Rows[0]["pt_YongHLX"].ToString());
                model.pt_DengLMC = dt.Rows[0]["pt_DengLMC"].ToString();
                model.pt_DengLMM = dt.Rows[0]["pt_DengLMM"].ToString();
                model.pt_ZhuCSJ = DateTime.Parse(dt.Rows[0]["pt_ZhuCSJ"].ToString());
                model.pt_Enabled = int.Parse(dt.Rows[0]["pt_Enabled"].ToString());
                model.pt_Deleted = int.Parse(dt.Rows[0]["pt_Deleted"].ToString());
                model.pt_YonghMC = dt.Rows[0]["pt_YonghMC"].ToString();
                model.pt_YonghYX = dt.Rows[0]["pt_YonghYX"].ToString();
                model.pt_YiDDH = dt.Rows[0]["pt_YiDDH"].ToString();

            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Plat_UserlInfo GetModel_PlatForm(string username)
        {
              StringBuilder strSql = new StringBuilder();
              strSql.Append("select pt_YongHID, pt_DengLMC, pt_DengLMM, pt_ZhuCSJ, pt_Enabled, pt_Deleted, pt_ZCBZ,pt_YonghYX  ");
            strSql.Append("  from Plat_UserlInfo ");
            strSql.Append(" where pt_DengLMC=@pt_DengLMC");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_DengLMC", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = username;
            Model.Plat_UserlInfo model = null;
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.Connection_PlatForm, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                model = new Model.Plat_UserlInfo();
                model.pt_YongHID = int.Parse(dt.Rows[0]["pt_YongHID"].ToString());
                model.pt_DengLMC = dt.Rows[0]["pt_DengLMC"].ToString();
                model.pt_DengLMM = dt.Rows[0]["pt_DengLMM"].ToString();
                model.pt_ZhuCSJ = DateTime.Parse(dt.Rows[0]["pt_ZhuCSJ"].ToString());
                model.pt_Enabled = int.Parse(dt.Rows[0]["pt_Enabled"].ToString());
                model.pt_Deleted = int.Parse(dt.Rows[0]["pt_Deleted"].ToString());
                model.pt_ZCBZ = dt.Rows[0]["pt_ZCBZ"].ToString();
                model.pt_YongHYX = dt.Rows[0]["pt_YonghYX"].ToString();
            }
            return model;
        
        }
    }
}
