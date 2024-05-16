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
       
        // создаем два метода соединения и разсоединения
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
        // возвращаем строку подключения для выполнения команд 
        public SqlConnection getConnection()
        { 
            return sqlConnection;
        }
    }
}
