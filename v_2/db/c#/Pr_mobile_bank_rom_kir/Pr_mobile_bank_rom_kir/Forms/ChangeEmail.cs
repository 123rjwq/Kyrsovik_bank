using Pr_mobile_bank_rom_kir.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class ChangeEmail : Form
    {
        // Создание экземпляра класса для подключения к базе данных
        DataBaseConnection database = new DataBaseConnection();

        public ChangeEmail()
        {
            InitializeComponent();
        }

        private void changeEmailButton_Click(object sender, EventArgs e)
        {
            // Определение параметров сообщения об ошибке
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Дата cохpанения";

            // Проверка корректности введенной почты
            if (!Regex.IsMatch(EmailTextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Пожалуйста, введите вашу почту", caption, btn, ico);
                EmailTextBox.Select();
                return; 
            }
            // Получение почты из текстового поля   
            var email = EmailTextBox.Text;
            
            // Формирование SQL-запроса для обновления почты клиента
            var changeNumQuery = $"update client set client_email = '{email}' where id_client = '{DataStorage.idClient}'";

            // Открытие соединения с базой данных перед выполнением запроса
            database.openConnection();

            // Создание команды SQL для выполнения запроса
            var command = new SqlCommand(changeNumQuery, database.getConnection());

            // Выполнение запроса и проверка результата
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Электронная почта успешно изменена!");
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
