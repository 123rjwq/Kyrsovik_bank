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


namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class MainForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public MainForm()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();
        

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            label_cardNumber.BringToFront();
            label_cardNumber.Text = "";
            label3.BringToFront();
            label_cardTo.BringToFront();
            label6.BringToFront();
            label_cardCvv.BringToFront();
            MirPictureBox2.Visible = false;
            VisaPictureBox3.Visible = false;

            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.GetConnection());
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
            label_cardNumber.Text = "";
            string paymentSystem = "";
            string querySelectCard = $"select bank_card_number, bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date, '%y')), bank_card_paymentSystem , bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{CardsComboBox.GetItemText(CardsComboBox.SelectedItem)}'";
            SqlCommand command = new SqlCommand(querySelectCard, database.GetConnection());
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
                        label_cardNumber.Text += cardNumber[n].ToString();
                    }
                    label_cardNumber.Text += " ";
                    tmp += 4;
                    tmp1 += 4;
                }

                label_cardCvv.Text = reader[1].ToString();//
                label_cardTo.Text = reader[2].ToString();//
                paymentSystem = reader[3].ToString(); // вроде
                balanceLabel.Text = Math.Round(Convert.ToDouble(reader[4]), 2).ToString();
                //string balanceString = reader[4].ToString();
                //double balance;

                //if (double.TryParse(balanceString, out balance))
                //{
                //    balanceLabel.Text = Math.Round(balance, 2).ToString();
                //}
                //else
                //{
                //    balanceLabel.Text = "Неверный баланс";
                //}
                currencyLabel.Text = reader[5].ToString();
                DataStorage.cardCVV = label_cardCvv.Text;
                label_cardCvv.Text = "***";
            }
                reader.Close();

                if (paymentSystem == "Мир")
                {
                    MirPictureBox2.Visible = true;
                    VisaPictureBox3.Visible = false;
                    //gdyPictureBox8.Visible = false;
                }
                else
                //{
                //    MirPictureBox2.Visible = false;
                //    VisaPictureBox3.Visible = false;
                //    gdyPictureBox8.Visible = true;
                //}
                //i/*f (paymentSystem == "Visa")*/
                {
                        MirPictureBox2.Visible = false;
                        VisaPictureBox3.Visible = true;
                        //gdyPictureBox8.Visible = false;
                }
                //else
                //{
                //    MirPictureBox2.Visible = false;
                //    VisaPictureBox3.Visible = false;
                //    gdyPictureBox8.Visible = true;
                //}

            


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
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddBankCard addBankCard = new AddBankCard();
            addBankCard.ShowDialog();
        }

        private void UpDateButton_Click(object sender, EventArgs e)
        {
            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.GetConnection());
            database.openConnection();
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            CardsComboBox.DataSource = cards;
            CardsComboBox.ValueMember = "id_bank_card";
            CardsComboBox.DisplayMember = "bank_card_number";
            database.closeConnection();

            selectBankCard();

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
