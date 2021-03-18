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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text.Trim();
            string b = textBox2.Text.Trim();
            string c = textBox3.Text.Trim();
            string d = textBox4.Text.Trim();
            string eee = textBox5.Text.Trim();
            //string f = textBox6.Text.Trim();
            string g = textBox7.Text.Trim();
            DateTime h = dateTimePicker1.Value;
            string i = textBox8.Text.Trim();
            string j = textBox9.Text.Trim();
            if (a.Equals("") || b.Equals("") || c.Equals("") || 
                eee.Equals("")|| h.Equals("")||i.Equals("")||j.Equals("")||d.Equals("")){
                    MessageBox.Show("请将病人信息填完整！", "提示");
                    return;
            }

            string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
            string sql = "insert into ZYH(Jzkh,Bfh,name,kes,ysbh,zd,rysj,bz,Bah)values('" + a + "','" + b + "','" + i + "','" + j + "','" + c + "','"+eee+"','" + h + "','" + g + "','"+d+"')";
           // string sql = "insert into zy(Bah,Bcf,)values('" + a + "','"+ b +"','"+ h +"')";
            string sel = string.Format(@"update room Set FactPeopleNum=FactPeopleNum+1 Where Bfh='{0}'", textBox2.Text.Trim());
            string s = string.Format(@"select count(*) from room where Bfh='{0}'", textBox2.Text.Trim());
            SqlConnection con = new SqlConnection(conn);
            SqlCommand com = new SqlCommand(sql, con);
            Class1 clas=new Class1();
            if (clas.login(s) == 0) {
                MessageBox.Show("没有该病房号");
                return;
            }
            if (!clas.update(sel))
            {
                MessageBox.Show("该病房已满");
                return; 
            }
            try
            {
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("登记成功！");
                

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                MessageBox.Show("已注册!");
            }
            finally
            {

                con.Close();

            }
         }

        private void button3_Click(object sender, EventArgs e)
        {
            string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
            String sql = "select * from BAH where Jzkh='" + textBox1.Text + "'";
            SqlConnection con = new SqlConnection(conn);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    textBox8.Text = dr.GetString(1);
                    textBox9.Text = dr.GetString(6);
                    textBox3.Text = dr.GetString(4);
                    textBox5.Text = dr.GetString(3);
                   
                }
                if(textBox3.Text.Equals("")){
                    MessageBox.Show("该就诊卡未挂号！");
                }
             }
            catch (Exception ex)
            {
                Console.Write(ex);
                MessageBox.Show("该就诊卡未挂号！ ");
            }
            finally
            {

                con.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             textBox1.Text = "";
             textBox2.Text = "";
             textBox3.Text = "";
             //textBox4.Text = "";
             textBox5.Text = "";
             //textBox6.Text = "";
             textBox7.Text = "";
             textBox8.Text = "";
             textBox9.Text = "";

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       

      

      
                
            
    }
}
