using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using GameLauncherWinFormsGames.Properties;
using GameLauncherWinFormsGames;

namespace GameLauncherWinFormsGames
{
    public partial class ProfilePage : Form
    {
        private string loggedInUsername;
        private string avatarPath;
        private MainMenu previousForm; // Предыдущая форма
        public ProfilePage(MainMenu previousForm, string login, string avatar )
        {
            InitializeComponent();
            loggedInUsername = login;
            avatarPath = avatar;
            this.previousForm = previousForm;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void ProfilePage_Load(object sender, EventArgs e)
        {
            LoginLabel.Text = loggedInUsername;

            // Выполнение запроса к базе данных для получения пути аватарки пользователя
            string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT AvatarPath, achiv1, achiv2, achiv3,achiv4,achiv5,achiv6 FROM Users WHERE Login = @Login";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", loggedInUsername);

                    string photoPath = command.ExecuteScalar()?.ToString();

                    SqlDataReader reader = command.ExecuteReader();
                    if (!string.IsNullOrEmpty(photoPath))
                    {
                        AvatarBox.BackgroundImage = Image.FromFile(photoPath);
                        AvatarBox.BackgroundImageLayout = ImageLayout.Stretch;
                        AvatarBox.BorderStyle = BorderStyle.FixedSingle;
                    }

                    if (reader.Read())
                    {
                        // Получение значений полей achiv1, achiv2, achiv3
                        int achiv1 = Convert.ToInt32(reader["achiv1"]);
                        int achiv2 = Convert.ToInt32(reader["achiv2"]);
                        int achiv3 = Convert.ToInt32(reader["achiv3"]);
                        int achiv4 = Convert.ToInt32(reader["achiv4"]);
                        int achiv5 = Convert.ToInt32(reader["achiv5"]);
                        int achiv6 = Convert.ToInt32(reader["achiv6"]);
                        int achivcount = 0;

                        // Присваивание картинок в зависимости от значений полей
                        if (achiv1 == 1)
                        {
                            BronzeRacer.BackgroundImage = Properties.Resources.bronze1;
                            BronzeRacer.BackgroundImageLayout = ImageLayout.Stretch;
                            achivcount++;
                        }
                        else
                        {
                            BronzeRacer.BackgroundImage = Properties.Resources.photoachiv;
                            BronzeRacer.BackgroundImageLayout = ImageLayout.Stretch;
                        }

                        if (achiv2 == 1)
                        {
                            SilverRacer.BackgroundImage = Properties.Resources.silver1;
                            SilverRacer.BackgroundImageLayout = ImageLayout.Stretch;
                            achivcount++;
                        }
                        else
                        {
                            SilverRacer.BackgroundImage = Properties.Resources.photoachiv;
                            SilverRacer.BackgroundImageLayout = ImageLayout.Stretch;
                        }

                        if (achiv3 == 1)
                        {
                            GoldRacer.BackgroundImage = Properties.Resources.gold1;
                            GoldRacer.BackgroundImageLayout = ImageLayout.Stretch;
                            achivcount++; 
                        }
                        else
                        {
                            GoldRacer.BackgroundImage = Properties.Resources.photoachiv;
                            GoldRacer.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (achiv4 == 1)
                        {
                            TetrisAch.BackgroundImage = Properties.Resources.tetrisloose;
                            TetrisAch.BackgroundImageLayout = ImageLayout.Stretch;
                            achivcount++;
                        }
                        else
                        {
                            TetrisAch.BackgroundImage = Properties.Resources.photoachiv;
                            TetrisAch.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (achiv5 == 1)
                        {
                            CasualAch.BackgroundImage = Properties.Resources.casualimage;
                            CasualAch.BackgroundImageLayout = ImageLayout.Stretch;
                            achivcount++;
                        }
                        else
                        {
                            CasualAch.BackgroundImage = Properties.Resources.photoachiv;
                            CasualAch.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (achiv6 == 1)
                        {
                            ShootersAch.BackgroundImage = Properties.Resources.shooters;
                            ShootersAch.BackgroundImageLayout = ImageLayout.Stretch;
                            achivcount++;
                        }
                        else
                        {
                            ShootersAch.BackgroundImage = Properties.Resources.photoachiv;
                            ShootersAch.BackgroundImageLayout = ImageLayout.Stretch;
                        }

                        // Заполняем ProgressBar в зависимости от достижений
                        int totalAchivments = 6;
                        progressBar1.Maximum = totalAchivments;
                        progressBar1.Value = achivcount;
                        int completionPercentage = (int)((float)achivcount / totalAchivments * 100);
                        labelPercentProgress.Text = completionPercentage.ToString()+ "% выполнено";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            previousForm.Show();

            // Закрываем текущую форму
            this.Close();
        }
    }
}

