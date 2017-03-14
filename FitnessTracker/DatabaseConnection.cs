using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    class DatabaseConnection
    {
        public SqlConnection connection;
        public string connect;

        public void connecting()
        {
            connect = "Data Source=Fitness;Initial Catalog=String;User Id=1;word=tester123";
            connection = new SqlConnection();
            connection.Open();
        }
    }
}
