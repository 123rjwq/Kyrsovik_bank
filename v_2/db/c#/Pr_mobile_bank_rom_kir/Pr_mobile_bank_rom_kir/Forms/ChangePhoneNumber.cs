using Pr_mobile_bank_rom_kir.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class ChangePhoneNumber : Form
    {
        // Создание экземпляра класса для подключения к базе данных
        DataBaseConnection database = new DataBaseConnection();

        public ChangePhoneNumber()
        {
            InitializeComponent();
        }


        private void changePhoneButton_Click(object sender, EventArgs e)
        {
            // Определение параметров сообщения об ошибке
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата сохранения";


            if (!Regex.IsMatch(NumberTextBox.Text, "^[+][7][9][0-9]{7,14}$"))
            {
                MessageBox.Show("Пожалуйста, введите номер телефона", caption, btn, ico);
                NumberTextBox.Select();
                return;
            }

            // Получение номера телефона из текстового поля
            var phonenumber = NumberTextBox.Text;
            // Формирование SQL-запроса для обновления номера телефона клиента
            var changeNumQuery = $"update client set client_phone_number = '{phonenumber}' where id_client = '{DataStorage.idClient}'";
            // Создание команды SQL для выполнения запроса
            var command = new SqlCommand(changeNumQuery, database.getConnection());
            // Открытие соединения с базой данных перед выполнением запроса
            database.openConnection();

            // Выполнение запроса и проверка результата
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Номер телефона успешно изменен!");
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка!");
                database.closeConnection();
            }

            UserForm userform = new UserForm();
            userform.Show();
        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
