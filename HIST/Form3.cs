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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string sql = "select Bah as 就诊卡号,Bfh as 病房号,name as 姓名,ysbh as 医生编号,kes as 科室,rysj as 入院时间 from ZYH";
            this.dataGridView1.DataSource = c.updatesee(sql);
        }
    }
}
