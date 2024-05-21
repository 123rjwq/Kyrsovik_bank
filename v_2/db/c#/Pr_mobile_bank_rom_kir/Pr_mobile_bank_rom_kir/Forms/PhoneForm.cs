using System;
using System.Data;
using Pr_mobile_bank_rom_kir.Classes;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Reflection.Emit;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class PhoneForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();
        Random rand = new Random();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public PhoneForm()
        {
            InitializeComponent();
            // позволяет воспринимать числа через точку, путем запрета написания через ',', чтобы избежать не соответствия типов переменных
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

        }

        private void PhoneForm_Load(object sender, EventArgs e)
        {
            // заполняем данными введеными на форме меин
            textBoxNumber.Text = DataStorage.phoneNumber;
            TextBoxCard.Text = DataStorage.cardNumber;

            var queryChooseOperator = $"select id_service, serviceName from clientServices where serviceType = 'Связь'";
            // передача запроса и получение строки подключения
            SqlDataAdapter commandChooseOperaot = new SqlDataAdapter(queryChooseOperator, database.getConnection());
            database.openConnection();

            // Создание нового объекта DataTable для хранения результатов запроса
            DataTable operators = new DataTable();
            // Заполнение DataTable данными из выполненного запроса
            commandChooseOperaot.Fill(operators);

            // Привязка полученных данных к элементу управления ComboBox
            comboBoxOperator.DataSource = operators;
            // Установка свойства ValueMember для определения значения, которое будет использоваться при выборе элемента
            comboBoxOperator.ValueMember = "id_service";
            // Установка свойства DisplayMember для определения того, какое поле будет отображаться в ComboBox
            comboBoxOperator.DisplayMember = "serviceName";
            // Закрытие соединения с базой данных после завершения операций
            database.closeConnection();
        }

        private void buttonSendToPhone_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;

            // Заголовок для MessageBox
            string caption = "Дата сохранения";
            // Получение текста из текстового поля для номера телефона
            string tmp = textBoxNumber.Text;
            // Извлечение первых двух символов из номера телефона для проверки
            string phoneNumberToCheck = String.Concat(tmp[2], tmp[3]);
            // Получение выбранного оператора из ComboBox
            string selectedOperator = comboBoxOperator.GetItemText(comboBoxOperator.SelectedItem);
            // Флаг для проверки корректности номера телефона
            bool numberCheck = false;

            // Проверка номера телефона в зависимости от выбранного оператора
            if (selectedOperator == "MTS") // МТС
            {
                if (phoneNumberToCheck != "14" && phoneNumberToCheck != "18" && phoneNumberToCheck != "13" && phoneNumberToCheck != "19")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "Megafon") // Мегафон
            {
                if (phoneNumberToCheck != "20" && phoneNumberToCheck != "26" && phoneNumberToCheck != "27" && phoneNumberToCheck != "37")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "Beeline") // Билайн
            {
                if (phoneNumberToCheck != "03" && phoneNumberToCheck != "09" && phoneNumberToCheck != "60" && phoneNumberToCheck != "76")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }
            else if (selectedOperator == "Tele2") // Теле2
            {
                if (phoneNumberToCheck != "52")
                {
                    MessageBox.Show("Введите корректный номер телефона.", caption, btn, ico);
                    numberCheck = true;
                }
            }


            // Если номер телефона прошел проверку
            if (numberCheck == false)
            {
                // Получение номера телефона из текстового поля
                var phoneNumber = textBoxNumber.Text;
                // Конвертация суммы из текстового поля в число с плавающей точкой
                double sum = Convert.ToDouble(textBoxSum.Text);

                // Получение данных с карточки пользователя
                var cardNumber = TextBoxCard.Text; 
                var cardCVV = TextBoxCvv.Text; 
                var cardDate = TextBoxCardTo.Text;

                // Инициализация переменных для проверки данных карты и баланса
                var cardCVVCheck = "";
                var cardDateCheck = "";
                double cardBalanceCheck = 0; 
                bool error = false; // Флаг ошибки
                string cardCurrency = ""; // Валюта карты

                // Расчет комиссии и общей суммы платежа
                double commission = (Convert.ToDouble(sum) * 0.001); // закон об отстутсвии коммисий 
                double totalSum = commission + Convert.ToDouble(sum);

                // Проверка формата номера телефона
                if (!Regex.IsMatch(textBoxNumber.Text, "^[+][7][9][0-9]{7,14}$"))
                {
                    MessageBox.Show("Пожалуйста, введите номер телефона", caption, btn, ico);
                    textBoxNumber.Select();
                    return;
                }

                // Создание SQL запроса для проверки данных карты
                var queryCheckCard = $"select bank_card_cvv_code, CONCAT(FORMAT(bank_card_data, '%M'), '/', FORMAT(bank_card_data, '%y')), bank_card_balance, bank_card_currency from bank_card where bank_card_number = '{cardNumber}'";
                // Создание объекта SqlCommand для выполнения запроса
                SqlCommand commandCheckCard = new SqlCommand(queryCheckCard, database.getConnection());
                // Открытие соединения с базой данных
                database.openConnection();
                // Выполнение запроса и чтение результатов
                SqlDataReader reader = commandCheckCard.ExecuteReader();

                // Чтение результатов запроса до конца
                while (reader.Read())
                {
                    // Присвоение значений из результата запроса переменным
                    cardCVVCheck = reader[0].ToString();
                    cardDateCheck = reader[1].ToString();
                    cardBalanceCheck = Convert.ToDouble(reader[2].ToString());
                    cardCurrency = reader[3].ToString();
                }
                reader.Close();

                if (cardCurrency != "RUB") 
                {
                    MessageBox.Show("Пополнение мобильного может происходить только в рублях", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true; 
                }

                if (cardCVV != cardCVVCheck)
                {
                    MessageBox.Show("Ошибка. Некорректно введен CVV-код", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }

                if (cardDate != cardDateCheck)
                {
                    MessageBox.Show("Ошибка. Некорректно введена дата карты", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true; 
                }

                if (Convert.ToDouble(sum) < 5.00)
                {
                    MessageBox.Show("Ошибка. Минимальная сумма пополнения 5.00 руб.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }
                if (sum > cardBalanceCheck)
                {
                    MessageBox.Show("Ошибка. Недостаточно средств для совершения операции", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }

                // Проверка отсутствия ошибок перед выполнением операций
                if (error == false)
                {
                    // Сохранение номера карты в хранилище данных
                    DataStorage.bankCard = TextBoxCard.Text;
                    // Создание экземпляра класса для валидации
                    Validation validation = new Validation();
                    // Отображение диалогового окна валидации
                    validation.ShowDialog();

                    // Проверка количества попыток
                    if (DataStorage.attempts > 0) 
                    {
                        // Получение текущей даты и времени транзакции
                        DateTime transactionDate = DateTime.Now;

                        // Генерация случайного номера транзакции
                        var transactionNumber = "P";
                        for (int i = 0; i < 10; i++)
                        {
                            transactionNumber += Convert.ToString(rand.Next(0, 10));
                        }

                        // Создание SQL запросов для обновления баланса карты и записи транзакции
                        var queryTransaction1 = $"update bank_card set bank_card_balance = bank_card_balance - '{totalSum}' where bank_card_number = '{cardNumber}'";
                        var queryTransaction2 = $"insert into transactions(transaction_type, transaction_destination, transaction_date, transaction_number, transaction_value, id_bank_card) values('Пополнение мобильного', '{textBoxNumber.Text}', '{transactionDate}', '{transactionNumber}', '{totalSum}', (select id_bank_card from bank_card where bank_card_number = '{cardNumber}'))";
                        var queryTransaction3 = $"update clientServices set serviceBalance = serviceBalance + '{sum}' where serviceName = '{comboBoxOperator.GetItemText(comboBoxOperator.SelectedItem)}' and serviceType = 'Связь'";

                        // Создание объектов SqlCommand для каждого запроса
                        var command1 = new SqlCommand(queryTransaction1, database.getConnection());
                        var command2 = new SqlCommand(queryTransaction2, database.getConnection());
                        var command3 = new SqlCommand(queryTransaction3, database.getConnection());

                        database.openConnection();

                        // Выполнение каждого запроса
                        command1.ExecuteNonQuery();
                        command2.ExecuteNonQuery();
                        command3.ExecuteNonQuery();

                        database.closeConnection();
                        
                        Close();
                    }
                }

            }
        }

        // метод для заполнения сведений об комиссии и итоговой суммы перевода 
        private void textBoxSum_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSum.Text == string.Empty)
            {
                textBoxSum.Text = null;
                labelCommission.Text = "0";
                labelTotalSum.Text = "0";
            }
            else
            { 
                double sum = Convert.ToDouble(textBoxSum.Text);
                labelCommission.Text = Convert.ToString(sum * 0.001);
                labelTotalSum.Text = Convert.ToString(labelCommission.Text + sum); // возможно надо сделать (sum * 0.00001) / 100) + sum
            }
        }

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





// Tele2 - 52
// Beeline - 03 09 60 76
// Megafon - 20 26 27 37
// MTS - 14 18 13 19

// проверить перевод, перед переводом задать номера согласно операторам и на вход и регестрацию поставить напоминалку операторов


