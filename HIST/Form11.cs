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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text.Trim();
            string b = textBox2.Text.Trim();
            string c = comboBox1.Text.Trim();
            string d = textBox3.Text.Trim();
            string ee = textBox4.Text.Trim();
            string f = textBox5.Text.Trim();
            string g = textBox6.Text.Trim();
            string h= textBox7.Text.Trim();
            if (a.Equals("") || b.Equals("") || c.Equals("") || d.Equals("") || ee.Equals("") || f.Equals("") || g.Equals("") || h.Equals("")) 
            {
                MessageBox.Show("信息必须填完整！");
                return ;
            }
            string sql = "insert into jzkh values('" + a + "','" + b + "','" + c + "','" + d + "','" + g + "','" + h+ "','" + ee + "','" + f + "')";
            Class1 cl = new Class1();
            if (!cl.update(sql))
            {
                MessageBox.Show("已有该就诊卡号！");
            }
            else
            {
                MessageBox.Show("注册成功！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            
        }
    }
}
