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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            //textBox2.text;
            label4.Text = CreateRandomCode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("")||textBox2.Text.Equals("")||textBox3.Text.Equals("")){
                MessageBox.Show("帐号，口令，验证码不能为空！");
                return;
            }
            if (radioButton1.Checked == true)
            {
                User user = new User();
                string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
                string sql = "select * from ys where Ysbh='" + textBox1.Text + "'and name='" + textBox2.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand com = new SqlCommand(sql, con);
                Boolean ok = false;
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        User.setYsbh(dr.GetString(0));
                        User.setName(dr.GetString(1));
                        User.setKes(dr.GetString(2));
                        if (textBox3.Text.Equals(label4.Text))
                        {
                            ok = true;
                        }
                        else {
                            MessageBox.Show("验证码错误！");
                        }
                    }
                    if (ok)
                    {
                        Form12 f = new Form12();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不对！");
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("系统问题！ ");
                }
                finally
                {

                    con.Close();

                }
            }
            if (radioButton2.Checked == true)
            {
                User user = new User();
                string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
                string sql = "select * from hs where Hsbh='" + textBox1.Text + "'and name='" + textBox2.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand com = new SqlCommand(sql, con);
                Boolean ok = false;
                string a="";
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        User.setYsbh(dr.GetString(0));
                        User.setName(dr.GetString(1));
                        User.setKes(dr.GetString(2));
                        a = dr.GetString(3);
                        if (textBox3.Text.Equals(label4.Text))
                        {
                            ok = true;
                        }
                        else
                        {
                            MessageBox.Show("验证码错误！");
                            return;
                        }
                    }
                    if (ok&&a.Equals("1"))
                    {
                        Form9 f = new Form9();
                        f.Show();
                        this.Hide();
                        return;
                    }
                    if (ok && a.Equals("0"))
                    {
                        Form1 f = new Form1();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不对！");
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("系统问题！ ");
                }
                finally
                {

                    con.Close();

                }
            }
            if (radioButton3.Checked == true)
            {
                User user = new User();
                string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
                string sql = "select * from hs where Hsbh='" + textBox1.Text + "'and name='" + textBox2.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand com = new SqlCommand(sql, con);
                Boolean ok = false;
                string a = "";
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        User.setYsbh(dr.GetString(0));
                        User.setName(dr.GetString(1));
                        User.setKes(dr.GetString(2));
                        a = dr.GetString(3);
                        if (textBox3.Text.Equals(label4.Text))
                        {
                            ok = true;
                        }
                        else
                        {
                            MessageBox.Show("验证码错误！");
                            return;
                        }
                    }
                    if (ok&&a.Equals("0"))
                    {
                        Form1 f = new Form1();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不对！");
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("系统问题！ ");
                }
                finally
                {

                    con.Close();

                }
            }
            if (radioButton4.Checked == true)
            {
                User user = new User();
                string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
                string sql = "select * from yaofang where id='" + textBox1.Text + "'and name='" + textBox2.Text + "'";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand com = new SqlCommand(sql, con);
                Boolean ok = false;
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        User.setYsbh(dr.GetString(0));
                        User.setName(dr.GetString(1));
                        User.setKes(dr.GetString(2));
                        if (textBox3.Text.Equals(label4.Text))
                        {
                            ok = true;
                        }
                        else
                        {
                            MessageBox.Show("验证码错误！");
                        }
                    }
                    if (ok)
                    {
                        Form15 f = new Form15();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不对！");
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("系统问题！ ");
                }
                finally
                {

                    con.Close();

                }
            }
        }
        private string CreateRandomCode()
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return CreateRandomCode();
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.Text = CreateRandomCode();
        }
    }
}
