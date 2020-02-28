using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp2
{
    public class InsertPessoa
    {
        public void Execute()
        {
            var input = Console.ReadLine();
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\leandro.amorim\source\repos\ConsoleApp2\App_Data\database.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = "INSERT INTO Pessoa" +
                            "(Nome)" +
                            "VALUES(@pessoaNome);";

            using (var sqlConnection = new SqlConnection(connectionString))
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                //sqlCommand.Parameters.Add("@pessoaNome", SqlDbType.VarChar).Value = input;
                sqlCommand.Parameters.AddWithValue("@pessoaNome", input);

                sqlConnection.Open();
                var resultScalar = sqlCommand.ExecuteScalar();
            }
        }
    }
}
