using Pr_mobile_bank_rom_kir.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
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
            // делаем так, чтобы label отображались поверх карт
            label_cardNumber.BringToFront();
            label_cardNumber.Text = "";
            label3.BringToFront();
            label_cardTo.BringToFront();
            label6.BringToFront();
            label_cardCvv.BringToFront();
            MirPictureBox2.Visible = false;
            VisaPictureBox3.Visible = false;

            // сопоставляем через id карты и id клиента его карты
            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.getConnection());
            database.openConnection();
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            сardsComboBox.DataSource = cards;
            // вывод информации в комбобокс
            сardsComboBox.ValueMember = "id_bank_card";
            сardsComboBox.DisplayMember = "bank_card_number";
            database.closeConnection();
            
            // вызов метода для вывода данных карты
            selectBankCard();
        }

        private void selectBankCard()
        {
            // поумолчанию пустые значения
            label_cardNumber.Text = "";
            string paymentSystem = "";
            // вывод информации из бд, CONCAT - объединяет несколько полей. Берем значение из bank_card, где номер карты равно из выбраному значению из комбо бокса
            string querySelectCard = $"select bank_card_number, bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date, '%y')), bank_card_paymentSystem , bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{сardsComboBox.GetItemText(сardsComboBox.SelectedItem)}'";
            SqlCommand command = new SqlCommand(querySelectCard, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            // через цикл и ридер будем в лайблы заполнять данные
            while (reader.Read())
            {
                // нулевое так как отсчет от нуля после select  в запросе 
                var cardNumber = reader[0].ToString();

                // циклы для вывода номера какрты по блокам
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

                // присваиваем значения дальше лайблам по порядку запроса в бд 
                label_cardCvv.Text = reader[1].ToString();
                label_cardTo.Text = reader[2].ToString();
                paymentSystem = reader[3].ToString();
                balanceLabel.Text = Math.Round(Convert.ToDouble(reader[4]), 2).ToString();
                currencyLabel.Text = reader[5].ToString();
                DataStorage.cardCVV = label_cardCvv.Text;
                label_cardCvv.Text = "***";
            }
            reader.Close();

           // взависимости от типа платежной системы выводим карту с логотипом выбраной платежной системы  
           if(paymentSystem == "Visa")
           {
              VisaPictureBox3.Visible = true;
              MirPictureBox2.Visible = false;
              gdyPictureBox8.Visible = false;
            }           
           else
           {
              MirPictureBox2.Visible = true;
              VisaPictureBox3.Visible = false;
              gdyPictureBox8.Visible = false;
            }       
        }

        private void label_cardCvv_Click(object sender, EventArgs e)
        {
            // по клику идет или показ CVV кода или сокрытие
            if (label_cardCvv.Text == "***")
            {
                label_cardCvv.Text = DataStorage.cardCVV;
            }
            else
            {
                label_cardCvv.Text = "***";
            }
        }
        // вызов окна создания новой карты
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddBankCard addBankCard = new AddBankCard();
            addBankCard.ShowDialog();
        }

        private void UpDateButton_Click(object sender, EventArgs e)
        {
            // объявили переменную в которую заносим данные карт авторизованного пользователя
            var queryMyCards = $"select id_bank_card, bank_card_number from bank_card where id_client = '{DataStorage.idClient}'";
            // передаем запрос
            SqlDataAdapter commandMyCards = new SqlDataAdapter(queryMyCards, database.getConnection());
            // возвращаем стоку с подключением
            database.openConnection();
            DataTable cards = new DataTable();
            commandMyCards.Fill(cards);
            // заносим данные банк карты для выбора 
            сardsComboBox.DataSource = cards;
            сardsComboBox.ValueMember = "id_bank_card";
            сardsComboBox.DisplayMember = "bank_card_number";
            // закрываем связь с бд 
            database.closeConnection();
            // вызов метода для вывода данных карты 
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

        private void TranslationButton_Click(object sender, EventArgs e)
        {
            // открытие новой формы и заносим данные номер карты и данные из текст бокса для ввода номера карты для перевода для автоматической подвязки 
            SendToForm sendToForm = new SendToForm();
            DataStorage.bankCard = CardTextBox.Text;
            DataStorage.cardNumber = сardsComboBox.GetItemText(сardsComboBox.SelectedItem);
            сardsComboBox.Text = "";
            sendToForm.ShowDialog();
        }

        // для первой загрузки комбо бокса с картами, по умолчанию пусто
        private void сardsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_cardNumber.Text = "";
            selectBankCard();
        }

        // переход в профиль пользователя
        private void UserPictureBox1_Click(object sender, EventArgs e)
        {
            UserForm userform = new UserForm();
            userform.Show();
        }

        private void HistoryPictureBox2_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
        }
        private void PhoneButton_Click(object sender, EventArgs e)
        {
            PhoneForm phoneForm = new PhoneForm();
            // выбираем выбранный номер карты из комбо бокса
            DataStorage.cardNumber = сardsComboBox.GetItemText(сardsComboBox.SelectedItem);
            // присваем номер телефона, который пользователь записал в текстовом сообщении
            DataStorage.phoneNumber = PhoneTextBox.Text;
            // далее очистим его
            PhoneTextBox.Text = "";
            // и вызавем окно
            phoneForm.Show();
        }

        private void gdyPictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
