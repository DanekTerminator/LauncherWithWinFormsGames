using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GameLauncherWinFormsGames
{
    public partial class MainMenu : Form
    {
        private LogINpage previousForm;
        private LogINpage loginForm;
        private string username;
        private bool isMenuOpen = false;
        private int menuWidth = 150;
        private int animationSpeed = 10;
        private Timer timer;
        private bool isSecondPanelOpen = false;
        private int secondPanelWidth = 200;
        private Timer panelWidthTimer; // Таймер для анимации изменения ширины панели
        private int panelWidthIncrement = 10; // Шаг изменения ширины панели
        private int panelMaxWidth = 350; // Максимальная ширина панели


        public MainMenu(LogINpage form1, LogINpage loginForm)
        {
            InitializeComponent();
            previousForm = form1;
            this.loginForm = loginForm;
            string loggedInUsername = loginForm.GetLoggedInUsername();
            LoginLabel.Text = loggedInUsername;
            username = loginForm.GetLoggedInUsername();
            this.StartPosition = FormStartPosition.CenterScreen;
            menuPanel.Left = -menuWidth;

            menuPanel.BackColor = Color.FromArgb(41, 53, 65);
            menuPanel.BorderStyle = BorderStyle.FixedSingle;
            menuPanel.Padding = new Padding(10);
            menuPanel.ForeColor = Color.Black;
            secondPanel.BackColor = Color.FromArgb(41, 53, 65);
            secondPanel.BorderStyle = BorderStyle.FixedSingle;
            secondPanel.Padding = new Padding(10);
            secondPanel.ForeColor = Color.Black;
            buttonTest.Visible = false;
            // Создайте таймер с интервалом, соответствующим скорости анимации
            timer = new Timer();
            timer.Interval = animationSpeed;
            timer.Tick += Timer_Tick;
            progressBar.Visible = false;
            pictureBox3.Visible = false;
            label2.Visible = false;
            
            string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT achiv7 FROM Users WHERE Login = @Login";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@Login", loggedInUsername);

                    int achiv7Value = (int)selectCommand.ExecuteScalar();

                    if (achiv7Value == 1)
                    {
                        // Выполнение действия, если achiv7 равно 1
                        buttonTest.Visible = true;
                        pictureBox3.Visible = true;
                    }
                    else if (achiv7Value == 0)
                    {
                        buttonTest.Visible = false;
                        pictureBox3.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void ToggleMenu()
        {
            if (isMenuOpen)
            {
                menuPanel.Visible = false;
                // Скрыть меню
                timer.Tick -= Timer_Tick; // Отключите обработчик события таймера
                timer.Start();
            }
            else
            {
                menuPanel.Visible = true;
                // Показать меню
                timer.Tick += Timer_Tick; // Включите обработчик события таймера
                timer.Start();
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            int targetLeft = isMenuOpen ? -menuWidth : 0;
            int currentLeft = menuPanel.Left;

            if (currentLeft == targetLeft)
            {
                timer.Stop();
                isMenuOpen = !isMenuOpen;
            }
            else
            {
                int newLeft = currentLeft + (isMenuOpen ? -animationSpeed : animationSpeed);
                if (Math.Abs(newLeft - targetLeft) < animationSpeed)
                {
                    newLeft = targetLeft;
                }
                menuPanel.Left = newLeft;
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            ToggleMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание новой формы
            CasualGames formcasual = new CasualGames(this, username);

            // Скрытие текущей формы
            this.Hide();

            // Отображение новой формы
            formcasual.Show();
            string loggedInUsername = loginForm.GetLoggedInUsername();
            string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Users SET achiv5 = 1 WHERE Login = @Login";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", loggedInUsername);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Создание новой формы
            ShooterGames formshooters = new ShooterGames(this);

            // Скрытие текущей формы
            this.Hide();

            // Отображение новой формы
            formshooters.Show();
            string loggedInUsername = loginForm.GetLoggedInUsername();
            string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Users SET achiv6 = 1 WHERE Login = @Login";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", loggedInUsername);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string loggedInUsername = loginForm.GetLoggedInUsername();
            RaceGames formraces = new RaceGames(this,username);

            
          //  this.Hide();

            
            formraces.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            string loggedInUsername = loginForm.GetLoggedInUsername();
            string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT AvatarPath FROM Users WHERE Login = @Login";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", loggedInUsername);

                    string photoPath = command.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(photoPath))
                    {
                        AvatarBox.BackgroundImage = Image.FromFile(photoPath);
                        AvatarBox.BackgroundImageLayout = ImageLayout.Stretch;
                        AvatarBox.BorderStyle = BorderStyle.FixedSingle;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string loggedInUsername = loginForm.GetLoggedInUsername();
            string photoPath = "";

            if (AvatarBox.BackgroundImage != null)
            {
                Image backgroundImage = AvatarBox.BackgroundImage;
                if (backgroundImage.Tag is string path)
                {
                    photoPath = path;
                }
            }

            ProfilePage profilePage = new ProfilePage(this, loggedInUsername, photoPath); // Передаем предыдущую форму в конструктор
            profilePage.Show();

            // Скрытие текущей формы
           // this.Hide();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToggleMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (secondPanel.Visible)
            {
                // Если панель уже видима, скрываем ее с помощью анимации уменьшения ширины
                AnimatePanelWidth(secondPanel, secondPanel.Width, 0, false);
            }
            else
            {
                // Если панель не видима, показываем ее с помощью анимации увеличения ширины
                AnimatePanelWidth(secondPanel, 0, panelMaxWidth, true);
            }
        }

        private void AnimatePanelWidth(Panel panel, int startWidth, int targetWidth, bool showPanel)
        {
            // Устанавливаем начальное состояние ширины панели
            panel.Width = startWidth;

            // Устанавливаем видимость панели в соответствии с переданным флагом
            panel.Visible = showPanel;

            // Создаем и настраиваем таймер для анимации изменения ширины панели
            panelWidthTimer = new Timer();
            panelWidthTimer.Interval = 10;
            panelWidthTimer.Tick += (sender, e) =>
            {
                if (panel.Width < targetWidth)
                {
                    // Увеличиваем ширину панели на заданный шаг
                    panel.Width += panelWidthIncrement;

                    // Проверяем, достигли ли целевой ширины панели
                    if (panel.Width >= targetWidth)
                    {
                        // Анимация завершена, устанавливаем конечное состояние ширины панели
                        panel.Width = targetWidth;
                        panelWidthTimer.Stop();
                    }
                }
                else if (panel.Width > targetWidth)
                {
                    // Уменьшаем ширину панели на заданный шаг
                    panel.Width -= panelWidthIncrement;

                    // Проверяем, достигли ли целевой ширины панели
                    if (panel.Width <= targetWidth)
                    {
                        // Анимация завершена, устанавливаем конечное состояние ширины панели
                        panel.Width = targetWidth;
                        panelWidthTimer.Stop();
                    }
                }
            };

            // Запускаем таймер для анимации изменения ширины панели
            panelWidthTimer.Start();
        }

        private async void TestGame_Click(object sender, EventArgs e)
        {
            if(buttonTest.Visible == true)
            {
                MessageBox.Show("Игра уже установлена!", "Повторная установка невозможна", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Отобразить сообщение о процессе установки
                MessageBox.Show("Идет установка игры...", "Установка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = true;
                label2.Visible = true;
                // Симуляция процесса установки
                int totalProgress = 100;
                int currentProgress = 0;
                int increment = 5;

                // Установка начального значения прогресс-бара
                progressBar.Value = 0;

                // Запуск асинхронной операции в отдельном потоке
                await Task.Run(async () =>
                {
                    // Цикл для постепенного наполнения прогресс-бара
                    while (currentProgress < totalProgress)
                    {
                        // Задержка для эффекта визуализации
                        await Task.Delay(100);

                        // Увеличение текущего прогресса
                        currentProgress += increment;

                        // Ограничение прогресса до максимального значения
                        if (currentProgress > totalProgress)
                            currentProgress = totalProgress;

                        // Обновление значения прогресс-бара
                        Invoke(new Action(() => progressBar.Value = currentProgress));
                    }
                });

                // Сообщение об успешной установке игры
                MessageBox.Show("Игра успешно установлена!", "Установка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = false;
                progressBar.Value = 0;
                buttonTest.Visible = true;
                pictureBox3.Visible = true;
                string loggedInUsername = loginForm.GetLoggedInUsername();
                string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";
                label2.Visible = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "UPDATE Users SET achiv7 = 1 WHERE Login = @Login";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@Login", loggedInUsername);
                        updateCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
            
        }

        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить игру?", "Удаление игры", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Отображение сообщения о процессе удаления игры
                MessageBox.Show("Идет удаление игры...", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = true;
                label2.Visible = true;
                // Симуляция процесса удаления игры
                int totalProgress = 100;
                int currentProgress = 0;
                int increment = 5;

                // Установка начального значения прогресс-бара
                progressBar.Value = 0;

                // Запуск асинхронной операции в отдельном потоке
                await Task.Run(async () =>
                {
                    // Цикл для постепенного наполнения прогресс-бара
                    while (currentProgress < totalProgress)
                    {
                        // Задержка для эффекта визуализации
                        await Task.Delay(100);

                        // Увеличение текущего прогресса
                        currentProgress += increment;

                        // Ограничение прогресса до максимального значения
                        if (currentProgress > totalProgress)
                            currentProgress = totalProgress;

                        // Обновление значения прогресс-бара
                        Invoke(new Action(() => progressBar.Value = currentProgress));
                    }
                });

                // Сообщение об успешном удалении игры
                MessageBox.Show("Игра успешно удалена!", "Удаление завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = false;
                progressBar.Value = 0;
                buttonTest.Visible = false;
                pictureBox3.Visible = false;
                string loggedInUsername = loginForm.GetLoggedInUsername();
                string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";
                label2.Visible = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "UPDATE Users SET achiv7 = 0 WHERE Login = @Login";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@Login", loggedInUsername);
                        updateCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            if (result== DialogResult.No)
            {
               
            }

            

            
                
            
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            // Создание новой формы
            Form2 formtestgame = new Form2(this);

            // Скрытие текущей формы
            this.Hide();

            // Отображение новой формы
            formtestgame.Show();
        }
    }
}
