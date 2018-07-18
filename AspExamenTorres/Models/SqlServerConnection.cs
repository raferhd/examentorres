using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //DataTable, DataRow
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataAdapter, SqlException
using System.Configuration; //ConfigurationManager

public class SqlServerConnection
{
    #region attributes

    private static string _connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    private static SqlConnection _connection = new SqlConnection(_connectionString);

    #endregion

    #region methods

    /// <summary>
    /// Open's a connection to SqlServer
    /// </summary>
    /// <returns></returns>
    private static bool Open()
    {
        //connected
        bool connected = false;
        //checks is connection is already opened
        if (_connection.State != ConnectionState.Open)
            try
            {
                _connection.Open(); //open connection
                connected = true; //connection was successful
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        else
            connected = true;
        //return result
        return connected;
    }

    /// <summary>
    /// Executes a query and returns the resulting table
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public static DataTable ExecuteQuery(SqlCommand command)
    {
        //result table
        DataTable table = new DataTable();
        //open connection
        if (Open())
        {
            command.Connection = _connection; //assign connection
            SqlDataAdapter adapter = new SqlDataAdapter(command); //adapter
            try
            {
                adapter.Fill(table); //execute query and fill result table
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            _connection.Close(); //close connection
        }
        //return result table
        return table;
    }

    #endregion
}

