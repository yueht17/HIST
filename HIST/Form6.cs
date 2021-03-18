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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

       

        private void 普通饭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox4.Hide();
            listBox3.Hide();
            listBox2.Hide();
            listBox1.Show();
            //listBox1.Items.Add("1.适用范围：病情较轻无发热和无消化道疾患，疾病恢复期及不");
            //listBox1.Items.Add("           必限制饮食者.");
            //listBox1.Items.Add("2.饮食原则：营养素平衡美观可口易消化无刺激性的一般食物均");
            //listBox1.Items.Add("            可采用。但油煎，胀气食物及强烈调味品应限制.");
            //listBox1.Items.Add("3.用法：每日三次，每日总热量2200-2600千卡.");
            
        }

        private void 软质膳食ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox4.Hide();
            listBox3.Hide();
            listBox2.Show();
            listBox1.Hide();
            //listBox2.Items.Add("1.适用范围：消化不良低热咀嚼不便，老幼病员和术后恢复期阶段.");
            //listBox2.Items.Add("           必限制饮食者");
            //listBox2.Items.Add("2.饮食原则：营养素平衡美观可口易消化无刺激性的一般食物均可采");
            //listBox2.Items.Add("            用.但油煎，胀气食物及强烈调味品应限制，要求以软烂");
            //listBox2.Items.Add("            为主食，如软饭面条菜肉均应切碎煮烂，易于咀嚼消化.");
            //listBox2.Items.Add("3.用法：每日三次，每日总热量2200-2600千卡.");
        }

        private void 半流质膳食ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox4.Hide();
            listBox3.Show();
            listBox2.Hide();
            listBox1.Hide();
            //listBox3.Items.Add("1.适用范围：发热体弱消化道疾患，口腔疾病，咀嚼不便，手术后和");
            //listBox3.Items.Add("            消化不良等病员.");
            //listBox3.Items.Add("2.饮食原则：少食多餐，无刺激性易于咀嚼及吞咽纤维素含量少，营");
            //listBox3.Items.Add("            养丰富食物呈半流质状，如粥、面条、馄饨、蒸鸡蛋等.");
            //listBox3.Items.Add("3.用法：每日5次，每日总热量1500～2000千卡.");
        }

        private void 流质膳食ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox4.Show();
            listBox3.Hide();
            listBox2.Hide();
            listBox1.Hide();
            //listBox4.Items.Add("1.适用范围：病情严重，高热、吞咽困难、口腔疾患、术后和急性消");
            //listBox4.Items.Add("            化道疾患等病员.");
            //listBox4.Items.Add("2.饮食原则：用液状食物，如乳类、豆浆、米汤、肉汁、菜汁、果汁");
            //listBox4.Items.Add("            等.因所含热量及营养素不足，故只能短期使用.");
            //listBox4.Items.Add("3.用法：每日6－7次每2－3小时一次，每日约200～300ml，每日");
            //listBox4.Items.Add("        总热量在1200～1400千卡.");
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listBox4.Hide();
            listBox3.Hide();
            listBox2.Hide();
            listBox1.Hide();
            Class1 c = new Class1();
            string sqll = "select Bah as 病案号,Type as 膳食类型,time as 订餐日期 from dingcan ";
            dataGridView1.DataSource = c.updatesee(sqll);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            //DateTime date = DateTime.Parse(dateTimePicker1.Text);
            //textBox3.Text = date.Hour.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text.Trim();
            string b = comboBox1.Text.Trim();
            DateTime c = dateTimePicker1.Value;
            if (a.Equals("") || b.Equals("") || c.Equals("")) {
                MessageBox.Show("信息必须填完整！");
                return;
            }
            Class1 cc = new Class1();
            string sql = "insert into dingcan(Bah,Type,time)values('" + a + "','" + b + "','" + c + "')";
            string sqll = "select Bah as 病案号,Type as 膳食类型,time as 订餐日期 from dingcan ";
            if (cc.update(sql))
            {
                MessageBox.Show("订餐成功！");
            }
            else
            {
                MessageBox.Show("没成功！");
            }
            dataGridView1.DataSource = cc.updatesee(sqll);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string a = textBox1.Text.Trim();
            DateTime b = dateTimePicker1.Value;
            
             string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
             string sql = string.Format(@"select * from dingcan where Bah={0}", dataGridView1.CurrentCell.Value);
             SqlConnection con = new SqlConnection(conn);
             SqlCommand com = new SqlCommand(sql, con);
             Class1 cc = new Class1();
             string sqll = "select Bah as 病案号,Type as 膳食类型,time as 订餐日期 from dingcan ";
            
            try {
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    int sum = 0;
                    DateTime d = dr.GetDateTime(2);
                    string type = dr.GetString(1);
                    TimeSpan c = Convert.ToDateTime(b) - Convert.ToDateTime(d);
                    int f = Convert.ToInt32(c.Days);

                    //textBox2.Text = f.ToString();
                    DateTime date = DateTime.Parse(dateTimePicker1.Text);
                    //if (date.Hour < 11)
                    //{
                    //    if (type.Equals("普通饭"))
                    //    {
                    //        sum = 15 * (f - 1);
                    //    }
                    //    if (type.Equals("软质膳食"))
                    //    {
                    //        sum = 20 * (f - 1);

                    //    }
                    //    if (type.Equals("半流质膳食"))
                    //    {
                    //        sum = 25 * (f - 1);
                    //    }
                    //    if (type.Equals("流质膳食"))
                    //    {
                    //        sum = 30 * (f - 1);
                    //    }
                   // }
                    
                    
                        if (type.Equals("普通饭"))
                        {
                            sum = 15 * f ;
                        }
                        if (type.Equals("软质膳食"))
                        {
                            sum = 20 * f;

                        }
                        if (type.Equals("半流质膳食"))
                        {
                            sum = 25 * f;
                        }
                        if (type.Equals("流质膳食"))
                        {
                            sum = 30 * f;
                        }
                    
                    //textBox3.Text = sum.ToString();
                }
            }catch(Exception ee){
                MessageBox.Show("?");
                return;
            }
            string delete = string.Format(@"delete from dingcan where Bah='{0}'", dataGridView1.CurrentCell.Value);//获取当前dataGridView1活动的值
            if (!cc.update(delete))
            {
                MessageBox.Show("删不掉！");
                return;
            }
            dataGridView1.DataSource = cc.updatesee(sqll);
        }
    }
}
