using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLauncherWinFormsGames
{
    public partial class ShooterGames : Form
    {
        private MainMenu previousForm;
        public ShooterGames(MainMenu form1)
        {
            InitializeComponent();
            previousForm = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Создание новой формы
            ZombieShooterGame formZombie = new ZombieShooterGame();

            // Скрытие текущей формы
           // this.Hide();

            // Отображение новой формы
            formZombie.Show();
        }

        private void ShooterGames_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }
    }
}
