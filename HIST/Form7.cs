using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIST
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Opacity = 200;
            timer1.Enabled = true;
            progressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.01)
            {
                this.Opacity = this.Opacity - 0.05;
                progressBar1.Value = progressBar1.Value + 5;
            }
            else
            {
                this.timer1.Enabled = false;
                //this.Close();
                Form8 m = new Form8();
                m.Show();
                this.Hide();
                

            }
            
        }
    }
}
