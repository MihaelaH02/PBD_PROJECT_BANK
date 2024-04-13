using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Text;
using System.Threading.Tasks;

namespace Bank_project_pbd
{
    public class DatabaseManager    
    {
        private static DatabaseManager instance;
        [Obsolete]
        private readonly OracleConnection connection;

        [Obsolete]
        private DatabaseManager()
        {
            string connectionString = "Data Source=Mihaela;User Id=Bank;Password=000000";
            connection = new OracleConnection(connectionString);
            connection.Open();
        }

        [Obsolete]
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager();
                }
                return instance;
            }
        }

        [Obsolete]
        public OracleConnection Connection
        {
            get { return connection; }
        }
    }
}
