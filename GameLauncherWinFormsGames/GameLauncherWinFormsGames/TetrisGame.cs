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
    public partial class TetrisGame : Form
    {
        public const int width = 15, height = 25, k = 15; // Размеры поля и размер клетки в пикселях
        public int[,] shape = new int[2, 4]; // Массив для хранения падающей фигурки (для каждого блока 2 координаты [0, i] и [1, i]
        public int[,] field = new int[width, height]; // Массив для хранения поля
        public Bitmap bitfield = new Bitmap(k * (width + 1) + 1, k * (height + 3) + 1);
        public Graphics gr; // Для рисования поля на PictureBox
        private string username1;
        string connectionString = "Data Source=MASARUPC\\SQLEXPRESS01;Initial Catalog=LauncherGamesBD;Integrated Security=True";
        private CasualGames previousForm;
        public TetrisGame(CasualGames form1, string username1)
        {
           

            InitializeComponent();
            gr = Graphics.FromImage(bitfield);
            for (int i = 0; i < width; i++)
                field[i, height - 1] = 1;
            for (int i = 0; i < height; i++)
            {
                field[0, i] = 1;
                field[width - 1, i] = 1;
            }
            SetShape();
            TickTimer.Interval = 100; // Интервал в миллисекундах (1 секунда)
            TickTimer.Tick += TickTimer_Tick; // Привязка обработчика события Tick таймера
            TickTimer.Enabled = true; // Активация таймера
            this.username1 = username1;
            previousForm = form1;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void UpdateAchievement()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Users SET achiv4 = 1 WHERE Login = @username";
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
        private void ShowPreviousForm()
        {
            // Закрытие текущей формы
            this.Close();

            // Отображение предыдущей скрытой формы
            previousForm.Show();
        }
        public void FillField()
        {
            gr.Clear(Color.Black);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    if (field[i, j] == 1)
                    {
                        gr.FillRectangle(Brushes.Green, i * k, j * k, k, k);
                        gr.DrawRectangle(Pens.Black, i * k, j * k, k, k);
                    }
            for (int i = 0; i < 4; i++)
            {
                gr.FillRectangle(Brushes.Red, shape[1, i] * k, shape[0, i] * k, k, k);
                gr.DrawRectangle(Pens.Black, shape[1, i] * k, shape[0, i] * k, k, k);
            }
            FieldPictureBox.Image = bitfield;
        }
        private void TickTimer_Tick(object sender, System.EventArgs e)
        {
            if (field[8, 3] == 1)
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Users SET achiv4 = 1 WHERE Login = @username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username1);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок при выполнении запроса
                }
            if (FindMistake())
                {
                    for (int i = 0; i < 4; i++)
                        field[shape[1, i], --shape[0, i]]++;

                    if (CheckGameOver())
                    {
                        TickTimer.Enabled = false;
                        DialogResult result = MessageBox.Show("Вы проиграли. Хотите сыграть снова?", "Поражение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                            RestartGame();
                        else
                            ShowPreviousForm();
                    }
                    else
                    {
                        SetShape();
                    }
                }
            UpdateAchievement();
            for (int i = 0; i < 4; i++)
                shape[0, i]++;
            for (int i = height - 2; i > 2; i--)
            {
                var cross = (from t in Enumerable.Range(0, field.GetLength(0)).Select(j => field[j, i]).ToArray() where t == 1 select t).Count();
                if (cross == width)
                    for (int k = i; k > 1; k--)
                        for (int l = 1; l < width - 1; l++)
                            field[l, k] = field[l, k - 1];
            }
            if (FindMistake())
            {
                for (int i = 0; i < 4; i++)
                    field[shape[1, i], --shape[0, i]]++;
                SetShape();
            }
            FillField();
        }
        private bool CheckGameOver()
        {
            for (int i = 0; i < 4; i++)
            {
                if (shape[0, i] <= 1)
                    return true;
            }
            return false;
        }

        private void RestartGame()
        {
            // Сброс состояния игры
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i == 0 || i == width - 1 || j == height - 1)
                        field[i, j] = 1;
                    else
                        field[i, j] = 0;
                }
            }

            SetShape();
            TickTimer.Enabled = true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    for (int i = 0; i < 4; i++)
                        shape[1, i]--;
                    if (FindMistake())
                        for (int i = 0; i < 4; i++)
                            shape[1, i]++;
                    break;
                case Keys.D:
                    for (int i = 0; i < 4; i++)
                        shape[1, i]++;
                    if (FindMistake())
                        for (int i = 0; i < 4; i++)
                            shape[1, i]--;
                    break;
                case Keys.W:
                    var shapeT = new int[2, 4];
                    Array.Copy(shape, shapeT, shape.Length);
                    int maxx = 0, maxy = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (shape[0, i] > maxy)
                            maxy = shape[0, i];
                        if (shape[1, i] > maxx)
                            maxx = shape[1, i];
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        int temp = shape[0, i];
                        shape[0, i] = maxy - (maxx - shape[1, i]) - 1;
                        shape[1, i] = maxx - (3 - (maxy - temp)) + 1;
                    }
                    if (FindMistake())
                        Array.Copy(shapeT, shape, shape.Length);
                    break;
            }
        }
        public void SetShape()
        {
            Random x = new Random(DateTime.Now.Millisecond);
            switch (x.Next(7))
            {
                case 0: shape = new int[,] { { 2, 3, 4, 5 }, { 8, 8, 8, 8 } }; break;
                case 1: shape = new int[,] { { 2, 3, 2, 3 }, { 8, 8, 9, 9 } }; break;
                case 2: shape = new int[,] { { 2, 3, 4, 4 }, { 8, 8, 8, 9 } }; break;
                case 3: shape = new int[,] { { 2, 3, 4, 4 }, { 8, 8, 8, 7 } }; break;
                case 4: shape = new int[,] { { 3, 3, 4, 4 }, { 7, 8, 8, 9 } }; break;
                case 5: shape = new int[,] { { 3, 3, 4, 4 }, { 9, 8, 8, 7 } }; break;
                case 6: shape = new int[,] { { 3, 4, 4, 4 }, { 8, 7, 8, 9 } }; break;
            }
        }

      

        public bool FindMistake()
        {
            for (int i = 0; i < 4; i++)
                if (shape[1, i] >= width || shape[0, i] >= height ||
                    shape[1, i] <= 0 || shape[0, i] <= 0 ||
                    field[shape[1, i], shape[0, i]] == 1)
                    return true;
            return false;
        }

        private void TetrisGame_Load(object sender, EventArgs e)
        {
           
        }
    }
}
