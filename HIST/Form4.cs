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
    public partial class Form4 : Form
    {
        Boolean suceess = false;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string sql = "select Bfh as 病房号,RoomTypeName as 房间类型,PeopleNum as 可住人数,FactPeopleNum as 实际人数 from room ";
            dataGridView1.DataSource = c.updatesee(sql);
            groupBox1.Hide();
            groupBox2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string sql = "select Bfh as 病房号,RoomTypeName as 房间类型,PeopleNum as 可住人数,FactPeopleNum as 实际人数 from room where FactPeopleNum=0 ";
            dataGridView1.DataSource = c.updatesee(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string sql = "select Bfh as 病房号,RoomTypeName as 房间类型,PeopleNum as 可住人数,FactPeopleNum as 实际人数 from room where FactPeopleNum<PeopleNum  ";
            dataGridView1.DataSource = c.updatesee(sql);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (suceess == false)
            {
                groupBox1.Show();
                groupBox2.Show();
                suceess = true;
            }
            else
            {
                groupBox1.Hide();
                groupBox2.Hide();
                suceess = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string upda = string.Format(@"insert into room (Bfh,RoomTypeName,PeopleNum,FactPeopleNum) values('"+textBox1.Text.Trim()+"','"+comboBox1.Text.Trim()+"','"+comboBox2.Text.Trim()+"','"+comboBox3.Text.Trim()+"')");
            if (!c.update(upda)) {
               MessageBox.Show("输入值不对！");
               return;
           }
            string sql = "select Bfh as 病房号,RoomTypeName as 房间类型,PeopleNum as 可住人数,FactPeopleNum as 实际人数 from room ";
            dataGridView1.DataSource = c.updatesee(sql);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            string delete = string.Format(@"delete from room where Bfh='{0}'", dataGridView1.CurrentCell.Value);//获取当前dataGridView1活动的值
            if (!c.update(delete))
            {
                MessageBox.Show("删不掉！");
                return;
            }
            string sql = "select Bfh as 病房号,RoomTypeName as 房间类型,PeopleNum as 可住人数,FactPeopleNum as 实际人数 from room ";
            dataGridView1.DataSource = c.updatesee(sql);
        }

       
    }
}
