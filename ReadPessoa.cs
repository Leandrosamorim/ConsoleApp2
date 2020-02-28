using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp2
{
    public class ReadPessoa
    {
        public void Execute()
        {
            Console.WriteLine("Dados da tabela Pessoa");
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\leandro.amorim\source\repos\ConsoleApp2\App_Data\database.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = "SELECT * FROM Pessoa";

            using (var sqlConnection = new SqlConnection(connectionString))
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                //sqlCommand.Parameters.Add("@pessoaNome", SqlDbType.VarChar).Value = input;

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        var idColumnIndex = reader.GetOrdinal("Id");
                        var nomeColumnIndex = reader.GetOrdinal("Nome");
                        while (reader.Read())
                        {
                            var id = reader.GetFieldValue<int>(idColumnIndex);
                            var nome = reader.GetFieldValue<string>(nomeColumnIndex);
                            Console.WriteLine($"ID:{id}, Nome:{nome}");
                        }
                    }
                }
            }
        }
    }
}
