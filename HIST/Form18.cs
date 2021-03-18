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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string sql = string.Format(@"select Jzkh as 就诊卡号,name as 姓名,zt as 状态,kes as 科室,doctor as 医生,time as 日期 from gh where doctor='{0}' and time='{1}'", User.getName(), DateTime.Now.ToLongDateString());
            this.dataGridView1.DataSource = c.updatesee(sql);
        }
    }
}
