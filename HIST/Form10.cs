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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

      

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.comboBox1.Focus();
                string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
                String sql = "select  * from jzkh where jzkh='" + textBox2.Text + "'";
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
                        textBox6.Text = dr.GetString(6);
                        textBox7.Text = dr.GetString(7);
                        
                    }
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("无该就诊卡号！ ");
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

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
            SqlConnection con = new SqlConnection(conn);
            try
            {
                con.Open();
                string sel = string.Format("select name From ys where kes='{0}'", comboBox1.SelectedItem);
                SqlDataAdapter da = new SqlDataAdapter(sel, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "cheng");
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "name";
                comboBox2.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ea) {
                Console.WriteLine(ea);
                MessageBox.Show("重新选择科室！");

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Equals("普通")) 
            {
                textBox1.Text = "3";

            } 
            if (comboBox3.Text.Equals("专家"))
            {
                textBox1.Text = "5";

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = this.printDialog1.ShowDialog();         //打印对话框弹出窗口，返回结果
            if (result == DialogResult.OK)            //对话窗口确认则执行下面代码
            {
                this.printDocument1.DocumentName = "挂号发票---";  //设置本次打印内容名称
                this.printDocument1.Print();              //开始打印。

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font titleFont = new Font("宋体", 18, FontStyle.Underline);   //设置打印字体
            //以下为将字符串发送到打印区域，其实this.textBox1.Text，打印字符串内容，titleFont为打印字体，Brushes.Black 打印采用的颜色，两个数字分别为Y,X左边。该坐标为打印机提供的打印范围左上角起的相对坐标。
            e.Graphics.DrawString("******************医院", titleFont, Brushes.Black, 240, 40);
            e.Graphics.DrawString("______________________", titleFont, Brushes.Black, 240, 100);
            e.Graphics.DrawString(label1.Text, titleFont, Brushes.Black, 240, 140);
            e.Graphics.DrawString(this.textBox2.Text, titleFont, Brushes.Black, 350, 140);

            e.Graphics.DrawString(label2.Text, titleFont, Brushes.Black, 240, 200);
            e.Graphics.DrawString(this.textBox3.Text, titleFont, Brushes.Black, 350, 200);

            e.Graphics.DrawString(label3.Text, titleFont, Brushes.Black, 240, 260);
            e.Graphics.DrawString(this.textBox4.Text, titleFont, Brushes.Black, 310, 260);
            e.Graphics.DrawString(label4.Text, titleFont, Brushes.Black, 240, 320);
            e.Graphics.DrawString(this.textBox5.Text, titleFont, Brushes.Black, 310, 320);
           
            e.Graphics.DrawString(label10.Text, titleFont, Brushes.Black, 240, 380);
            e.Graphics.DrawString(this.comboBox3.Text, titleFont, Brushes.Black, 310,380);

            e.Graphics.DrawString(label7.Text, titleFont, Brushes.Black, 240, 440);
            e.Graphics.DrawString(this.comboBox1.Text, titleFont, Brushes.Black, 310, 440);

            e.Graphics.DrawString(label8.Text, titleFont, Brushes.Black, 240, 500);
            e.Graphics.DrawString(this.comboBox2.Text, titleFont, Brushes.Black, 310, 500);

            e.Graphics.DrawString(label9.Text, titleFont, Brushes.Black, 240, 540);
            e.Graphics.DrawString(this.textBox1.Text, titleFont, Brushes.Black, 350, 540);

            e.Graphics.DrawString("时间：", titleFont, Brushes.Black, 240, 600);
            e.Graphics.DrawString(DateTime.Now.ToString(), titleFont, Brushes.Black, 310, 600);


            
            // e.Graphics 各类打印内容的实现，如要实现图像打印可以用方法e.Graphics.DraoImage();其他详细的请参考MSDN。
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox2.Text.Trim();
            string b = textBox3.Text.Trim();
            string c = textBox4.Text.Trim();
            string d = textBox5.Text.Trim();
            string ee=comboBox3.Text.Trim();
            string f = comboBox1.Text.Trim();
            string g = comboBox2.Text.Trim();
            string h = "等待看病！";
            string i = DateTime.Now.ToLongDateString();
            if (a.Equals("") || b.Equals("") || c.Equals("") || d.Equals("") || ee.Equals("") || f.Equals("") || g.Equals("") )
            {
                MessageBox.Show("信息必须填完整！");
                return;
            }
            string sql = "insert into gh values('" + a + "','" + b + "','" + c + "','" + d + "','" + ee + "','" + f + "','" + g + "','"+h+"','"+i+"')";
            Class1 cl = new Class1();
            if (!cl.update(sql))
            {
                MessageBox.Show("该就诊卡号已挂号！");
            }
            else
            {
                MessageBox.Show("挂号成功！");
            }

        }
    }
}
