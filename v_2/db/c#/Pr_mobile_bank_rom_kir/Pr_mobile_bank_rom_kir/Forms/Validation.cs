using System;
using Pr_mobile_bank_rom_kir.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class Validation : Form
    {
        DataBaseConnection database = new DataBaseConnection();
       
        public Validation()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            // три попытки подтвердить перевод
            int attempts = 3;
            // присвоение введеного пина
            int cardPin = Convert.ToInt32(numericUpDownPin.Value);
            int pin = 0;

            // совпадает ли пик-код с пин-кодом карты из бд
            var queryCheckPin = $"select bank_card_pin from bank_card where bank_card_number = '{DataStorage.bankCard}'";
            // передача запроса и получение состояния
            SqlCommand command = new SqlCommand(queryCheckPin, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            // получаем пин карты из бд
            while (reader.Read())
                { pin = Convert.ToInt32(reader[0]); }
            reader.Close();

            // совпали пины
            if (cardPin == pin)
            {
                MessageBox.Show("Операция подтверждена", "ОК", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                DataStorage.attempts = attempts;
            }
            else
            {
                MessageBox.Show("Ошибка. Неверный Pin-код", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // вычитаем или блокирум из-за попыток
                if (attempts > 0)
                {
                    attempts--;
                }
                else 
                { 
                    DataStorage.attempts = attempts;
                    MessageBox.Show("У вас закончились попытки.", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            } 
        }
    }
}
