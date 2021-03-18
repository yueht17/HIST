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
    public partial class Form14 : Form
    {
        float sum = 0;
        public Form14()
        {
            InitializeComponent();
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
                dataGridView1.Show();
                Class1 c = new Class1();
                string sqll = string.Format(@"select name as 药品名称,danwei as 单位,jiage as 价格,shuliang as 数量, money as 小计 from bryp where Jzkh='{0}' ", textBox1.Text.Trim());
                this.dataGridView1.DataSource = c.updatesee(sqll);
                
               // this.listBox1.DataSource = c.updatesee(sqll);
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    sum = sum + float.Parse(c.updatesee(sqll).Rows[i]["小计"].ToString());
                    
                }
                textBox6.Text = sum.ToString();
            }
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = this.printDialog1.ShowDialog();         //打印对话框弹出窗口，返回结果
            if (result == DialogResult.OK)            //对话窗口确认则执行下面代码
            {
                this.printDocument1.DocumentName = "收复发票---";  //设置本次打印内容名称
                this.printDocument1.Print();              //开始打印。

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Class1 c = new Class1();
            
            string sqll = string.Format(@"select name as 药品名称,danwei as 单位,jiage as 价格,shuliang as 数量, money as 小计 from bryp where Jzkh='{0}' ", textBox1.Text.Trim());
            //this.dataGridView1.SelectAll();
            Font titleFont = new Font("宋体", 18, FontStyle.Underline);   //设置打印字体
            //以下为将字符串发送到打印区域，其实this.textBox1.Text，打印字符串内容，titleFont为打印字体，Brushes.Black 打印采用的颜色，两个数字分别为Y,X左边。该坐标为打印机提供的打印范围左上角起的相对坐标。
            //e.Graphics.DrawString("******************医院", titleFont, Brushes.Black, 240, 40);
            //e.Graphics.DrawString("______________________", titleFont, Brushes.Black, 240, 100);
            int  b = 560;
     
            e.Graphics.DrawString("*******************浙江中医药医院*******************", titleFont, Brushes.Black, 40, 40);
            e.Graphics.DrawString("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", titleFont, Brushes.Black, 40, 100);
            e.Graphics.DrawString(label1.Text, titleFont, Brushes.Black, 240, 140);
            e.Graphics.DrawString(this.textBox1.Text, titleFont, Brushes.Black, 350, 140);

            e.Graphics.DrawString(label2.Text, titleFont, Brushes.Black, 240, 200);
            e.Graphics.DrawString(this.textBox2.Text, titleFont, Brushes.Black, 350, 200);

            e.Graphics.DrawString(label3.Text, titleFont, Brushes.Black, 240, 260);
            e.Graphics.DrawString(this.textBox3.Text, titleFont, Brushes.Black, 350, 260);
            e.Graphics.DrawString(label4.Text, titleFont, Brushes.Black, 240, 320);
            e.Graphics.DrawString(this.textBox4.Text, titleFont, Brushes.Black, 310, 320);

            e.Graphics.DrawString(label5.Text, titleFont, Brushes.Black, 240, 380);
            e.Graphics.DrawString(this.textBox5.Text, titleFont, Brushes.Black, 350, 380);

            e.Graphics.DrawString("时间：", titleFont, Brushes.Black, 240, 440);
            e.Graphics.DrawString(DateTime.Now.ToString(), titleFont, Brushes.Black, 310, 440);
            e.Graphics.DrawString("药品名称      单位     价格      数量    小计", titleFont, Brushes.Black, 40, 500);
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                e.Graphics.DrawString(c.updatesee(sqll).Rows[i]["药品名称"].ToString(), titleFont, Brushes.Black, 40, b);
                e.Graphics.DrawString(c.updatesee(sqll).Rows[i]["单位"].ToString(), titleFont, Brushes.Black, 220, b);
                e.Graphics.DrawString(c.updatesee(sqll).Rows[i]["价格"].ToString(), titleFont, Brushes.Black, 330, b);
                e.Graphics.DrawString(c.updatesee(sqll).Rows[i]["数量"].ToString(), titleFont, Brushes.Black, 470, b);
                e.Graphics.DrawString(c.updatesee(sqll).Rows[i]["小计"].ToString(), titleFont, Brushes.Black, 570, b);
                b = b + 100;
             
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox8.Text = ( float.Parse(textBox7.Text.Trim().ToString())-sum).ToString();
            string sql = string.Format(@"update gh Set zt ='{0}'Where Jzkh='{1}'", "已付费，正在取药", textBox1.Text.Trim()) ;
            Class1 c = new Class1();
            if (!c.update(sql))
            {
                MessageBox.Show("未完成！");
                return;
            }
        }
    }
}
