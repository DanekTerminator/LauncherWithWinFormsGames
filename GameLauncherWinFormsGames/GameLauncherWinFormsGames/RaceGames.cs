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
    public partial class RaceGames : Form
    {
        private MainMenu previousForm;
        private string username1;
        public RaceGames(MainMenu form1, string usernamecurrentuser)
        {
            InitializeComponent();
            previousForm = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.username1 = usernamecurrentuser;
        }

        private void RaceGames_Load(object sender, EventArgs e)
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
            SurviveRaceGame formSurviveRace = new SurviveRaceGame(username1);

           
            

            // Отображение новой формы
            formSurviveRace.Show();
        }
    }
}
