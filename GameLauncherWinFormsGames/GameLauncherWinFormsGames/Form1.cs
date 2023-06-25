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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ButtonCasual.Text = "Казуальные";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCasual_Click(object sender, EventArgs e)
        {
            // Создание новой формы
            CasualGames formcasual = new CasualGames(this);

            // Скрытие текущей формы
            this.Hide();

            // Отображение новой формы
            formcasual.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Races_Click(object sender, EventArgs e)
        {

        }
    }
}
