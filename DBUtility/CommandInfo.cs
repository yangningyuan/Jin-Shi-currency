using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DBUtility
{
    public class CommandInfo
    {
        public CommandInfo()
        {
        }
        public CommandInfo(string strSql, SqlParameter[] para)
        {
            sql_str = strSql;
            parames = para;
        }

        private string sql_str;

        public string Sql_str
        {
            get { return sql_str; }
            set { sql_str = value; }
        }
        private SqlParameter[] parames;

        public SqlParameter[] Parames
        {
            get { return parames; }
            set { parames = value; }
        }
    }
}
