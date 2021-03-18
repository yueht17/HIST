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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "浙江中医医药大学出品";
            this.toolStripStatusLabel2.Text = "医生编号：" + User.get_Ysbh();
            this.toolStripStatusLabel3.Text = "用户：" + User.getName();
            this.toolStripStatusLabel4.Text = "科室：" + User.getKes();
            //splitter1.Hide();
            
            panel2.Hide();
            panel3.Hide();
            textBox11.Hide();
            //this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//设置为整行被选中



        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.comboBox1.Focus();
                string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
                String sql = "select  * from gh where jzkh='" + textBox2.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand com = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {

                        textBox3.Text = dr.GetString(1);
                        textBox4.Text = dr.GetString(2);
                        textBox5.Text = dr.GetString(3);
                        if (!dr.GetString(6).Equals(User.getName())) {
                            MessageBox.Show("病人与医生不对口！");
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            return;

                        };
                        

                    }
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("无该就诊卡号或者该就诊卡号未挂号！ ");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("无该就诊卡号！ ");
                }
                finally
                {

                    con.Close();

                }
            }
        }

        private void 显示当日病人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18 f = new Form18();
            f.Show();
           
           
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Class1 c = new Class1();
                string sql = string.Format(@"select name as 疾病名称 from jb where piny like'{0}%' ", textBox7.Text.Trim());
                this.dataGridView2.DataSource = c.updatesee(sql);
                panel2.Show();
                //groupBox2.Hide();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView2.CurrentCell.Value.ToString();
            panel2.Hide();
            //groupBox2.Show();
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panel3.Show();
                Class1 c = new Class1();
                string sql = string.Format(@"select name as 药品名称,jix as 剂型,danwei as 单位,jiage as 价格,shuliang as 库存 from yp where piny like'{0}%' ", textBox8.Text.Trim());
                this.dataGridView3.DataSource = c.updatesee(sql);
                panel2.Show();
                //groupBox2.Hide();
                //groupBox3.Hide();
                
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            string f = textBox2.Text.Trim();
            string a = textBox8.Text.Trim();
            string b = textBox9.Text.Trim();
            string c = textBox10.Text.Trim();
            string d = comboBox1.Text.Trim();
            string ee = textBox11.Text.Trim();
            float m = float.Parse(b) * float.Parse(ee);
            if (a.Equals("") || b.Equals("") || c.Equals("") || d.Equals(""))
            {
                MessageBox.Show("信息必须填完整！");
                return;
            }
            string sql = "insert into bryp values('" + f + "','" + a + "','" + b + "','" + c + "','" + ee + "','" + m + "','" + d + "')";
            Class1 cl = new Class1();
            if (!cl.update(sql))
            {
                MessageBox.Show("未加药");
            }
            else
            {
                MessageBox.Show("加药成功！");
                textBox8.Text="";
                textBox9.Text="";
                textBox10.Text="";
                comboBox1.Text="";
                textBox11.Text="";

            }


        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView3.CurrentRow.Cells["药品名称"].Value.ToString();
            textBox10.Text = dataGridView3.CurrentRow.Cells["单位"].Value.ToString();
            textBox11.Text = dataGridView3.CurrentRow.Cells["价格"].Value.ToString();
            panel3.Hide();
            panel2.Hide();
           // groupBox3.Show();
            //groupBox2.Show();
        }

        private void 查看此病人药品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.setJzkh(textBox2.Text);
            Form13 f = new Form13();
            f.Show();
        }

        private void 完成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a = textBox2.Text.Trim();
            string b = textBox3.Text.Trim();
            string c = textBox1.Text.Trim();
            string d = textBox6.Text.Trim();
            string sql = "insert into BAH values('" + a + "','" + b + "','" + c + "','" + d + "','" + User.get_Ysbh() + "','" + User.getName() + "','" + User.getKes() + "')";
            string sqll=string.Format(@"update gh Set zt ='{0}'Where Jzkh='{1}'", "已看完病",textBox2.Text.Trim());
            Class1 cl = new Class1();
            if (!cl.update(sql))
            {
                MessageBox.Show("未完成！");
                return;
            }
            else
            {
                MessageBox.Show("看病完成");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Text = "";
                //comboBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                if (!cl.update(sqll))
                {
                    MessageBox.Show("未完成！");
                    return;
                }

            }

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
