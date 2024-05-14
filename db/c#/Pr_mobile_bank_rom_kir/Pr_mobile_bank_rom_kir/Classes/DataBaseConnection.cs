using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pr_mobile_bank_rom_kir.Classes
{
    class DataBaseConnection
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = Magicbook; Initial Catalog = mobile_bank_rom_kir; Integrated Security = True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        { 
            return sqlConnection;
        }
    }
}
