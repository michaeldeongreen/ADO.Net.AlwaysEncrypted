using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net.AlwaysEncrypted.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local); integrated Security=sspi;initial catalog=Development; Column Encryption Setting = Enabled";
            string storedProcedure = "dbo.Company_Select";
            DataSet dataSet = new DataSet("Companies");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter("@Name", SqlDbType.NVarChar, 300);
                    parameter.Value = "Bitcoin";
                    command.Parameters.Add(parameter);

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = command;
                        adapter.Fill(dataSet);
                    }  
                }
            }

            Console.ReadLine();
        }
    }
}
