// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainHandler.cs" company="Dylan Corriveau">
//   
// </copyright>
// <summary>
//   This class is used to act as a middle layer between the UI and the other sections of the application
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Data.Common;
using SQLCopier.SQL;

namespace SQLCopier
{
    /// <summary>
    /// The sql handler
    /// </summary>
    public class MainHandler
    {
        /// <summary>
        /// this action is used to dictate what occurs when changes are added
        /// </summary>
        internal static Action<string> Change;
        /// <summary>
        /// this method is used to reset the SQL objects defined, such as remove connections and clear queries
        /// </summary>
        public static void Reset()
        {
            SQLConnectionHandler.RemoveConnections();
            SQLQueryHandler.ClearQueries();
        }
        /// <summary>
        /// this method is used to call the method that will add a new connection
        /// </summary>
        /// <param name="serverType">
        /// the type of server we are looking at (provider)
        /// </param>
        /// <param name="server">
        /// the name of the server we are connecting to
        /// </param>
        /// <param name="integratedSecurity">
        /// this is used if the provider is SQL server, and if is set, uses the Windows Login to login
        /// </param>
        /// <param name="username">
        /// this is the username to use for this connection
        /// </param>
        /// <param name="password">
        /// this is the password to use for this connection
        /// </param>
        /// <returns>
        /// the ID used to identify this connection throughout the application
        /// </returns>
        public static int AddNewConnection(string serverType, string server, bool integratedSecurity, string username, string password)
        {
            return SQLConnectionHandler.AddNewConnection(serverType, server, integratedSecurity, username, password);
        }

        /// <summary>
        /// this method is used to call the method that will check if the database given actually exists. If so, we add it to the connection string
        /// </summary>
        /// <param name="database">
        /// the name of the database 
        /// </param>
        /// <param name="connNumber">
        /// the connection number we want to use
        /// </param>
        /// <returns>
        /// a boolean dictating if the database exists or not
        /// </returns>
        public static bool CheckForExistanceOfDatabase(string database, int connNumber)
        {
            return SQLDBHandler.CheckForExistanceOfDatabase(database, connNumber);
        }

        /// <summary>
        /// this method is used to call the method that will check if the database given is empty
        /// </summary>
        /// <param name="database">
        /// the name of the database 
        /// </param>
        /// <param name="connNumber">
        /// the connection number we want to use
        /// </param>
        /// <returns>
        /// a boolean dictating if the database is empty or not
        /// </returns>
        public static bool CheckIfDbIsEmpty(string database, int connNumber)
        {
            return SQLDBHandler.CheckIfDbIsEmpty(database, connNumber);
        }

        /// <summary>
        /// This method is used to call the method that will compare two databases for their schema's. and see if the schema's are compatable
        /// </summary>
        /// <param name="database">
        ///     the name of the first database
        /// </param>
        /// <param name="database2">
        ///     the name of the second database
        /// </param>
        /// <param name="connNumber">
        ///     the connection number of the first database
        /// </param>
        /// <param name="connNumber2">
        ///     the connection number of the second database
        /// </param>
        /// <param name="justSchema">
        /// A boolean dictating if we want to just copy the schema's over
        /// </param>
        /// <returns>
        /// a boolean dictating if any errors occurred
        /// </returns>
        public static string CompareTableStructure(string database, string database2, int connNumber, int connNumber2, bool justSchema)
        {
            return SQLTableHandler.CompareTableStructure(database, database2, connNumber, connNumber2,justSchema);
        }

        /// <summary>
        /// this method is used to execute the copy command, by calling each of the appropriate methods to add not only the queries, but also the data to the second table
        /// </summary>
        /// <param name="database">
        /// the name of the first database
        /// </param>
        /// <param name="database2">
        /// the name of the second database
        /// </param>
        /// <param name="connNumber">
        /// the connection number of the first database
        /// </param>
        /// <param name="connNumber2">
        /// the connection number of the second database
        /// </param>
        /// <param name="queryStep">
        /// the action we want to take every query action
        /// </param>
        /// <param name="justStructure">
        /// a boolean dictating if the user just wants to copy the structure for now (incase they want to add any fields to the database before copying the data)
        /// </param>
        /// <returns>
        /// the asyncronous task, so it does not lock the UI
        /// </returns>
        public static void ExecuteCopy(string database, string database2, int connNumber, int connNumber2,Action<string> queryStep, Boolean justStructure)
        {
            //using the opened connection...
            using (DbConnection conn = SQLConnectionHandler.GetOpenedConnection(connNumber2))
            {
                //using the opened transaction...
                using (DbTransaction sqlTran = conn.BeginTransaction())
                {
                    try
                    {
                        //run the queries before, after, and copy the data
                        SQLQueryHandler.RunBeforeQueries(connNumber2, conn, sqlTran, queryStep);
                        if (!justStructure)
                        {
                            SQLDataHandler.CopyData(database, database2, connNumber, connNumber2, conn, sqlTran,
                                queryStep);
                        }
                        SQLQueryHandler.RunAfterQueries(connNumber2, conn, sqlTran, queryStep);
                        //commit the changes
                        sqlTran.Commit();
                    }
                    catch (Exception)
                    {
                        // rollback the transaction on error
                        sqlTran.Rollback();
                        throw;
                    }
                }
            }
        }

        // Create an asynchronous delegate that matches the Factorize method. 
        public delegate void AsyncFactorCaller(
            string database, string database2, int connNumber, int connNumber2, Action<string> queryStep,
            Boolean justStructure);
        /// <summary>
        /// this method will set up any application related options that need to be set
        /// </summary>
        /// <param name="changes">
        /// the action we want to use when adding a new change
        /// </param>
        public static void SetUp(Action<string> changes)
        {
            Change = changes;
            SQLConnectionHandler.AddProviders();
        }

        /// <summary>
        /// this method is used to call the underlying method that will gather all Key values from the providers list
        /// </summary>
        /// <returns>
        /// the list of provider keys
        /// </returns>
        public static IEnumerable GetProviders()
        {
            return SQLConnectionHandler.GetProviders();
        }
        /// <summary>
        /// This method is used to call the underlying log message
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void LogMessage(string message)
        {
            Logging.LogMessage(message);
        }
    }
}
