using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLauncherWinFormsGames
{
    public partial class RegPage : Form
    {
        private LogINpage previousForm;
        private string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";
        private string selectedImagePath;
        
        public RegPage(LogINpage form11)
        {
            InitializeComponent();
            previousForm = form11;
            PasswordBox.PasswordChar = '*';
            ConfirmPasswordBox.PasswordChar = '*';
            radioButton2.Visible = false;
            AvatarBox.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void RegPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            string username = LoginBox.Text;
            string password = PasswordBox.Text;
            string confirmPassword = ConfirmPasswordBox.Text;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            if (RegisterUser(username, password))
            {
                MessageBox.Show("Registration successful");

                // Перенаправление на другую страницу (например, MainForm)
                LogINpage mainForm = new LogINpage();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
           
        }

        private bool RegisterUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Проверяем, существует ли пользователь с таким же логином
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Login = @Login";
                    SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection);
                    checkUserCommand.Parameters.AddWithValue("@Login", username);

                    int existingUserCount = Convert.ToInt32(checkUserCommand.ExecuteScalar());
                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                        return false;
                    }

                    // Регистрируем нового пользователя
                    string registerQuery = "INSERT INTO Users (Login, Password, AvatarPath, achiv1, achiv2, achiv3, achiv4, achiv5, achiv6, achiv7, achiv8, achiv9, achiv10) VALUES (@Login, @Password, @AvatarPath, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)";
                    SqlCommand registerCommand = new SqlCommand(registerQuery, connection);
                    registerCommand.Parameters.AddWithValue("@Login", username);
                    registerCommand.Parameters.AddWithValue("@Password", password);
                    registerCommand.Parameters.AddWithValue("@AvatarPath", selectedImagePath); // Используем выбранный путь к фотографии

                    registerCommand.ExecuteNonQuery();

                    return true;
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
                ConfirmPasswordBox.PasswordChar = '\0'; // Отобразить пароль без маскировки
                radioButton1.Visible = false;
                radioButton2.Visible = true;
            }

            else
            {
                PasswordBox.PasswordChar = '*'; // Применить маскировку пароля
                ConfirmPasswordBox.PasswordChar = '*'; // Применить маскировку пароля
                
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                PasswordBox.PasswordChar = '*';
                ConfirmPasswordBox.PasswordChar = '*';
                radioButton1.Visible = true;
                radioButton2.Visible = false;
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    // Отображение выбранной фотографии в PictureBox или любом другом контроле, где нужно показать выбранное изображение
                    AvatarBox.Image = Image.FromFile(selectedImagePath);
                    AvatarBox.Visible = true;
                }
            }
        }

        private void AvatarBox_Click(object sender, EventArgs e)
        {

        }
    }
}
