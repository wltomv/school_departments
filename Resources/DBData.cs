using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace school_departments.Resources
{
    public class DBData
    {
        public static string connectionString = DotNetEnv.Env.GetString("CONNECTIONSTRING");
        
        public static DataSet? ListTables(string procedureName, List<Parameter> parameter = null)
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(procedureName, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameter != null)
                {
                    foreach (var param in parameter)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                DataSet table = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);


                return table;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public static DataTable? List(string procedureName, List<Parameter> parameter = null)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(procedureName, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameter != null)
                {
                    foreach (var param in parameter)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                DataTable table = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);


                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool Execute(string procedureName, List<Parameter> parameter = null)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand cmd = new(procedureName, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameter != null)
                {
                    foreach (var param in parameter)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
