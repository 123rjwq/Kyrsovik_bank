using Pr_mobile_bank_rom_kir.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Pr_mobile_bank_rom_kir.Forms
{
    public partial class LoginForm : Form
    {
        // создаем объект класса DataBaseConnection для работы с бд
        DataBaseConnection database = new DataBaseConnection();
        public LoginForm()
        {
            InitializeComponent();
        }

        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;

        //[System.Runtime.InteropServices.DllImport("user32.dll")]

        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //[System.Runtime.InteropServices.DllImport("user32.dll")]

        //public static extern bool ReleaseCapture();
        

        //private void LoginForm_Load_1(object sender, EventArgs e)
        //{
        //    PhoneNumberTextBox.Select();
        //}

        private void ShowPasswordCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ShowPasswordCheckBox.Checked == true)
            {
                // если галочка стоит, то шифровка оключена 
                PasswordTextBox.UseSystemPasswordChar = false;
            }
            else 
            {
                // иначе включена
                PasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // переход на форму регистрации
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // если поля не пустые 
            if (!string.IsNullOrEmpty(PhoneNumberTextBox.Text) && !string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                // выполнение бд запросов

                // проверка совпадения пароля и номера введеных со значениями в бд
                var querySelectClient = $"SELECT * FROM client WHERE client_phone_number = '{PhoneNumberTextBox.Text}' AND  client_password = '{PasswordTextBox.Text}'";
                // запись в переменную значения id_client чей номер был введен для 
                var queryGetId = $"select id_client from client where client_phone_number = '{PhoneNumberTextBox.Text}'";
                // записываем в переменную значение из объекта, который заносим запрос queryGetId и возвращаем значение подключения с бд
                var commandGetId = new SqlCommand(queryGetId, database.getConnection());
                // открываем подключение 
                database.openConnection();
                // читаем и записываем idClient
                SqlDataReader reader = commandGetId.ExecuteReader();

                while (reader.Read())
                {
                    // получаем из нулевой ячейки idClient и переводим это полученное значение в строку 
                    DataStorage.idClient = reader[0].ToString();
                }
                reader.Close();
                //Здесь создается объект adapter, который будет использоваться для заполнения DataTable данными из базы данных. SqlDataAdapter служит мостом между DataSet и источником данных, позволяя выполнять операции, такие как выборка данных (Fill) и обновление данных в базе данных (Update).
                SqlDataAdapter adapter = new SqlDataAdapter();
                //будет хранить данные, полученные из базы данных
                DataTable table = new DataTable();

                //возвращает открытую соединение с базой данных. Этот объект SqlCommand будет связан с SqlDataAdapter для выполнения запроса и заполнения DataTable
                SqlCommand command = new SqlCommand(querySelectClient, database.getConnection());

                // Связывание SqlCommand с SqlDataAdapter 
                adapter.SelectCommand = command;
                // содержит все строки и столбцы, возвращенные SQL-запросом
                adapter.Fill(table);

                // Проверка на правильность заполнение данных и существуют ли они в бд
                if (table.Rows.Count > 0)
                {
                    // сбрасываем данные
                    PhoneNumberTextBox.Clear();
                    PasswordTextBox.Clear();
                    ShowPasswordCheckBox.Checked = false;

                    // переход на главную форму
                    // Скрытие текущего окна
                    Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.ShowDialog();
                    // Очистка ссылки на форму после использования
                    mainForm = null;

                    //  снова становится видимой
                    Show();
                    // позволяет пользователю сразу начать ввод без необходимости кликать мышью на текстовое поле
                    PhoneNumberTextBox.Select();
                }
                else
                {
                    MessageBox.Show("Имя пользователя или пароль неверны. Попробуйте еще раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    PhoneNumberTextBox.Focus();
                    PhoneNumberTextBox.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // установка курсора в текстовое поле 
                PhoneNumberTextBox.Select();
            }
        }

        //private void CloseButton_Click(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.Application.Exit();// убедиться вставил через лампу
        //}

        //private void LoginForm_MouseDown(object sender, MouseEventArgs e) { }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // 
            //PhoneNumberTextBox.Select();
        }
        //{
        //    if (e.Button == MouseButtons.Left) 
        //    {
        //        ReleaseCapture();
        //        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        //    }
        //}
    }
}

// всесь код в комментариях можно удалить после проверки работоспособности