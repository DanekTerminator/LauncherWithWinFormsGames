using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GameLauncherWinFormsGames
{
    public partial class Form2 : Form
    {
        // variables list for this quiz game
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;
        private MainMenu previousForm;


        public Form2(MainMenu form4)
        {
            InitializeComponent();

            askQuestion(questionNumber);

            totalQuestions = 5;
            previousForm = form4;
           
            this.StartPosition = FormStartPosition.CenterScreen;


        }

        private void ClickAnswerEvent(object sender, EventArgs e)
        {

            var senderObject = (System.Windows.Forms.Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);




            if (buttonTag == correctAnswer)
            {
                score++;


            }

            if (questionNumber == totalQuestions)
            {
                // work out the percentage here
                percentage = (int)Math.Round((double)(100 * score) / totalQuestions);


                MessageBox.Show("тестирование завершено!" + Environment.NewLine +
                                "Вы ответили верно на " + score + " вопросов" + Environment.NewLine +
                                "Ваш процент правильных ответов " + percentage + " %" + Environment.NewLine +
                                "Нажмите Ок чтобы пройти тестирование снова"

                    );

                score = 0;
                questionNumber = 0;

                askQuestion(questionNumber);
            }

            questionNumber++;

            askQuestion(questionNumber);



        }

        private void askQuestion(int qnum)
        {



            switch (qnum)
            {

                case 1:

                    pictureBox1.Image = Properties.Resources.sqlquest;
                    lblQuestion.Text = "Что делает этот код?";

                    button1.Text = "Обновляет таблицу, присваивая единицу полю achi5 пользователю с определённым логином \n записывает изменения и закрывает подключение";
                    button2.Text = "Обновляет таблицу и записывает изменения";
                    button3.Text = "Определяет подключение базы данных";
                    button4.Text = "Не знаю";

                    correctAnswer = 1;

                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.newForm;
                    lblQuestion.Text = "Какую страницу скрывает этот код и какую показывает?";

                    button1.Text = "Скрывает RaceGames и показывает formraces";
                    button2.Text = "Скрывает текущую и отображает formraces";
                    button3.Text = "Скрывает текущую и отображает formraces";
                    button4.Text = "Скрывает RaceGames и отображает RaceGames";

                    correctAnswer = 2;

                    break;

                case 3:

                    pictureBox1.Image = Properties.Resources.vsstudio;

                    lblQuestion.Text = "Кто является разработчиков Visual Studio?";

                    button1.Text = "EA";
                    button2.Text = "Activision";
                    button3.Text = "Square Enix";
                    button4.Text = "Microsoft";

                    correctAnswer = 4;

                    break;

                case 4:

                    pictureBox1.Image = Properties.Resources.issystem;

                    lblQuestion.Text = "Что такое информационная система?";

                    button1.Text = "Информационная система - это набор документов и файлов, содержащих информацию \n о различных аспектах деятельности организации.";
                    button2.Text = "Информационная система - это совокупность программного и аппаратного обеспечения, \n которые обрабатывают, хранят и передают информацию.";
                    button3.Text = "Информационная система - это процесс автоматизации бизнес-процессов \n с использованием компьютерных технологий.";
                    button4.Text = "Информационная система - это набор данных и информационных ресурсов, \n которые используются для принятия решений и поддержки операций в организации.";

                    correctAnswer = 2;

                    break;

                case 5:

                    pictureBox1.Image = Properties.Resources.languages;

                    lblQuestion.Text = "Назовите основной язык программирования Visual Studio";

                    button1.Text = "C#";
                    button2.Text = "Python";
                    button3.Text = "C++";
                    button4.Text = "HTML";

                    correctAnswer = 1;

                    break;

              




            }




        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }
    }
}
