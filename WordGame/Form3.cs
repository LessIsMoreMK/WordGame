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
    
    public partial class Form3 : Form
    {
        Form opener;
        public Form3(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }

        private void multipleStartt(object sender, EventArgs e)
        {
            Form4 multipleFormm = new Form4(opener, text.Text, number.Value);
            
                
            multipleFormm.Show();
            this.Hide();
        }
        private void closeApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

}
