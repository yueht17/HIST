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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string sql = string.Format(@"select name as 药品名称,danwei as 单位,jiage as 价格,shuliang as 数量, money as 小计 from bryp where Jzkh='{0}' ", User.getJzkh());
            this.dataGridView1.DataSource = c.updatesee(sql);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        } 
    }
}
