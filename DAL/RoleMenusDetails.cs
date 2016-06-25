using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Collections.Generic;

namespace DAL
{
	/// <summary>
	/// 数据访问类:CompetenceInfo
	/// </summary>
	public partial class RoleMenusDetails
	{
		public RoleMenusDetails()
		{}
		#region  Method
        /// <summary>
        /// 批量添加角色菜单
        /// </summary>
        /// <param name="list"></param>
        /// <param name="_roleid"></param>
        /// <returns></returns>
        public string Add(List<Model.RoleMenusDetails> list, int _roleid)
        {
            string result = "";
            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("Delete RoleMenusDetails Where ci_JueSID=@ci_JueSID ");
                    SqlParameter[] parameters = {
                    new SqlParameter("@ci_JueSID",SqlDbType.Int,4)
                                        };
                    parameters[0].Value = _roleid;

                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);

                    if (list.Count > 0)
                    {
                        foreach (Model.RoleMenusDetails _item in list)
                        {
                            StringBuilder strSql2 = new StringBuilder();
                            strSql2.Append("insert into RoleMenusDetails(");
                            strSql2.Append("ci_JueSID,ci_CaiDID)");
                            strSql2.Append(" values (");
                            strSql2.Append("@ci_JueSID,@ci_CaiDID)");
                            SqlParameter[] parameters2 = {
					new SqlParameter("@ci_JueSID", SqlDbType.Int,4),
					new SqlParameter("@ci_CaiDID", SqlDbType.Int,4)};
                            parameters2[0].Value =  _item.ci_JueSID;
                            parameters2[1].Value = _item.ci_CaiDID;
                            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql2.ToString(), parameters2);
                        }
                    }

                    trans.Commit();
                    result = "succeeded|" + parameters[0].Value.ToString();
                }
                catch (Exception ex)
                {
                    result = "error|" + ex.Message;
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return result;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetDataTableByRoleId(int RoleID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ci_JueSID,ci_CaiDID ");
            strSql.Append(" FROM RoleMenusDetails ");
            strSql.AppendFormat(" where ci_JueSID='{0}'",RoleID);

            return SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringMembership,CommandType.Text,strSql.ToString());
		}

        public List<Model.RoleMenusDetails> GetListByRoleId(int RoleID)
        {
            DataTable dt = GetDataTableByRoleId(RoleID);
            List<Model.RoleMenusDetails> list = new List<Model.RoleMenusDetails>();
            if (dt.Rows.Count > 0)
            {
              
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Model.RoleMenusDetails model = new Model.RoleMenusDetails();
                    model.ci_JueSID = Convert.ToInt32(dt.Rows[i]["ci_JueSID"].ToString());
                    model.ci_CaiDID = Convert.ToInt32(dt.Rows[i]["ci_CaiDID"].ToString());
                    list.Add(model);
                }
            }

            return list;
        }

		#endregion  Method
	}
}

