using System;
using System.Data;
using Pr_mobile_bank_rom_kir.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class SendToForm : Form
    {
        DataBaseConnection database =  new DataBaseConnection();
        Random rand = new Random();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public SendToForm()
        {
            InitializeComponent();
        }

        private void SendToForm_Load(object sender, EventArgs e)
        {
            // присваиваиваем текст боксам значения с прошлой формы
            TextBoxCardDestination.Text = DataStorage.bankCard;
            TextBoxCard.Text = DataStorage.cardNumber;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            // добавть сюда еще валют и нормальный курс
            double dolar = 32.787;
            double euro = 34.130;

            // объявляем переменные и присваиваем им значения из текст боксов
            var cardNumber = TextBoxCard.Text;
            var CardCVV = TextBoxCvv.Text;
            var CardDate = TextBoxCardTo.Text;
            var destinationCard = TextBoxCardDestination.Text;
            double sum = Convert.ToDouble(TextBoxSum.Text);
            var cardCurrency = "";
            var cardCurrency2 = "";
            var cardCVVCheck = "";
            var CardDateCheck = "";
            double cardBalanceCheck = 0;
            bool error = false;

            // запрос в бд при условии, что номер карты равен номеру карты в бд
            var queryCheckCard = $"select bank_card_cvv_code, CONCAT(FORMAT(bank_card_date, '%M'), '/', FORMAT(bank_card_date, '%y')), bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{cardNumber}'";
            // объявили запрос и передали сторку и вернули с подключением
            SqlCommand commandCheckCard = new SqlCommand(queryCheckCard, database.getConnection());
            database.openConnection();
            SqlDataReader reader = commandCheckCard.ExecuteReader();
            
            // достаем данные из ридара
            while (reader.Read())
            {
                // заполняем переменные согласно sql запросу
                cardCVVCheck = reader[0].ToString();
                CardDateCheck = reader[1].ToString();
                cardBalanceCheck = Convert.ToDouble(reader[2].ToString());
                cardCurrency = reader[3].ToString();
            }
            reader.Close();

            // совпадает ли код с тем, что ввели
            if (CardCVV != cardCVVCheck)
            {
                MessageBox.Show("Ошибка. Некорректно введен CVV-код", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }

            // совпадает ли дата с тем, что ввели
            if (CardDate != CardDateCheck)
            {
                MessageBox.Show("Ошибка. Некорректно введена дата карты", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }

            // запрос на совпадение карты для перевода с картой в бд
            var queryCheckCardNumber = $"select id_bank_card, bank_card_currency from bank_card where bank_card_number = '{destinationCard}'";
            // подключаемся и передаем запрос
            SqlCommand commandCheckCardNumber = new SqlCommand( queryCheckCardNumber, database.getConnection());

            // получение данных и их заполнение через ридер через цикл
            adapter.SelectCommand = commandCheckCardNumber;
            adapter.Fill(table);
            SqlDataReader reader1 = commandCheckCardNumber.ExecuteReader();

            while (reader1.Read()) 
            {
                cardCurrency2 = reader1[1].ToString();
            }
            reader1.Close();

            // если нет карты для перевода
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Ошибка. Некорректные данные карты получателя", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            // минимум для перевода
            if (Convert.ToDouble(sum) < 1.00)
            {
                MessageBox.Show("Ошибка. Минимальная сумма перевода 1.00 рублей", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            // на карту списания нельзя начислить
            if (cardNumber == destinationCard)
            {
                MessageBox.Show("Ошибка. Вы не можете перевести средства на эту карту", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }
            // нельзя уходить в отрицательный баланс 
            if ( sum > cardBalanceCheck)
            {
                MessageBox.Show("Ошибка. Недостаточно средств для совершения операции", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = true;
            }

            if (error == false)
            {
                // 
                DataStorage.bankCard = TextBoxCard.Text;
                //
                Validation validation = new Validation();
                validation.ShowDialog();

                // Если попытки есть
                if (DataStorage.attempts > 0)
                {
                    // генерация номеров для истроии транзакций
                    DateTime transactionDate = DateTime.Now;
                    var transactionNumber = "p";
                    for (int i = 0; i < 10; i++)
                    {
                        transactionNumber += Convert.ToString(rand.Next(0, 10));
                    }


                    var queryTransaction1 = $"";
                    var queryTransaction2 = $"";

                    // переводы с рублей
                    if (cardCurrency == "RUB" && cardCurrency == "USD")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum /= dolar}' where bank_card_number = '{destinationCard}'";
                    }
                    else if (cardCurrency == "RUB" && cardCurrency == "EUR")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum /= euro}' where bank_card_number = '{destinationCard}'";
                    }


                    // переводы с доллара
                    else if (cardCurrency == "USD" && cardCurrency == "RUB")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum *= dolar}' where bank_card_number = '{destinationCard}'";
                    }
                    else if (cardCurrency == "USD" && cardCurrency == "EUR")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum *= 0.96}' where bank_card_number = '{destinationCard}'";
                    }


                    // переводы с евро
                    else if (cardCurrency == "EUR" && cardCurrency == "RUB")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum *= euro}' where bank_card_number = '{destinationCard}'";
                    }
                    else if (cardCurrency == "EUR" && cardCurrency == "USD")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum * 1.04}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum}' where bank_card_number = '{destinationCard}'";
                    }
                    // доллары на доллары
                    else if (cardCurrency == "USD" && cardCurrency == "USD")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum}' where bank_card_number = '{destinationCard}'";
                    }
                    // евро на евро
                    else if (cardCurrency == "EUR" && cardCurrency == "EUR")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum}' where bank_card_number = '{destinationCard}'";
                    }
                    // рубли на рубли
                    else if (cardCurrency == "RUB" && cardCurrency == "RUB")
                    {
                        queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{sum}' where bank_card_number = '{cardNumber}'";
                        queryTransaction2 = $"update bank_card set bank_card_balance = bank_card_balance + '{sum}' where bank_card_number = '{destinationCard}'";
                    }
                    // добавить еще валют

                    // запрос на вставку данных из бд в истроию транзакций, выбрали нужную таблицу, выбрали нужные там поля и записываем в них данные и передаем id карты банка с которой идет перевод для взаимосвязи данных для авторизованного пользователя
                    var queryTransaction3 = $"insert into transactions(transaction_type, transaction_destination, transaction_date,transaction_number, transaction_value, id_bank_card) values('Перевод', '{destinationCard}', '{transactionDate}', '{transactionNumber}', '{sum}', (select id_bank_card from bank_card where bank_card_number = '{cardNumber}'))";
                    // записываем запросы для бд
                    var command1 = new SqlCommand(queryTransaction1, database.getConnection());
                    var command2 = new SqlCommand(queryTransaction2, database.getConnection());
                    var command3 = new SqlCommand(queryTransaction3, database.getConnection());
                    // возвращаем строку с подключением
                    database.openConnection();
                    // выполняем запрос 
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    database.closeConnection();

                    Close();
                }
            }
        }
        private void SendToForm_MouseDown(object sender, MouseEventArgs e)
        {  }

        private void TextBoxCvv_TextChanged(object sender, EventArgs e)
        {
            // по клику идет или показ CVV кода или сокрытие
            if (TextBoxCvv.Text == "***")
            {
                TextBoxCvv.Text = DataStorage.cardCVV;
            }
            else
            {
                TextBoxCvv.Text = "***";
            }
        }
    }
}
