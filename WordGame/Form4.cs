using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordGame
{
    public partial class Form4 : Form
    {
        Button[] buttons = new Button[30];
        Button[] buttons2 = new Button[30];
        Form opener;
        String word = "";

        int points = 0;
        int miss1 = 0;
        decimal possibleMiss = 0;
        int finish = 0;
        
        public Form4(Form parentForm, String tekstToGuess, decimal possibleMissess)
        {
            InitializeComponent();
            opener = parentForm;
            word = tekstToGuess.ToUpper();
            possibleMiss = possibleMissess;
            GenerateWord();
        }
        

        public void GenerateWord()
        {
            finish = word.Length;
            int positionX = 50;
            int postitionY = 46;
            bool isit = false;
            for(int i=0; i<word.Length; i++)
            {
                if(word[i]==' ')
                {
                    isit = true;
                    break;
                }
            }
            //check
            if (word.Length > 19)
            {
                DialogResult result = MessageBox.Show("Word is too long. Maksimum 20 charcters\n\nWant to play again?", "Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    opener.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    Application.Exit();
                }
            }
            else if(isit==true)
            {
                DialogResult result = MessageBox.Show("Written tekst is is having space. Just one word!\n\nWant to play again?", "Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    opener.Show();            
                    this.Hide();
                    return;
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {


                for (int i = 0; i < word.Length; i++)
                {
                    buttons[i] = new Button();
                    buttons[i].Size = new Size(40, 40);
                    buttons[i].Location = new Point(positionX, postitionY);
                    buttons[i].Font = new Font("Tahoma", 12, FontStyle.Bold);

                    string help = "";
                    help += word[i];
                    buttons[i].Text = help;
                    help = "";

                    buttons[i].Visible = false;


                    buttons2[i] = new Button();
                    buttons2[i].Size = new Size(40, 40);
                    buttons2[i].Location = new Point(positionX, postitionY);



                    positionX += 46;

                    this.Controls.Add(buttons[i]);
                    this.Controls.Add(buttons2[i]);
                }
            }
        }
        private void Check(String letter)
        {
            bool test = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (buttons[i].Text == letter && buttons[i].Visible == false)
                {

                    points++;
                    point.Text = "Points: " + points;
                    buttons2[i].Visible = false;
                    buttons[i].Visible = true;

                    if (finish == points)
                    {
                        DialogResult result = MessageBox.Show("You Won!\n\nPoints: " + points +
                            "\nMiss: " + miss1 + "\n\nWant to play again?", "Congratulation!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            opener.Show();
                            this.Hide();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    test = false;
                }
            }
            if (test == true)
            {
                miss1++;
                miss.Text = "Miss: " + miss1;
                test = false;
                if(miss1==possibleMiss)
                {
                    DialogResult result = MessageBox.Show("You Lost!\nMiis:" + miss1+ "\n\nWord: " + word + "\n\nWant to play again?", "Lost!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        opener.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }

        }

        private void push(object sender, KeyPressEventArgs e)
        {
            string help = "";
            help += e.KeyChar;
            Check(help.ToUpper());
        }

        private void push2(object sender, MouseEventArgs e)
        {
            Check((sender as Button).Text);
        }
        private void closeApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
