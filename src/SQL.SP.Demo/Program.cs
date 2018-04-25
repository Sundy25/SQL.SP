using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SQL.SP.Demo
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var connetionString = "Data Source=localhost;Initial Catalog = master; User ID = sa; Password = web@1234;";

            using (var db = new SqlConnection(connetionString))
            {
                //pager
                Console.WriteLine("Pager 10 to 20 results:");
                var employees = db.Query<Employees>("[dbo].[spGetEmployeesAll]", new { @from = 10, @to = 20 }, commandType: CommandType.StoredProcedure);
                foreach (var item in employees.Take(5))
                {
                    Console.WriteLine(item);
                }

                //by id
                Console.WriteLine("Get by id=1 result:");
                var employee = db.QueryFirstOrDefault<Employees>("[dbo].[spGetEmployeeById]",new {@id=1},commandType:CommandType.StoredProcedure);
                Console.WriteLine(employee);
            }
             
            Console.ReadKey();
        }
    }
}
