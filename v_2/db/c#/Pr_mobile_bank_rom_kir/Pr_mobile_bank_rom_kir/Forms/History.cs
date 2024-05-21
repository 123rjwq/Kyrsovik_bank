using Pr_mobile_bank_rom_kir.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class History : Form
    {
        // Создание экземпляра класса для подключения к базе данных
        DataBaseConnection database = new DataBaseConnection();
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            // inner join - чтобы связать таблицу транзакций с таблицей карт банка через on через одинаковые поля id (transactions.id_bank_card = bank_card.id_bank_card) и дальше через джоин связываем таблицу банковских карт с таблицей клиентов через id клиента и id клиента = сейчас зареганому пользователю
            var querySelectTransactions = $"select transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value from transactions inner join bank_card on transactions.id_bank_card = bank_card.id_bank_card inner join client on client.id_client = bank_card.id_client where client.id_client = '{DataStorage.idClient}'";
            SqlCommand command = new SqlCommand(querySelectTransactions, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem lvitem = new ListViewItem(reader[0].ToString());
                lvitem.SubItems.Add(reader[1].ToString());
                lvitem.SubItems.Add(reader[2].ToString());
                lvitem.SubItems.Add(reader[3].ToString());
                lvitem.SubItems.Add(reader[4].ToString());
                listView1.Items.Add(lvitem);
            }

            reader.Close();

            listView1.Sort();
        }
    }
}
