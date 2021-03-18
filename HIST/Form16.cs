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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.comboBox1.Focus();

                String sql = "select id as 药品编号, name as 药品名称,jix as 剂型,danwei as 单位,jiage as 价格,shuliang as 库存 from yp where shuliang<='" + textBox1.Text + "'";
                Class1 c = new Class1();
                this.dataGridView1.DataSource = c.updatesee(sql);
                
            }
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            string sql = "select id as 药品编号, name as 药品名称,jix as 剂型,danwei as 单位,jiage as 价格,shuliang as 库存 from yp ";
            Class1 c = new Class1();
            this.dataGridView1.DataSource = c.updatesee(sql);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            string sql = string.Format(@"select id as 药品编号, name as 药品名称,jix as 剂型,danwei as 单位,jiage as 价格,shuliang as 库存 from yp where piny like'{0}%'",textBox5.Text.Trim());
            Class1 c = new Class1();
            this.dataGridView1.DataSource = c.updatesee(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16_Load(sender,e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells["药品名称"].Value.ToString();
            //textBox3.Text = dataGridView1.CurrentRow.Cells["库存"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["单位"].Value.ToString();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Equals("") || textBox3.Equals("") )
            {
                MessageBox.Show("必须填写药品名称和药品数量！");
                return;
            }
            int a = int.Parse(textBox3.Text);
            string sqll = string.Format(@"update yp Set shuliang =shuliang+'{0}'Where name='{1}'", a, textBox2.Text.Trim());
            Class1 c=new Class1();
            if (!c.update(sqll)) {
                MessageBox.Show("系统故障");
                return;
            }
            MessageBox.Show("入药成功！");
        }
    }
}
