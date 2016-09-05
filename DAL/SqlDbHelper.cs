using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace DSN.DAL
{
    public class SqlDbHelper : IDbHelper
    {
        /// <summary>
        /// Field holding the connection string to the SQL Server database
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Field holding the Enterprise Library database abstraction for the SQL Server database
        /// </summary>
        private Database db;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDbHelper" /> class.
        /// </summary>
        public SqlDbHelper()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDbHelper" /> class.
        /// </summary>
        /// <param name="db">An instance of the <see cref="Database" /> type, for injecting the dependency</param>     
        public SqlDbHelper(Database db)
        {
            Db = db;
        }

        /// <summary>
        /// Gets or sets the connection string to the SQL Server database
        /// </summary> 
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionStrings.DSNDb]?.ConnectionString;
                }

                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }

        /// <summary>
        /// Gets or sets the Enterprise Library database abstraction for the SQL Server database
        /// </summary>
        public Database Db
        {
            get
            {
                if (db != null)
                {
                    return db;
                }

                return db = new SqlDatabase(ConnectionString);
            }

            set
            {
                db = value;
            }
        }

        /// <summary>
        /// Executes a stored procedure or an inline query and returns a reader for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns>        
        public IDataReader ExecuteReader(string query, DbCommandType commandType)
        {
            return ExecuteReader(query, commandType, null);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters and returns a reader for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns>   
        public IDataReader ExecuteReader(string query, DbCommandType commandType, List<DbParameter> parameters)
        {
            DbCommand cmd = null;

            if (commandType == DbCommandType.StoredProcedure)
            {
                
                cmd = Db.GetStoredProcCommand(query);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
            }
            else if (commandType == DbCommandType.InlineQuery)
            {
                
                throw new NotImplementedException("Inline queries are currently not supported");
            }

            return Db.ExecuteReader(cmd);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query, and returns a scalar for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>The scalar output from the procedure / query's execution</returns>        
        public object ExecuteScalar(string query, DbCommandType commandType)
        {
            return ExecuteScalar(query, commandType, null);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters, and returns a scalar for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>The scalar output from the procedure / query's execution</returns>      
        public object ExecuteScalar(string query, DbCommandType commandType, List<DbParameter> parameters)
        {
            DbCommand cmd = null;

            if (commandType == DbCommandType.StoredProcedure)
            {
                
                cmd = Db.GetStoredProcCommand(query);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
            }
            else if (commandType == DbCommandType.InlineQuery)
            {
                
                throw new NotImplementedException("Inline queries are currently not supported");
            }

            return Db.ExecuteScalar(cmd);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query
        /// </summary>
        /// <param name="nonQuery">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>The number of rows affected by the execution</returns>          
        public int ExecuteNonQuery(string nonQuery, DbCommandType commandType)
        {
            return ExecuteNonQuery(nonQuery, commandType, null);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters
        /// </summary>
        /// <param name="nonQuery">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>The number of rows affected by the execution</returns>         
        public int ExecuteNonQuery(string nonQuery, DbCommandType commandType, List<DbParameter> parameters)
        {
            DbCommand cmd = null;

            if (commandType == DbCommandType.StoredProcedure)
            {
                
                cmd = Db.GetStoredProcCommand(nonQuery);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
            }
            else if (commandType == DbCommandType.InlineQuery)
            {
                
                throw new NotImplementedException("Inline queries are currently not supported");
            }

            var returnval = Db.ExecuteNonQuery(cmd);

            return returnval;
        }
    }

    public enum DbCommandType
    {
        /// <summary>
        /// Command Type: Unknown 
        /// </summary>
        Unknown,

        /// <summary>
        /// Command Type: Stored Procedure
        /// </summary>
        StoredProcedure,

        /// <summary>
        /// Command Type: Inline Query
        /// </summary>
        InlineQuery
    }
}
