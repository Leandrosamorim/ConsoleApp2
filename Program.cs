using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var insertPessoa = new InsertPessoa();
            insertPessoa.Execute();

            var readPessoa = new ReadPessoa();
            readPessoa.Execute();
        }
    }
}
