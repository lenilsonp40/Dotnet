using System;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess;

class Program
{
    static void Main(string[] args)
    {
       const string connectionString = "Server=localhost,1433;Database=balta;User Id=sa;Password=1q2w3e4r@#$";

       using (var connection = new SqlConnection(connectionString))
       {
        
       }

    }
}