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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void 入药ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void 药房发药ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f = new Form17();
            f.WindowState = FormWindowState.Maximized;
            f.MdiParent = this;
            f.Show();
        }

        private void 返回主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Hide();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "浙江中医医药大学出品";
            this.toolStripStatusLabel2.Text = "工作人员编号：" + User.get_Ysbh();
            this.toolStripStatusLabel3.Text = "用户：" + User.getName();
            this.toolStripStatusLabel4.Text = "科室：" + User.getKes();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel5.Text = DateTime.Now.ToString();
        }
    }
}
