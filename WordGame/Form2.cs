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
    
    public partial class Form2 : Form
    {
        Form opener;
        Button [] buttons = new Button[30];
        Button [] buttons2 = new Button[30];

        String[] words = new String[5] { "SPECIAL", "UNIVERSITY", "TOWN", "CAT", "MOUSE" };
        int random = 0;
        int points = 0;
        int miss1 = 0;
        int finish = 0;

        public Form2(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
            GenerateWord();
        }

        public void GenerateWord()
        {        
            Random rnd = new Random();
            random = rnd.Next(0,5);
            finish = words[random].Length; 
            int positionX = 50;
            int postitionY = 46;

            for (int i = 0; i < words[random].Length; i++)
            {

                buttons[i] = new Button();
                buttons[i].Size = new Size(40, 40);
                buttons[i].Location = new Point(positionX, postitionY);

                string help = "";
                help += words[random][i];
                buttons[i].Text = help;
                help = "";

                buttons[i].Visible = false;


                buttons2[i] = new Button();
                buttons2[i].Size = new Size(40, 40);
                buttons2[i].Location = new Point(positionX, postitionY);
                buttons[i].Font = new Font("Tahoma", 12, FontStyle.Bold);
               

                positionX += 46;

                this.Controls.Add(buttons[i]);
                this.Controls.Add(buttons2[i]);
            }
        }
        private void Check(String letter)
        {
            bool test = true;
            for (int i=0; i < words[random].Length; i++)
            {
                
                if(buttons[i].Text==letter && buttons[i].Visible == false)
                {
                    
                    points++;
                    point.Text = "Points: " + points;
                    buttons2[i].Visible = false;
                    buttons[i].Visible = true;

                    if (finish == points)
                    {  
                        DialogResult result = MessageBox.Show("You Won!\n\nPoints: "+ points +
                            "\nMiss: "+miss1 +"\n\nWant to play again?", "Congratulation!", MessageBoxButtons.YesNo);
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
