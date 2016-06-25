using System;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Collections;
using System.Diagnostics;

namespace DBUtility
{
	/// <summary>
	/// The OleDbHelper class is intended to encapsulate high performance, scalable best practices for 
	/// common uses of OleDbClient.
	/// </summary>
	[DebuggerStepThroughAttribute]
	public sealed class OleDbHelper
	{
		#region private utility methods & constructors

		//Since this class provides only static methods, make the default constructor private to prevent 
		//instances from being created with "new SqlHelper()".
		private OleDbHelper() {}



		/// <summary>
		/// This method is used to attach array of SqlParameters to a SqlCommand.
		/// 
		/// This method will assign a value of DbNull to any parameter with a direction of
		/// InputOutput and a value of null.  
		/// 
		/// This behavior will prevent default values from being used, but
		/// this will be the less common case than an intended pure output parameter (derived as InputOutput)
		/// where the user provided no input value.
		/// </summary>
		/// <param name="command">The command to which the parameters will be added</param>
		/// <param name="commandParameters">an array of SqlParameters tho be added to command</param>
		private static void AttachParameters(OleDbCommand command, OleDbParameter[] commandParameters)
		{
			foreach (OleDbParameter p in commandParameters)
			{
				//check for derived output value with no value assigned
				if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
				{
					p.Value = DBNull.Value;
				}
				
				command.Parameters.Add(p);
			}
		}

		/// <summary>
		/// This method assigns an array of values to an array of SqlParameters.
		/// </summary>
		/// <param name="commandParameters">array of SqlParameters to be assigned values</param>
		/// <param name="parameterValues">array of Components holding the values to be assigned</param>
		private static void AssignParameterValues(OleDbParameter[] commandParameters, object[] parameterValues)
		{
			if ((commandParameters == null) || (parameterValues == null)) 
			{
				//do nothing if we get no data
				return;
			}

			// we must have the same number of values as we pave parameters to put them in
			if (commandParameters.Length != parameterValues.Length)
			{
				throw new ArgumentException("Parameter count does not match Parameter Value count.");
			}

			//iterate through the SqlParameters, assigning the values from the corresponding position in the 
			//value array
			for (int i = 0, j = commandParameters.Length; i < j; i++)
			{
				commandParameters[i].Value = parameterValues[i];
			}
		}

		/// <summary>
		/// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
		/// to the provided command.
		/// </summary>
		/// <param name="command">the SqlCommand to be prepared</param>
		/// <param name="connection">a valid SqlConnection, on which to execute this command</param>
		/// <param name="transaction">a valid SqlTransaction, or 'null'</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParameters to be associated with the command or 'null' if no parameters are required</param>
		private static void PrepareCommand(OleDbCommand command,OleDbConnection connection,OleDbTransaction transaction, CommandType commandType, string commandText, OleDbParameter[] commandParameters)
		{
			//if the provided connection is not open, we will open it
			if (connection.State != ConnectionState.Open)
			{
				connection.Open();
			}

			//associate the connection with the command
			command.Connection = connection;

			//set the command text (stored procedure name or SQL statement)
			command.CommandText = commandText;

			//if we were provided a transaction, assign it.
			if (transaction != null)
			{
				command.Transaction = transaction;
			}

			//set the command type
			command.CommandType = commandType;

			//attach the command parameters if they are provided
			if (commandParameters != null)
			{
				AttachParameters(command, commandParameters);
			}

			return;
		}


		#endregion private utility methods & constructors

		#region DataHelpers

		public static string CheckNull(object obj)
		{
			return (string) obj;
		}

		public static string CheckNull(DBNull obj)
		{
			return null;
		}

		#endregion

		#region AddParameters

		public static object CheckForNullString(string text)
		{
			if(text == null || text.Trim().Length == 0)
			{
				return System.DBNull.Value;
			}
			else
			{
				return text;
			}
		}

		public static OleDbParameter MakeInParam(string ParamName, object Value)
		{
			return new OleDbParameter(ParamName,Value);
		}

		/// <summary>
		/// Make input param.
		/// </summary>
		/// <param name="ParamName">Name of param.</param>
		/// <param name="DbType">Param type.</param>
		/// <param name="Size">Param size.</param>
		/// <param name="Value">Param value.</param>
		/// <returns>New parameter.</returns>
		public static OleDbParameter MakeInParam(string ParamName, OleDbType DbType, int Size, object Value) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
		}		

		/// <summary>
		/// Make input param.
		/// </summary>
		/// <param name="ParamName">Name of param.</param>
		/// <param name="DbType">Param type.</param>
		/// <param name="Size">Param size.</param>
		/// <returns>New parameter.</returns>
		public static OleDbParameter MakeOutParam(string ParamName, OleDbType DbType, int Size) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
		}		

		/// <summary>
		/// Make stored procedure param.
		/// </summary>
		/// <param name="ParamName">Name of param.</param>
		/// <param name="DbType">Param type.</param>
		/// <param name="Size">Param size.</param>
		/// <param name="Direction">Parm direction.</param>
		/// <param name="Value">Param value.</param>
		/// <returns>New parameter.</returns>
		public static OleDbParameter MakeParam(string ParamName, OleDbType DbType, Int32 Size, ParameterDirection Direction, object Value) 
		{
			OleDbParameter param;

			if(Size > 0)
				param = new OleDbParameter(ParamName, DbType, Size);
			else
				param = new OleDbParameter(ParamName, DbType);

			param.Direction = Direction;
			if (!(Direction == ParameterDirection.Output && Value == null))
				param.Value = Value;

			return param;
		}
	

		#endregion

		#region ExecuteNonQuery

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteNonQuery(connectionString, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create & open a SqlConnection, and dispose of it after we are done.
			using (OleDbConnection cn = new OleDbConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="connection">a valid SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OleDbConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteNonQuery(connection, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) against the specified SqlConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{	
			//create a command and prepare it for execution
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, connection, (OleDbTransaction)null, commandType, commandText, commandParameters);
			
			//finally, execute the command.
			int retval = cmd.ExecuteNonQuery();
			
			// detach the SqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
            connection.Dispose();
			return retval;
		}

	
		/// <summary>
		/// Execute a SqlCommand (that returns no resultset and takes no parameters) against the provided SqlTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="transaction">a valid SqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OleDbTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteNonQuery(transaction, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a SqlCommand (that returns no resultset) against the specified SqlTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid SqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
			
			//finally, execute the command.
			int retval = cmd.ExecuteNonQuery();
			
			// detach the SqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
            
			return retval;
		}
		#endregion

		#region ExecuteDataSet

        /// <summary>
        /// Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connection">a valid SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <returns>a dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(OleDbConnection connection, CommandType commandType, string commandText)
        {
            //pass through the call providing null for the set of SqlParameters
            return ExecuteDataset(connection, commandType, commandText, (OleDbParameter[])null);
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">a valid SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>a dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, connection, (OleDbTransaction)null, commandType, commandText, commandParameters);

            //create the DataAdapter & DataSet
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();

            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            // detach the SqlParameters from the command object, so they can be used again.			
            cmd.Parameters.Clear();
            connection.Dispose();
            //return the dataset
            return ds;
        }
		/// <summary>
		/// Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteDataset(connectionString, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create & open a SqlConnection, and dispose of it after we are done.
			using (OleDbConnection cn = new OleDbConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteDataset(cn, commandType, commandText, commandParameters);
			}
		}
		

		/// <summary>
		/// Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="transaction">a valid SqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(OleDbTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteDataset(transaction, commandType, commandText, (OleDbParameter[])null);
		}
		
		/// <summary>
		/// Execute a SqlCommand (that returns a resultset) against the specified SqlTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid SqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
			
			//create the DataAdapter & DataSet
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			DataSet ds = new DataSet();

			//fill the DataSet using default values for DataTable names, etc.
			da.Fill(ds);
			
			// detach the SqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
            
			
			//return the dataset
			return ds;
		}
		


		#endregion ExecuteDataSet

		#region ExecuteDataTable

		/// <summary>
		/// Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataTable dt = ExecuteDataTable(connString, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>a DataTable containing the resultset generated by the command</returns>
		public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteDataTable(connectionString, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataTable dt = ExecuteDataTable(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
		/// <returns>a DataTable containing the resultset generated by the command</returns>
		public static DataTable ExecuteDataTable(string connectionString, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create & open a SqlConnection, and dispose of it after we are done.
			using (OleDbConnection cn = new OleDbConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteDataTable(cn, commandType, commandText, commandParameters);
			}
		}



		/// <summary>
		/// Execute a SqlCommand (that returns a resultset and takes no parameters) against the provided SqlConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataTable dt = ExecuteDataTable(conn, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connection">a valid SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>a DataTable containing the resultset generated by the command</returns>
		public static DataTable ExecuteDataTable(OleDbConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of SqlParameters
			return ExecuteDataTable(connection, commandType, commandText, (OleDbParameter[])null);
		}
		
		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset) against the specified OleDbConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataTable dt = ExecuteDataTable(conn, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>a DataTable containing the resultset generated by the command</returns>
		public static DataTable ExecuteDataTable(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, connection, (OleDbTransaction)null, commandType, commandText, commandParameters);
			
			//create the DataAdapter & DataTable
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			DataTable dt = new DataTable();

			//fill the DataTable using default values for DataTable names, etc.
			da.Fill(dt);
			
			// detach the OleDbParameters from the command object, so they can be used again.			
			cmd.Parameters.Clear();

            connection.Close();
            connection.Dispose();
			//return the DataTable
			return dt;						
		}
		

		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset and takes no parameters) against the provided OleDbTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataTable dt = ExecuteDataTable(trans, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="transaction">a valid OleDbTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>a DataTable containing the resultset generated by the command</returns>
		public static DataTable ExecuteDataTable(OleDbTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OleDbParameters
			return ExecuteDataTable(transaction, commandType, commandText, (OleDbParameter[])null);
		}
		
		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset) against the specified OleDbTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataTable dt = ExecuteDataTable(trans, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid OleDbTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>a DataTable containing the resultset generated by the command</returns>
		public static DataTable ExecuteDataTable(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
			
			//create the DataAdapter & DataTable
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			DataTable dt = new DataTable();

			//fill the DataTable using default values for DataTable names, etc.
			da.Fill(dt);
			
			// detach the OleDbParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
            

			//return the DataTable
			return dt;
		}
		


		#endregion ExecuteDataTable

		#region ExecuteReader

		/// <summary>
		/// this enum is used to indicate whether the connection was provided by the caller, or created by OleDbHelper, so that
		/// we can set the appropriate CommandBehavior when calling ExecuteReader()
		/// </summary>
		private enum OleDbConnectionOwnership	
		{
			/// <summary>Connection is owned and managed by OleDbHelper</summary>
			Internal, 
			/// <summary>Connection is owned and managed by the caller</summary>
			External
		}

		/// <summary>
		/// Create and prepare a OleDbCommand, and call ExecuteReader with the appropriate CommandBehavior.
		/// </summary>
		/// <remarks>
		/// If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
		/// 
		/// If the caller provided the connection, we want to leave it to them to manage.
		/// </remarks>
		/// <param name="connection">a valid OleDbConnection, on which to execute this command</param>
		/// <param name="transaction">a valid OleDbTransaction, or 'null'</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParameters to be associated with the command or 'null' if no parameters are required</param>
		/// <param name="connectionOwnership">indicates whether the connection parameter was provided by the caller, or created by OleDbHelper</param>
		/// <returns>OleDbDataReader containing the results of the command</returns>
		private static OleDbDataReader ExecuteReader(OleDbConnection connection, OleDbTransaction transaction, CommandType commandType, string commandText, OleDbParameter[] commandParameters, OleDbConnectionOwnership connectionOwnership)
		{	
			//create a command and prepare it for execution
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);
			
			//create a reader
			OleDbDataReader dr;

			// call ExecuteReader with the appropriate CommandBehavior
			if (connectionOwnership == OleDbConnectionOwnership.External)
			{
				dr = cmd.ExecuteReader();
			}
			else
			{
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			
			// detach the OleDbParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
			
			return dr;
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OleDbDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>a OleDbDataReader containing the resultset generated by the command</returns>
		public static OleDbDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OleDbParameters
			return ExecuteReader(connectionString, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OleDbDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>a OleDbDataReader containing the resultset generated by the command</returns>
		public static OleDbDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create & open a OleDbConnection
			OleDbConnection cn = new OleDbConnection(connectionString);
			cn.Open();

			try
			{
				//call the private overload that takes an internally owned connection in place of the connection string
				return ExecuteReader(cn, null, commandType, commandText, commandParameters,OleDbConnectionOwnership.Internal);
			}
			catch
			{
				//if we fail to return the OleDbDatReader, we need to close the connection ourselves
				cn.Close();
				throw;
			}
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset and takes no parameters) against the provided OleDbConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OleDbDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connection">a valid OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>a OleDbDataReader containing the resultset generated by the command</returns>
		public static OleDbDataReader ExecuteReader(OleDbConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OleDbParameters
			return ExecuteReader(connection, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset) against the specified OleDbConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OleDbDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>a OleDbDataReader containing the resultset generated by the command</returns>
		public static OleDbDataReader ExecuteReader(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//pass through the call to the private overload using a null transaction value and an externally owned connection
			return ExecuteReader(connection, (OleDbTransaction)null, commandType, commandText, commandParameters, OleDbConnectionOwnership.External);
		}

	
		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset and takes no parameters) against the provided OleDbTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  OleDbDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="transaction">a valid OleDbTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>a OleDbDataReader containing the resultset generated by the command</returns>
		public static OleDbDataReader ExecuteReader(OleDbTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OleDbParameters
			return ExecuteReader(transaction, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a resultset) against the specified OleDbTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///   OleDbDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new OleDbParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid OleDbTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>a OleDbDataReader containing the resultset generated by the command</returns>
		public static OleDbDataReader ExecuteReader(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//pass through to private overload, indicating that the connection is owned by the caller
			return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, OleDbConnectionOwnership.External);
		}

		#endregion ExecuteReader

		#region ExecuteScalar
		
		/// <summary>
		/// Execute a OleDbCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OleDbParameters
			return ExecuteScalar(connectionString, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a 1x1 resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new OleDbParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create & open a OleDbConnection, and dispose of it after we are done.
			using (OleDbConnection cn = new OleDbConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteScalar(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a 1x1 resultset and takes no parameters) against the provided OleDbConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="connection">a valid OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OleDbConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OleDbParameters
			return ExecuteScalar(connection, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a 1x1 resultset) against the specified OleDbConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new OleDbParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid OleDbConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OleDbConnection connection, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, connection, (OleDbTransaction)null, commandType, commandText, commandParameters);
			
			//execute the command & return the results
			object retval = cmd.ExecuteScalar();
			
			// detach the OleDbParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();
            connection.Dispose();
			return retval;
			
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a 1x1 resultset and takes no parameters) against the provided OleDbTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="transaction">a valid OleDbTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OleDbTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of OleDbParameters
			return ExecuteScalar(transaction, commandType, commandText, (OleDbParameter[])null);
		}

		/// <summary>
		/// Execute a OleDbCommand (that returns a 1x1 resultset) against the specified OleDbTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new OleDbParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid OleDbTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(OleDbTransaction transaction, CommandType commandType, string commandText, params OleDbParameter[] commandParameters)
		{
			//create a command and prepare it for execution
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
			
			//execute the command & return the results
			object retval = cmd.ExecuteScalar();
			
			// detach the OleDbParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();

            
			return retval;
		}

	
		#endregion ExecuteScalar	

	}

}
