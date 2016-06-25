using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
using Common;
using System.Collections;
namespace DAL
{
    /// <summary>
    /// 数据访问类:WebNews
    /// </summary>
    public partial class WebNews
    {
        public WebNews()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.WebNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebNews(");
            strSql.Append("title,fromName,fromPath,author,type,typeId,seque,userId,roleId,limits,setHome,defined,putDate,editDate,verifyDate,deadline,contents,details,style,contants,visit,videoHtml,videoType,videoId,videoPath,imageUrl,deteState,IsTop,browsecount)");
            strSql.Append(" values (");
            strSql.Append("@title,@fromName,@fromPath,@author,@type,@typeId,@seque,@userId,@roleId,@limits,@setHome,@defined,@putDate,@editDate,@verifyDate,@deadline,@contents,@details,@style,@contants,@visit,@videoHtml,@videoType,@videoId,@videoPath,@imageUrl,@deteState,@IsTop,@browsecount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@fromName", SqlDbType.VarChar,100),
					new SqlParameter("@fromPath", SqlDbType.VarChar,500),
					new SqlParameter("@author", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@seque", SqlDbType.Int,4),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@limits", SqlDbType.VarChar,500),
					new SqlParameter("@setHome", SqlDbType.VarChar,50),
					new SqlParameter("@defined", SqlDbType.VarChar,5000),
					new SqlParameter("@putDate", SqlDbType.DateTime),
					new SqlParameter("@editDate", SqlDbType.DateTime),
					new SqlParameter("@verifyDate", SqlDbType.DateTime),
					new SqlParameter("@deadline", SqlDbType.Int,4),
					new SqlParameter("@contents", SqlDbType.VarChar,2000),
					new SqlParameter("@details", SqlDbType.Text),
					new SqlParameter("@style", SqlDbType.VarChar,1000),
					new SqlParameter("@contants", SqlDbType.VarChar,1000),
					new SqlParameter("@visit", SqlDbType.Int,4),
					new SqlParameter("@videoHtml", SqlDbType.VarChar,5000),
					new SqlParameter("@videoType", SqlDbType.VarChar,50),
					new SqlParameter("@videoId", SqlDbType.Int,4),
					new SqlParameter("@videoPath", SqlDbType.VarChar,1000),
					new SqlParameter("@imageUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@deteState", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
                    new SqlParameter("@browsecount", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.fromName;
            parameters[2].Value = model.fromPath;
            parameters[3].Value = model.author;
            parameters[4].Value = model.type;
            parameters[5].Value = model.typeId;
            parameters[6].Value = model.seque;
            parameters[7].Value = model.userId;
            parameters[8].Value = model.roleId;
            parameters[9].Value = model.limits;
            parameters[10].Value = model.setHome;
            parameters[11].Value = model.defined;
            parameters[12].Value = model.putDate;
            parameters[13].Value = model.editDate;
            parameters[14].Value = model.verifyDate;
            parameters[15].Value = model.deadline;
            parameters[16].Value = model.contents;
            parameters[17].Value = model.details;
            parameters[18].Value = model.style;
            parameters[19].Value = model.contants;
            parameters[20].Value = model.visit;
            parameters[21].Value = model.videoHtml;
            parameters[22].Value = model.videoType;
            parameters[23].Value = model.videoId;
            parameters[24].Value = model.videoPath;
            parameters[25].Value = model.imageUrl;
            parameters[26].Value = model.deteState;
            parameters[27].Value = model.IsTop;
            parameters[28].Value = model.browsecount;
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
        /// 更新一条数据
        /// </summary>
        public string Update(Model.WebNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebNews set ");
            strSql.Append("title=@title,");
            strSql.Append("fromName=@fromName,");
            strSql.Append("fromPath=@fromPath,");
            strSql.Append("author=@author,");
            strSql.Append("type=@type,");
            strSql.Append("typeId=@typeId,");
            strSql.Append("seque=@seque,");
            strSql.Append("userId=@userId,");
            strSql.Append("roleId=@roleId,");
            strSql.Append("limits=@limits,");
            strSql.Append("setHome=@setHome,");
            strSql.Append("defined=@defined,");
            strSql.Append("putDate=@putDate,");
            strSql.Append("editDate=@editDate,");
            strSql.Append("verifyDate=@verifyDate,");
            strSql.Append("deadline=@deadline,");
            strSql.Append("contents=@contents,");
            strSql.Append("details=@details,");
            strSql.Append("style=@style,");
            strSql.Append("contants=@contants,");
            strSql.Append("visit=@visit,");
            strSql.Append("videoHtml=@videoHtml,");
            strSql.Append("videoType=@videoType,");
            strSql.Append("videoId=@videoId,");
            strSql.Append("videoPath=@videoPath,");
            strSql.Append("imageUrl=@imageUrl,");
            strSql.Append("deteState=@deteState,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("browsecount=@browsecount");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@fromName", SqlDbType.VarChar,100),
					new SqlParameter("@fromPath", SqlDbType.VarChar,500),
					new SqlParameter("@author", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@seque", SqlDbType.Int,4),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@limits", SqlDbType.VarChar,500),
					new SqlParameter("@setHome", SqlDbType.VarChar,50),
					new SqlParameter("@defined", SqlDbType.VarChar,5000),
					new SqlParameter("@putDate", SqlDbType.DateTime),
					new SqlParameter("@editDate", SqlDbType.DateTime),
					new SqlParameter("@verifyDate", SqlDbType.DateTime),
					new SqlParameter("@deadline", SqlDbType.Int,4),
					new SqlParameter("@contents", SqlDbType.VarChar,2000),
					new SqlParameter("@details", SqlDbType.Text),
					new SqlParameter("@style", SqlDbType.VarChar,1000),
					new SqlParameter("@contants", SqlDbType.VarChar,1000),
					new SqlParameter("@visit", SqlDbType.Int,4),
					new SqlParameter("@videoHtml", SqlDbType.VarChar,5000),
					new SqlParameter("@videoType", SqlDbType.VarChar,50),
					new SqlParameter("@videoId", SqlDbType.Int,4),
					new SqlParameter("@videoPath", SqlDbType.VarChar,1000),
					new SqlParameter("@imageUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@deteState", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
                    new SqlParameter("@browsecount",SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.fromName;
            parameters[2].Value = model.fromPath;
            parameters[3].Value = model.author;
            parameters[4].Value = model.type;
            parameters[5].Value = model.typeId;
            parameters[6].Value = model.seque;
            parameters[7].Value = model.userId;
            parameters[8].Value = model.roleId;
            parameters[9].Value = model.limits;
            parameters[10].Value = model.setHome;
            parameters[11].Value = model.defined;
            parameters[12].Value = model.putDate;
            parameters[13].Value = model.editDate;
            parameters[14].Value = model.verifyDate;
            parameters[15].Value = model.deadline;
            parameters[16].Value = model.contents;
            parameters[17].Value = model.details;
            parameters[18].Value = model.style;
            parameters[19].Value = model.contants;
            parameters[20].Value = model.visit;
            parameters[21].Value = model.videoHtml;
            parameters[22].Value = model.videoType;
            parameters[23].Value = model.videoId;
            parameters[24].Value = model.videoPath;
            parameters[25].Value = model.imageUrl;
            parameters[26].Value = model.deteState;
            parameters[27].Value = model.IsTop;
            parameters[28].Value = model.browsecount;
            parameters[29].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebNews ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebNews ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
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
        public Model.WebNews GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,fromName,fromPath,author,type,typeId,seque,userId,roleId,limits,setHome,defined,putDate,editDate,verifyDate,deadline,contents,details,style,contants,visit,videoHtml,videoType,videoId,videoPath,imageUrl,deteState,IsTop,browsecount from WebNews ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.WebNews model = new Model.WebNews();
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return DataRowToModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取置顶信息实体
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public Model.WebNews GetTopModel(int typeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,fromName,fromPath,author,type,typeId,seque,userId,roleId,limits,setHome,defined,putDate,editDate,verifyDate,deadline,contents,details,style,contants,visit,videoHtml,videoType,videoId,videoPath,imageUrl,deteState,IsTop,browsecount from WebNews ");
            strSql.Append(" where typeId=@typeId Order By IsTop DESC,ID DESC");
            SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4)
			};
            parameters[0].Value = typeId;

            Model.WebNews model = new Model.WebNews();
            DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return DataRowToModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.WebNews DataRowToModel(DataRow row)
        {
            string flag = "";
            Model.WebNews model = new Model.WebNews();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["fromName"] != null)
                {
                    model.fromName = row["fromName"].ToString();
                }
                if (row["fromPath"] != null)
                {
                    model.fromPath = row["fromPath"].ToString();
                }
                if (row["author"] != null)
                {
                    model.author = row["author"].ToString();
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["typeId"] != null && row["typeId"].ToString() != "")
                {
                    model.typeId = int.Parse(row["typeId"].ToString());
                }
                if (row["seque"] != null && row["seque"].ToString() != "")
                {
                    model.seque = int.Parse(row["seque"].ToString());
                }
                if (row["userId"] != null && row["userId"].ToString() != "")
                {
                    model.userId = int.Parse(row["userId"].ToString());
                }
                if (row["roleId"] != null && row["roleId"].ToString() != "")
                {
                    model.roleId = int.Parse(row["roleId"].ToString());
                }
                if (row["limits"] != null)
                {
                    model.limits = row["limits"].ToString();
                }
                if (row["setHome"] != null)
                {
                    model.setHome = row["setHome"].ToString();
                }
                if (row["defined"] != null)
                {
                    model.defined = row["defined"].ToString();
                }
                if (row["putDate"] != null && row["putDate"].ToString() != "")
                {
                    model.putDate = DateTime.Parse(row["putDate"].ToString());
                }
                if (row["editDate"] != null && row["editDate"].ToString() != "")
                {
                    model.editDate = DateTime.Parse(row["editDate"].ToString());
                }
                if (row["verifyDate"] != null && row["verifyDate"].ToString() != "")
                {
                    model.verifyDate = DateTime.Parse(row["verifyDate"].ToString());
                }
                if (row["deadline"] != null && row["deadline"].ToString() != "")
                {
                    model.deadline = int.Parse(row["deadline"].ToString());
                }
                if (row["contents"] != null)
                {
                    model.contents = row["contents"].ToString();
                }
                if (row["details"] != null)
                {
                    model.details = row["details"].ToString();
                }
                if (row["style"] != null)
                {
                    model.style = row["style"].ToString();
                }
                if (row["contants"] != null)
                {
                    model.contants = row["contants"].ToString();
                }
                if (row["visit"] != null && row["visit"].ToString() != "")
                {
                    model.visit = int.Parse(row["visit"].ToString());
                }
                if (row["videoHtml"] != null)
                {
                    model.videoHtml = row["videoHtml"].ToString();
                }
                if (row["videoType"] != null)
                {
                    model.videoType = row["videoType"].ToString();
                }
                if (row["videoId"] != null && row["videoId"].ToString() != "")
                {
                    model.videoId = int.Parse(row["videoId"].ToString());
                }
                if (row["videoPath"] != null)
                {
                    model.videoPath = row["videoPath"].ToString();
                }
                if (row["imageUrl"] != null)
                {
                    model.imageUrl = row["imageUrl"].ToString();
                }
                if (row["deteState"] != null && row["deteState"].ToString() != "")
                {
                    model.deteState = int.Parse(row["deteState"].ToString());
                }
                if (row["IsTop"] != null && row["IsTop"].ToString() != "")
                {
                    if ((row["IsTop"].ToString() == "1") || (row["IsTop"].ToString().ToLower() == "true"))
                    {
                        model.IsTop = true;
                    }
                    else
                    {
                        model.IsTop = false;
                    }
                }
                if (row["browsecount"] != null && row["browsecount"].ToString() != "")
                {
                    model.browsecount = int.Parse(row["browsecount"].ToString());
                }
            }
            try
            {
                dataWork dw = new dataWork();
                Hashtable ht = new Hashtable();
                ht.Add("browsecount", model.browsecount + 1);
                dw.ExecUpdate(ht, "WebNews", "id=" + model.id);
            }
            catch (Exception)
            {
                
                throw;
            }
                return model;
        }
        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,fromName,fromPath,author,type,typeId,seque,userId,roleId,limits,setHome,defined,putDate,editDate,verifyDate,deadline,contents,details,style,contants,visit,videoHtml,videoType,videoId,videoPath,imageUrl,deteState,IsTop,browsecount ");
            strSql.Append(" FROM WebNews ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,title,fromName,fromPath,author,type,typeId,seque,userId,roleId,limits,setHome,defined,putDate,editDate,verifyDate,deadline,contents,details,style,contants,visit,videoHtml,videoType,videoId,videoPath,imageUrl,deteState,IsTop,browsecount ");
            strSql.Append(" FROM WebNews ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM WebNews ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from WebNews T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string UpdateTop(int id, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebNews set ");
            strSql.Append("IsTop=@IsTop");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                   new SqlParameter("@IsTop",SqlDbType.Int)};
            parameters[0].Value = id;
            parameters[1].Value = status;

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
        /// 获取上一篇、下一篇
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="newId"></param>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        public DataTable GetProAndNextList(string strWhere, string orderby, int newId, string rowNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from WebNews T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row in ({0})", rowNumber);

            return SqlHelper.ExecuteDataTable(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 获取当前文章的行号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public int GetCurrentRowNumber(string strWhere, string orderBy, int newsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                strSql.Append("order by T." + orderBy);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row,T.*  from WebNews T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT ");
            strSql.AppendFormat(" WHERE TT.id={0}", newsid);
            object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion  ExtensionMethod
    }
}

