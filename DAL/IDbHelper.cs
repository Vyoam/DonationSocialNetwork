using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSN.DAL
{
    public interface IDbHelper
    {
        /// <summary>
        /// Gets or sets the connection string to the database
        /// </summary>        
        string ConnectionString { get; set; }

        /// <summary>
        /// Executes a stored procedure or an inline query and returns a reader for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns>        
        IDataReader ExecuteReader(string query, DbCommandType commandType);

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters and returns a reader for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>A <see cref="IDataReader"/> instance from the execution result</returns> 
        IDataReader ExecuteReader(string query, DbCommandType commandType, List<DbParameter> parameters);

        /// <summary>
        /// Executes a stored procedure or an inline query, and returns a scalar for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>The scalar output from the procedure / query's execution</returns>     
        object ExecuteScalar(string query, DbCommandType commandType);

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters, and returns a scalar for the result
        /// </summary>
        /// <param name="query">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>The scalar output from the procedure / query's execution</returns>      
        object ExecuteScalar(string query, DbCommandType commandType, List<DbParameter> parameters);

        /// <summary>
        /// Executes a stored procedure or an inline query
        /// </summary>
        /// <param name="nonQuery">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <returns>The number of rows affected by the execution</returns>            
        int ExecuteNonQuery(string nonQuery, DbCommandType commandType);

        /// <summary>
        /// Executes a stored procedure or an inline query by passing in the provided parameters
        /// </summary>
        /// <param name="nonQuery">The stored procedure or query to execute</param>
        /// <param name="commandType">Type (stored procedure / query) of the query</param>
        /// <param name="parameters">List of <see cref="DbParameter"/> instances representing the parameters to pass to the procedure / query</param>
        /// <returns>The number of rows affected by the execution</returns>    
        int ExecuteNonQuery(string nonQuery, DbCommandType commandType, List<DbParameter> parameters);
    }
}
