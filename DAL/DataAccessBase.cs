using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSN.DAL
{
    public abstract class DataAccessBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessBase" /> class.
        /// </summary>        
        protected DataAccessBase()
        {
            DbHelper = new SqlDbHelper();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessBase" /> class.
        /// </summary>
        /// <param name="helper">An instance of the <see cref="IDbHelper" /> type, for injecting the dependency</param>      
        protected DataAccessBase(IDbHelper helper)
        {
            DbHelper = helper;
        }

        /// <summary>
        /// Gets the <see cref="IDbHelper" /> database helper
        /// </summary>        
        protected IDbHelper DbHelper { get; }

        /// <summary>
        /// Executes a stored procedure and returns a reader for the result
        /// </summary>
        /// <param name="procName">The procedure to execute</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns>        
        protected IDataReader ExecuteStoredProcReader(string procName)
        {
            return ExecuteReader(procName, DbCommandType.StoredProcedure);
        }

        /// <summary>
        /// Executes a stored procedure by passing in the provided parameters, and returns a reader for the result
        /// </summary>
        /// <param name="procName">The procedure to execute</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns>        
        protected IDataReader ExecuteStoredProcReader(string procName, List<DbParameter> parameters)
        {
            return ExecuteReader(procName, DbCommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Executes a stored procedure and returns a scalar output for the result
        /// </summary>
        /// <param name="procName">The procedure to execute</param>
        /// <returns>The scalar output from the procedure's execution</returns>        
        protected object ExecuteStoredProcScalar(string procName)
        {
            return ExecuteScalar(procName, DbCommandType.StoredProcedure);
        }

        /// <summary>
        /// Executes a stored procedure by passing in the provided parameters, and returns a scalar for the result
        /// </summary>
        /// <param name="procName">The procedure to execute</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure</param>
        /// <returns>The scalar output from the procedure's execution</returns>      
        protected object ExecuteStoredProcScalar(string procName, List<DbParameter> parameters)
        {
            return ExecuteScalar(procName, DbCommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Executes a stored procedure
        /// </summary>
        /// <param name="procName">The procedure to execute</param>
        /// <returns>The number of rows affected by the execution</returns>        
        protected int ExecuteStoredProcNonQuery(string procName)
        {
            return ExecuteNonQuery(procName, DbCommandType.StoredProcedure);
        }

        /// <summary>
        /// Executes a stored procedure by passing in the provided parameters
        /// </summary>
        /// <param name="procName">The procedure to execute</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure</param>
        /// <returns>The number of rows affected by the execution</returns> 
        protected int ExecuteStoredProcNonQuery(string procName, List<DbParameter> parameters)
        {
            return ExecuteNonQuery(procName, DbCommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Executes an inline query and returns a reader for the result
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns>   
        protected IDataReader ExecuteInlineQueryReader(string query)
        {
            return ExecuteReader(query, DbCommandType.InlineQuery);
        }

        /// <summary>
        /// Executes an inline query
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <returns>The number of rows affected by the execution</returns>       
        protected int ExecuteInlineNonQuery(string query)
        {
            return ExecuteNonQuery(query, DbCommandType.InlineQuery);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query and returns a reader for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns>     
        protected IDataReader ExecuteReader(string query, DbCommandType commandType)
        {
            return DbHelper.ExecuteReader(query, commandType);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters and returns a reader for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns> 
        protected IDataReader ExecuteReader(string query, DbCommandType commandType, List<DbParameter> parameters)
        {
            return DbHelper.ExecuteReader(query, commandType, parameters);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query, and returns a scalar for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>The scalar output from the procedure / query's execution</returns>   
        protected object ExecuteScalar(string query, DbCommandType commandType)
        {
            return DbHelper.ExecuteScalar(query, commandType);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters, and returns a scalar for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>The scalar output from the procedure / query's execution</returns>   
        protected object ExecuteScalar(string query, DbCommandType commandType, List<DbParameter> parameters)
        {
            return DbHelper.ExecuteScalar(query, commandType, parameters);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query
        /// </summary>
        /// <param name="nonQuery">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>The number of rows affected by the execution</returns>      
        protected int ExecuteNonQuery(string nonQuery, DbCommandType commandType)
        {
            return DbHelper.ExecuteNonQuery(nonQuery, commandType);
        }

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters
        /// </summary>
        /// <param name="nonQuery">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>The number of rows affected by the execution</returns>        
        protected int ExecuteNonQuery(string nonQuery, DbCommandType commandType, List<DbParameter> parameters)
        {
            return DbHelper.ExecuteNonQuery(nonQuery, commandType, parameters);
        }

        /// <summary>
        /// Constructs and returns a date time parameter from the name and value provided. Accounts for null / empty date times
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">value of the parameter</param>
        /// <returns>A <see cref="SqlParameter"/> instance for the date time parameter</returns>
        protected SqlParameter GetDateTimeSqlParameter(string name, DateTime value)
        {
            return value == DateTime.MinValue ? new SqlParameter(name, null) : new SqlParameter(name, value);
        }

        /// <summary>
        /// Constructs and returns a guid parameter from the name and value provided. Accounts for null / empty guids
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">value of the parameter</param>
        /// <returns>A <see cref="SqlParameter"/> instance for the guid parameter</returns>
        protected SqlParameter GetGuidSqlParameter(string name, Guid value)
        {
            return value == Guid.Empty ? new SqlParameter(name, null) : new SqlParameter(name, value);
        }

        /// <summary>
        /// Gets the value of the parameter as a string
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>String value of the parameter</returns>
        protected string GetStringValueOf(object parameter)
        {
            if (parameter == DBNull.Value)
            {
                return null;
            }

            return ((string)parameter).Trim();
        }

        /// <summary>
        /// Gets the value of the generic parameter
        /// </summary>
        /// <typeparam name="T">The type of the parameter passed</typeparam>
        /// <param name="parameter">The parameter</param>
        /// <returns>Type T value of the parameter</returns>
        protected T GetValueOf<T>(object parameter)
        {
            if (parameter == DBNull.Value)
            {
                return default(T);
            }

            return (T)parameter;
        }
        
    }
}
