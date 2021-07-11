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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void singleStart(object sender, MouseEventArgs e)
        {
            Form2 singleForm = new Form2(this);

            singleForm.Show();
            this.Hide();

        }

        private void multipleStart(object sender, MouseEventArgs e)
        {
            Form3 multipleForm = new Form3(this);

            multipleForm.Show();
            this.Hide();
        }
    }
}
