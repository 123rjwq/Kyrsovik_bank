using Pr_mobile_bank_rom_kir.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class UserForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();
        public UserForm()
        {
            InitializeComponent();
        }

        private void RefreshData() 
        {
            // объявляем переменную и записываем ей запрос, который объединит все имена пользователя и возьмет номер и почту у того пользователя, кто сейчас вошёл
            var queryPIB = $"select concat(client_last_name, ' ' ,client_first_name, ' ' ,client_middle_name), client_phone_number, client_email from client where id_client = '{DataStorage.idClient}'";
            // отправляем запрос с помощью класса SqlCommand после подключения к бд
            SqlCommand commandPIB = new SqlCommand(queryPIB, database.getConnection());
            database.openConnection();
            // метод SqlCommand, который выполняет SQL-запрос и возвращает объект SqlDataReader
            // SqlDataReader используется для чтения строки за строкой из набора результатов
            SqlDataReader reader = commandPIB.ExecuteReader();
            // заполняем через ридер через цикл данные в лайблы
            while (reader.Read())
            {
                labelPIB.Text += reader[0].ToString();
                labelPhone.Text += reader[1].ToString();
                labelEmail.Text += reader[2].ToString();
            }
            reader.Close();
        }

        private void ClearFields() // метод для очистки текста лайблов
        {
            
            labelPIB.Text = string.Empty;
            labelPhone.Text = string.Empty;
            labelEmail.Text = string.Empty;
        }

        // при загрузке вызываем метод для заполнения данных в лайблах
        private void UserForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        // обновляем путем очистки данных лейблов и запись данных в них
        private void UpDateButton_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshData();
        }
        
        // вызов формы для изменения номера телефона
        private void changePhoneButton_Click(object sender, EventArgs e)
        {
            ChangePhoneNumber ChangePhoneNumber = new ChangePhoneNumber();
            ChangePhoneNumber.Show();
        }

        // вызов формы для изменения почты
        private void changeEmailButton_Click(object sender, EventArgs e)
        {
            ChangeEmail changeEmail = new ChangeEmail();
            changeEmail.Show();
        }

        // вызов формы для изменения пароля
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
