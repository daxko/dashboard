using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace domain_tests
{
    [TestClass]
    public class DBTests
    {

        public IDbConnection db_connection;

        [TestInitialize]
        public void setup()
        {
            string db_connection_path = @"C:\\Daxko\\Dashboard\\db_connection_path.txt";

            var con_string = File.OpenText(db_connection_path).ReadToEnd();
            db_connection = new SqlConnection(con_string);

        }

        [TestCleanup]
        public void cleanup()
        {
            if(db_connection.State == ConnectionState.Open)
                db_connection.Close();
        }

    }
}
