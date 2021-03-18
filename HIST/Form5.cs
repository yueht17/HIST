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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            //创建窗体对象是为打印对话空间赋值
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.ShowHelp = true;      //是否显示帮助
            this.printDialog1.Document = this.printDocument1; //关联对话的打印控件
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.printDialog1.ShowDialog();         //打印对话框弹出窗口，返回结果
            if (result == DialogResult.OK)            //对话窗口确认则执行下面代码
            {
                this.printDocument1.DocumentName = "标签打印---";  //设置本次打印内容名称
                this.printDocument1.Print();              //开始打印。

            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font titleFont = new Font("宋体", 24, FontStyle.Underline);   //设置打印字体
            //以下为将字符串发送到打印区域，其实this.textBox1.Text，打印字符串内容，titleFont为打印字体，Brushes.Black 打印采用的颜色，两个数字分别为Y,X左边。该坐标为打印机提供的打印范围左上角起的相对坐标。
           // e.Graphics.DrawString(this.textBox1.Text, titleFont, Brushes.Black, 40, 40);
          



            // e.Graphics 各类打印内容的实现，如要实现图像打印可以用方法e.Graphics.DraoImage();其他详细的请参考MSDN。
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
                String sql = "select * from ZYH where Bah='" + textBox1.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand com = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox2.Text = dr.GetString(2);
                        textBox3.Text = dr.GetString(3);
                        textBox4.Text = dr.GetString(1);
                        dateTimePicker1.Value = dr.GetDateTime(6);
                       // textBox5.Text = dr.GetString(3);

                    }
                    if (textBox3.Text.Equals(""))
                    {
                        MessageBox.Show("无该病案号！");
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("无该病案号！ ");
                }
                finally
                {

                    con.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string sql = string.Format(@"delete from ZYH  where Bah='{0}'", textBox1.Text.Trim());
            string sel = string.Format(@"update room Set FactPeopleNum=FactPeopleNum-1 Where Bfh='{0}'", textBox4.Text.Trim());
            if (c.update(sql)) {
                MessageBox.Show("出院成功！");
            }
            if (c.update(sel)) { 
            }
        }
    }
}
