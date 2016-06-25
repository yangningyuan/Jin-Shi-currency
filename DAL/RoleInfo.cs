using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:RoleInfo
	/// </summary>
	public partial class RoleInfo
	{
		public RoleInfo()
		{}
		#region  Method
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(Model.RoleInfo model)
		{
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into RoleInfo(");
                strSql.Append("ri_JueSMC,ri_deleted,ri_JueSBZ)");
                strSql.Append(" values (");
                strSql.Append("@ri_JueSMC,@ri_deleted,@ri_JueSBZ)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@ri_JueSMC", SqlDbType.NVarChar,50),
					new SqlParameter("@ri_deleted", SqlDbType.Int,4),
					new SqlParameter("@ri_JueSBZ", SqlDbType.NVarChar)};
                parameters[0].Value = model.ri_JueSMC;
                parameters[1].Value = model.ri_deleted;
                parameters[2].Value = model.ri_JueSBZ;

                object id = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);
                return "succeeded|" + id.ToString();
            }
            catch (Exception e)
            {
                return "error|"+e.Message;
            }
            
			
		}
        
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public string Update(Model.RoleInfo model)
		{
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update RoleInfo set ");
                strSql.Append("ri_JueSMC=@ri_JueSMC,");
                strSql.Append("ri_deleted=@ri_deleted,");
                strSql.Append("ri_JueSBZ=@ri_JueSBZ");
                strSql.Append(" where ri_JueSID=@ri_JueSID");
                SqlParameter[] parameters = {
					new SqlParameter("@ri_JueSMC", SqlDbType.NVarChar,50),
					new SqlParameter("@ri_deleted", SqlDbType.Int,4),
					new SqlParameter("@ri_JueSBZ", SqlDbType.NVarChar),
					new SqlParameter("@ri_JueSID", SqlDbType.Int,4)};
                parameters[0].Value = model.ri_JueSMC;
                parameters[1].Value = model.ri_deleted;
                parameters[2].Value = model.ri_JueSBZ;
                parameters[3].Value = model.ri_JueSID;

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, strSql.ToString(), parameters);

                return "succeeded|" + model.ri_JueSID;
            }
            catch (Exception e)
            {
                return "error|"+e.Message;
            }
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RoleID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update  RoleInfo set ri_deleted=1 ");
            strSql.Append(" where ri_JueSID=@ri_JueSID");
			SqlParameter[] parameters = {
					new SqlParameter("@ri_JueSID", SqlDbType.Int,4)
			};
			parameters[0].Value = RoleID;

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
       public Model.RoleInfo GetModel(int RoleID)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 ri_JueSID,ri_JueSMC,ri_deleted,ri_JueSBZ from RoleInfo ");
           strSql.Append(" where ri_JueSID=@ri_JueSID");
           SqlParameter[] parameters = {
					new SqlParameter("@ri_JueSID", SqlDbType.Int,4)
			};
           parameters[0].Value = RoleID;

           Model.RoleInfo model = new Model.RoleInfo();
           DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringMembership,CommandType.Text,strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["ri_JueSID"] != null && ds.Tables[0].Rows[0]["ri_JueSID"].ToString() != "")
               {
                   model.ri_JueSID = int.Parse(ds.Tables[0].Rows[0]["ri_JueSID"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ri_JueSMC"] != null && ds.Tables[0].Rows[0]["ri_JueSMC"].ToString() != "")
               {
                   model.ri_JueSMC = ds.Tables[0].Rows[0]["ri_JueSMC"].ToString();
               }
               if (ds.Tables[0].Rows[0]["ri_deleted"] != null && ds.Tables[0].Rows[0]["ri_deleted"].ToString() != "")
               {
                   model.ri_deleted = int.Parse(ds.Tables[0].Rows[0]["ri_deleted"].ToString());
               }
               if (ds.Tables[0].Rows[0]["ri_JueSBZ"] != null && ds.Tables[0].Rows[0]["ri_JueSBZ"].ToString() != "")
               {
                   model.ri_JueSBZ = ds.Tables[0].Rows[0]["ri_JueSBZ"].ToString();
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

