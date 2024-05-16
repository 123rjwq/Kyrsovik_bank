using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pr_mobile_bank_rom_kir.Classes
{
    class DataBaseConnection
    {
        // строка подключения
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = Magicbook; Initial Catalog = mobile_bank_rom_kir; Integrated Security = True");


        // создаем длва метода соединения и разсоединения

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        { 
            return sqlConnection;
        }
    }
}
