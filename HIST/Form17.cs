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
    public partial class Form17 : Form
    {

        public Form17()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.comboBox1.Focus();
                string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
                String sql = "select  * from gh where jzkh='" + textBox1.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand com = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {

                        textBox2.Text = dr.GetString(1);
                        textBox3.Text = dr.GetString(4);
                        textBox4.Text = dr.GetString(5);
                        textBox5.Text = dr.GetString(6);



                    }
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("无该就诊卡号或者该就诊卡号未挂号！ ");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("无该就诊卡号！ ");
                    return;
                }
                finally
                {

                    con.Close();

                }
                Class1 c = new Class1();
                string sqll = string.Format(@"select name as 药品名称,danwei as 单位,jiage as 价格,shuliang as 数量, money as 小计 from bryp where Jzkh='{0}' ", textBox1.Text.Trim());
                this.dataGridView1.DataSource = c.updatesee(sqll);
                dataGridView1.Show();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string sqll = string.Format(@"select name as 药品名称,danwei as 单位,jiage as 价格,shuliang as 数量, money as 小计 from bryp where Jzkh='{0}' ", textBox1.Text.Trim());
            this.dataGridView1.DataSource = c.updatesee(sqll);
            Boolean success = false;
               
               
            // this.listBox1.DataSource = c.updatesee(sqll);
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            { 
               string name= c.updatesee(sqll).Rows[i]["药品名称"].ToString();
               int number=int.Parse(c.updatesee(sqll).Rows[i]["数量"].ToString());
               string sql= string.Format(@"update yp Set shuliang =shuliang-'{0}'Where name='{1}'", number, name);
               if (!c.update(sql))
               {
                   MessageBox.Show("系统问题！");

               }
               else {
                   success = true;
               }
                
            }
            if (success) 
            {
                MessageBox.Show("发药成功！");
            }
            this.dataGridView1.Hide();
            string sqlll = string.Format(@"delete from bryp where Jzkh='{0}'", textBox1.Text.Trim());
            if (c.update(sqlll)) { 
               
            }
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            
            this.dataGridView1.Hide();
        }
    }
}
