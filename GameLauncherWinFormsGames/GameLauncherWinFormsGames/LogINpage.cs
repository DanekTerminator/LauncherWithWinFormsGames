using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GameLauncherWinFormsGames
{
    public partial class LogINpage : Form
    {
        private string loggedInUsername;
        private string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";
        public LogINpage()
        {
            InitializeComponent();
            PasswordBox.PasswordChar = '*';
            radioButton2.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegPage formregistration = new RegPage(this);

            // Скрытие текущей формы
           // this.Hide();

            // Отображение новой формы
            formregistration.Show();
        }

        private void LogINpage_Load(object sender, EventArgs e)
        {

        }

        private void Enter_Click(object sender, EventArgs e)
        {
            string username = LoginBox.Text;
            string password = PasswordBox.Text;
            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Authentication successful");
                loggedInUsername = username; // Сохраняем имя пользователя
                // Здесь вы можете перейти к другой форме или выполнить нужные действия после успешной авторизации.
                MainMenu formmain = new MainMenu(this,this);

                // Скрытие текущей формы
                this.Hide();

                // Отображение новой формы
                formmain.Show();
            }
            else
            {
                MessageBox.Show("Authentication failed");
            }
        }
        private bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Login = @Login AND Password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                PasswordBox.PasswordChar = '\0'; // Отобразить пароль без маскировки
                radioButton1.Visible = false;
                radioButton2.Visible = true;
            }
            
            else
            {
                PasswordBox.PasswordChar = '*'; // Применить маскировку пароля
                PasswordBox.Focus();
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                PasswordBox.PasswordChar = '*';
                radioButton1.Visible = true;
                radioButton2.Visible = false;
            }
        }
        public string GetLoggedInUsername()
        {
            return loggedInUsername;
        }
    }
}
