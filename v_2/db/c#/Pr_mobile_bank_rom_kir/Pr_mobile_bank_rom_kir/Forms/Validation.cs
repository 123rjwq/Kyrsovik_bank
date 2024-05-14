using System;
using System.Data;
using Pr_mobile_bank_rom_kir.Classes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class Validation : Form
    {
        DataBaseConnection database = new DataBaseConnection();
       
        public Validation()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            int attempts = 3;
            int cardPin = Convert.ToInt32(numericUpDownPin.Value);// понять
            int pin = 0;

            var queryCheckPin = $"select bank_card_pin from bank_card where bank_card_number = '{DataStorage.bankCard}'";
            SqlCommand command = new SqlCommand(queryCheckPin, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                { pin = Convert.ToInt32(reader[0]); }
            reader.Close();

            if (cardPin == pin)
            {
                MessageBox.Show("Операция подтверждена", "ОК", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                DataStorage.attempts = attempts;
            }
            else
            {
                MessageBox.Show("Ошибка. Неверный Pin-код", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (attempts > 0) { attempts--; }
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
