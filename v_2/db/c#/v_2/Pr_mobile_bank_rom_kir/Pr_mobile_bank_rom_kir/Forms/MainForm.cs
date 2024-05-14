using Pr_mobile_bank_rom_kir.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class MainForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddBankCard addBankCard = new AddBankCard();
            addBankCard.ShowDialog();
        }

        public static extern int SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MainForm_Load(object sender, EventArgs e)
        {
            cardNumber_label.BringToFront();
            balanceLabel.Text = "";
            label12.BringToFront();
            label_cardTo.BringToFront();
            label15.BringToFront();
            label_cardCvv.BringToFront();
            MirPictureBox2.Visible = false;
            VisaPictureBox3.Visible = false;

            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.getConnection());
            database.openConnection();
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            CardsComboBox.DataSource = cards;
            CardsComboBox.ValueMember = "id_bank_card";
            CardsComboBox.DisplayMember = "bank_card_number";
            database.closeConnection();

            selectBankCard();
        }

        private void selectBankCard()
        {
            cardNumber_label.Text = "";
            string paymentSystem = "";
            string querySelectCard = $"select bank_card_number, bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date, '%y')), bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{CardsComboBox.GetItemText(CardsComboBox.SelectedItem)}'";
            SqlCommand command = new SqlCommand(querySelectCard, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cardNumber = reader[0].ToString();
                
                int tmp = 0;
                int tmp1 = 4;
                for (int m = 0; m < 4; m++)
                {
                    for (int n = tmp; n < tmp1; n++)
                    {
                        cardNumber_label.Text += cardNumber[n].ToString();
                    }
                    cardNumber_label.Text += " ";
                    tmp += 4;
                    tmp1 += 4;
                }

                label_cardCvv.Text = reader[1].ToString();
                label_cardTo.Text = reader[2].ToString();
                paymentSystem = reader[3].ToString();
                balanceLabel.Text = Math.Round(Convert.ToDouble(reader[4]), 2).ToString();
                this.cardNumber_label.Text = reader[5].ToString();
                DataStorage.cardCVV = label_cardCvv.Text;
                label_cardCvv.Text = "***";
                reader.Close();

                if (paymentSystem == "Мир")
                {
                    MirPictureBox2.Visible = true;
                    VisaPictureBox3.Visible = false;
                }
                else
                {
                    MirPictureBox2.Visible = false;
                    VisaPictureBox3.Visible = true;
                }

            }

        }

        private void UpDateButton_Click(object sender, EventArgs e)
        {
            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.getConnection());
            database.openConnection();
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            CardsComboBox.DataSource = cards;
            CardsComboBox.ValueMember = "id_bank_card";
            CardsComboBox.DisplayMember = "bank_card_number";
            database.closeConnection();

            selectBankCard();
        }

        private void label_cardCvv_Click(object sender, EventArgs e)
        {
            if (label_cardCvv.Text == "***")
            {
                label_cardCvv.Text = DataStorage.cardCVV;
            }
            else
            {
                label_cardCvv.Text = "***";
            }
        }

        private void label_cardCvv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
