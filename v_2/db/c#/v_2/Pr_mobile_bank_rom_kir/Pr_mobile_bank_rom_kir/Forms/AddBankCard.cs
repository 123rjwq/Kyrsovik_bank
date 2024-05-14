using System;
using System.Data;
using Pr_mobile_bank_rom_kir.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class AddBankCard : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        DataBaseConnection database = new DataBaseConnection();
        Random rand = new Random();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public AddBankCard()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newCardButton_Click(object sender, EventArgs e)
        {
            var cardType = cardTypeComboBox.GetItemText(cardTypeComboBox.SelectedItem);
            var currency = currencyComboBox.GetItemText(currencyComboBox.SelectedItem);
            var paymentSystem = paymentSystemComboBox.GetItemText(paymentSystemComboBox.SelectedItem);
            var cardNumber = "";
            var pinKod = numericUpDown.Value;
            var cvvCode = "";
            bool isCardFree = false;
            DateTime dateTime = DateTime.Now;
            var cardDate = dateTime.AddYears(4);

            for (int i = 0; i < 3; i++)
            {
                cvvCode += Convert.ToString(rand.Next(0, 10));
            }

            do
            {
                if (paymentSystem == "Мир")
                {
                    cardNumber += "2";
                    for (int i = 0; i < 15; i++)
                    {
                        cardNumber += Convert.ToString(rand.Next(0, 10));
                    }
                }
                else
                {
                    cardNumber += "4";
                    for (int i = 0; i < 15; i++)
                    {
                        cardNumber += Convert.ToString(rand.Next(10));
                    }
                }

                var queryCheckCardNumber = $"select * from bank_card where bank_card_number = '{cardNumber}'";
                SqlCommand command = new SqlCommand(queryCheckCardNumber, database.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    isCardFree = true;
                }
            } while (isCardFree == false);

            var queryAddNewCard = $"insert into bank_card(bank_card_type, bank_card_number, bank_card_cvv_code, bank_card_currency, bank_card_paymentsystems, bank_card_date, id_client, bank_card_pin) values ('{cardType}','{cardNumber}','{cvvCode}','{currency}','{paymentSystem}','{cardDate}','{DataStorage.idClient}','{pinKod}')";
            SqlCommand commandAddNewCard = new SqlCommand(queryAddNewCard, database.getConnection());
            database.openConnection();
            commandAddNewCard.ExecuteNonQuery();
            database.closeConnection();
            MessageBox.Show("Карта успешно создана", "Данные сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void AddBankCard_Load(object sender, EventArgs e)
        {
            cardTypeComboBox.SelectedIndex = 0;
            currencyComboBox.SelectedIndex = 0;
            paymentSystemComboBox.SelectedIndex = 0;
        }

        private void AddBankCard_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) 
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
