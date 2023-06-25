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
    public partial class CasualGames : Form
    {
        private MainMenu previousForm;
        private string usernamecurrentuser;
       
        public CasualGames(MainMenu form1, string usernamecurrentuser)
        {
            InitializeComponent();
            previousForm = form1;
            this.usernamecurrentuser = usernamecurrentuser;
            textBox1.Text = usernamecurrentuser;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Создание новой формы
            TetrisGame formtetrisgame = new TetrisGame(this,usernamecurrentuser);

            // Скрытие текущей формы
            this.Hide();

            // Отображение новой формы
            formtetrisgame.Show();
        }

        private void CasualGames_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
