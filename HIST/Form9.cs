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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void 挂号收复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void 制卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void 药品收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
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

        private void 返回主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Hide();
        }
    }
}
