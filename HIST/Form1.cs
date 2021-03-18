using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

       

       
        

        private void 入院登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 病房管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.WindowState = FormWindowState.Maximized;//使子窗体最大化
            f.MdiParent = this;
            f.Show();
        }

      

        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
           // f.WindowState = FormWindowState.Maximized;
           // f.MdiParent = this;
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "浙江中医医药大学出品";
            this.toolStripStatusLabel2.Text = "护士编号：" + User.get_Ysbh();
            this.toolStripStatusLabel3.Text = "用户：" + User.getName();
            this.toolStripStatusLabel4.Text = "科室：" + User.getKes();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel5.Text = DateTime.Now.ToString();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.WindowState = FormWindowState.Maximized;//使子窗体最大化
            f.MdiParent = this;
            f.Show();
        }

        private void 返回登录界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Hide();
        }

       
    }
}
