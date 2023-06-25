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
using GameLauncherWinFormsGames.Properties;

namespace GameLauncherWinFormsGames
{
    public partial class SurviveRaceGame : Form
    {
        int roadSpeed;
        int trafficSpeed;
        int playerSpeed = 12;
        int score;
        int carImage;
        private string username1;
        string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";
        Random rand = new Random();
        Random carPosition = new Random();

        bool goleft, goright;
        public SurviveRaceGame(string username1)
        {
            InitializeComponent();
            ResetGame();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.username1 = username1;
            
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = "Score: " + score;
            score++;


            if (goleft == true && player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
            if (goright == true && player.Left < 415)
            {
                player.Left += playerSpeed;
            }

            roadTrack1.Top += roadSpeed;
            roadTrack2.Top += roadSpeed;

            if (roadTrack2.Top > 519)
            {
                roadTrack2.Top = -519;
            }
            if (roadTrack1.Top > 519)
            {
                roadTrack1.Top = -519;
            }

            AI1.Top += trafficSpeed;
            AI2.Top += trafficSpeed;


            if (AI1.Top > 530)
            {
                changeAIcars(AI1);

            }

            if (AI2.Top > 530)
            {
                changeAIcars(AI2);
            }

            if (player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                gameOver();
            }

            if (score > 40 && score < 500)
            {
                award.Image = Properties.Resources.bronze1;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Users SET achiv1 = 1 WHERE Login = @username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username1);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок при выполнении запроса
                }
            }


            if (score > 500 && score < 2000)
            {
                award.Image = Properties.Resources.silver1;
                roadSpeed = 20;
                trafficSpeed = 22;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Users SET achiv2 = 1 WHERE Login = @username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username1);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок при выполнении запроса
                }
            }

            if (score > 2000)
            {
                award.Image = Properties.Resources.gold1;
                trafficSpeed = 27;
                roadSpeed = 25;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Users SET achiv3 = 1 WHERE Login = @username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username1);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок при выполнении запроса
                }
            }


        }

        private void changeAIcars(PictureBox tempCar)
        {

            carImage = rand.Next(1, 9);

            switch (carImage)
            {

                case 1:
                    tempCar.Image = Properties.Resources.ambulance1;
                    break;
                case 2:
                    tempCar.Image = Properties.Resources.carGreen1;
                    break;
                case 3:
                    tempCar.Image = Properties.Resources.carGrey1;
                    break;
                case 4:
                    tempCar.Image = Properties.Resources.carOrange1;
                    break;
                case 5:
                    tempCar.Image = Properties.Resources.carPink1;
                    break;
                case 6:
                    tempCar.Image = Properties.Resources.CarRed1;
                    break;
                case 7:
                    tempCar.Image = Properties.Resources.carYellow1;
                    break;
                case 8:
                    tempCar.Image = Properties.Resources.TruckBlue1;
                    break;
                case 9:
                    tempCar.Image = Properties.Resources.TruckWhite1;
                    break;
            }


            tempCar.Top = carPosition.Next(100, 400) * -1;


            if ((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(5, 200);
            }
            if ((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(245, 422);
            }
        }

        private void gameOver()
        {
            playSound();
            gameTimer.Stop();
            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;

            award.Visible = true;
            award.BringToFront();

            btnStart.Enabled = true;




        }

        private void ResetGame()
        {

            btnStart.Enabled = false;
            explosion.Visible = false;
            award.Visible = false;
            goleft = false;
            goright = false;
            score = 0;
            award.Image = Properties.Resources.bronze1;

            roadSpeed = 12;
            trafficSpeed = 15;

            AI1.Top = carPosition.Next(200, 500) * -1;
            AI1.Left = carPosition.Next(5, 200);

            AI2.Top = carPosition.Next(200, 500) * -1;
            AI2.Left = carPosition.Next(245, 422);

            gameTimer.Start();



        }

        private void restartGame(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void playSound()
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.hit);
            playCrash.Play();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void SurviveRaceGame_Load(object sender, EventArgs e)
        {

        }
    }
}
