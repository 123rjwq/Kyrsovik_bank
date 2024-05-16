using System;
using System.Data;
using System.Linq;
using Pr_mobile_bank_rom_kir.Classes;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class RegistrationForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();
        public RegistrationForm()
        {
            InitializeComponent();
        }
        

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            // сразу переносим курсор в первое поле
            LastNameTextBox.Select();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            // Указываем тип кнопок в MessageBox
            MessageBoxButtons btn = MessageBoxButtons.OK;

            // Указываем иконку для MessageBox
            MessageBoxIcon ico = MessageBoxIcon.Information;

            // Задаем заголовок для MessageBox
            string caption = "Дата сохранения";

            // Регулярные выражения для правильной регестрации
            if (!Regex.IsMatch(LastNameTextBox.Text, "[A-Яa-я]+$"))
            {
                MessageBox.Show("Пожалуйста, введите фамилию повторно!", caption, btn, ico);
                LastNameTextBox.Select();
                return;
            }

            if (!Regex.IsMatch(FirstNameTextBox.Text, "[A-Яa-я]+$"))
            {
                MessageBox.Show("Введите имя повторно!", caption, btn, ico);
                FirstNameTextBox.Select();
                return;
            }

            if (!Regex.IsMatch(MiddleNameTextBox.Text, "[A-Яа-я]+$"))
            {
                MessageBox.Show("Пожалуйста, введите отчество повторно!", caption, btn, ico);
                MiddleNameTextBox.Select();
                return;
            }

            if (string.IsNullOrEmpty(GenderComboBox.SelectedItem.ToString()))
            {
                MessageBox.Show("Пожалуйста, выберите пол", caption, btn, ico);
                GenderComboBox.Select();
                return;
            }
            if (!Regex.IsMatch(PasswordTextBox.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("Пожалуйста, введите пароль", caption, btn, ico);
                PasswordTextBox.Select();
                return;
            }
            if (!Regex.IsMatch(ConfirmPasswordTextBox.Text, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
            {
                MessageBox.Show("Пожалуйста, введите подтверждение пароля", caption, btn, ico);
                ConfirmPasswordTextBox.Select();
                return;
            }
            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Ваш пароль и пароль подтверждения не совпадают", caption, btn, ico);
                ConfirmPasswordTextBox.SelectAll();
                return;
            }
            if (!Regex.IsMatch(AddressTextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Пожалуйста, введите вашу почту", caption, btn, ico);
                AddressTextBox.Select();
                return;
            }

            if (!Regex.IsMatch(PhoneNumberTextBox.Text, "^[+][7][9][0-9]{7,14}$"))
            {
                MessageBox.Show("Пожалуйста, введите номер телефона", caption, btn, ico);
                PhoneNumberTextBox.Select();
                return;
            }

            string yourSQL = "SELECT client_phone_number FROM client WHERE client_phone_number = '" + PhoneNumberTextBox.Text + "'";

            // комментировал в логине (строка 82)
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(yourSQL, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            // проверка на уникальность номера
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Номер телефона уже существует. Невозможно зарегистрировать аккаунт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PhoneNumberTextBox.SelectAll();
                return;
            }

            // выводим диалоговое окно и сохраняем выбор в переменную
            DialogResult result;
            result = MessageBox.Show("Вы хотите сохранить запись?", "Сохранение данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // если выбрали зарегистрироваться
            if (result == DialogResult.Yes)
            {
                // записываем данные в бд 
                string mySQL = string.Empty;
                mySQL += "INSERT INTO client (client_last_name, client_first_name, client_middle_name, client_gender, client_password, client_email, client_phone_number)";
                mySQL += "VALUES ('" + LastNameTextBox.Text + "','" + FirstNameTextBox.Text + "','" + MiddleNameTextBox.Text + "',";
                mySQL += "'" + GenderComboBox.SelectedItem.ToString() + "','" + PasswordTextBox.Text + "','" + AddressTextBox.Text + "','" + PhoneNumberTextBox.Text + "')";

                database.openConnection();
                // команда для внесения запроса в бд
                SqlCommand commandAddNewUser = new SqlCommand(mySQL, database.getConnection());
                // Выполняем SQL-запрос для добавления нового пользователя
                commandAddNewUser.ExecuteNonQuery();

                MessageBox.Show("Запись успешна сохранена", "Данные сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearControls();
                database.closeConnection();
                Close();
            }
        }
        // метод для очитски полей от данных
        private void clearControls()
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = string.Empty;
            }

            foreach (ComboBox comboBox in Controls.OfType<ComboBox>())
            {
                comboBox.SelectedItem = null;
            }
        }
        
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            LastNameTextBox.Select();
            clearControls();
        }

        private void PasswordTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCheckBox.Checked == true)
            {
                PasswordTextBox.UseSystemPasswordChar = false;
                ConfirmPasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTextBox.UseSystemPasswordChar = true;
                ConfirmPasswordTextBox.UseSystemPasswordChar = true;
            }
        }
    }
}
