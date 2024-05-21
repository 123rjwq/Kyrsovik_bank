using Pr_mobile_bank_rom_kir.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class ChangePassword : Form
    {
        // Создание экземпляра класса для подключения к базе данных
        DataBaseConnection database = new DataBaseConnection();

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            // Определение параметров сообщения об ошибке
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата сохранения";

            // Проверка корректности введенного пароля
            if (!Regex.IsMatch(PasswordTextBox.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("Пожалуйста, введите пароль", caption, btn, ico);
                PasswordTextBox.Select();
                return;
            }

            // Получение пароля из текстового поля
            var pass = PasswordTextBox.Text;
            // Формирование SQL-запроса для обновления пароля клиента
            var changeNumQuery = $"update client set client_password = '{pass}' where id_client = (select id_client from client where id_client = '{DataStorage.idClient}')";
            // Открытие соединения с базой данных перед выполнением запроса
            database.openConnection();
            // Создание команды SQL для выполнения запроса
            var command = new SqlCommand(changeNumQuery, database.getConnection());

            // Выполнение запроса и проверка результата
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Пароль успешно изменен!");
                Close();
            }
            else
            {
               MessageBox.Show("Ошибка!");
            }
            database.closeConnection();

            UserForm userform = new UserForm();
            userform.Show();
        }
    }
}
