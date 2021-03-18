using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HIST
{
    class Class1
    {
        DataSet ds;
        public DataTable updatesee(string sql)
        {
            string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
            SqlConnection con = new SqlConnection(conn);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds, " Room");

            }
            catch (Exception e)
            {
                Console.Write(e);
                MessageBox.Show("系统问题：Class1","提示");
            }
            finally
            {

                con.Close();

            }
            return ds.Tables[0];
         }
        public int login(string sql)
        {
            int a = 0;
            string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
            SqlConnection con = new SqlConnection(conn);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                con.Open();

               Object o = com.ExecuteScalar();
               a = Convert.ToInt32(o);   

            }
            catch (Exception e)
            {
                Console.Write(e);
                MessageBox.Show("系统问题：登录", "提示");
                
            }
            finally
            {

                con.Close();

            }
            return a;
        }
        public Boolean update(string sql)
        {
          Boolean suceess=false;  
            string conn = "Data Source = .; Initial Catalog = his;uid=sa;pwd=123456";
            SqlConnection con = new SqlConnection(conn);
            SqlCommand com = new SqlCommand(sql, con);
            try
            {
                con.Open();
                if (com.ExecuteNonQuery() == 0) {
                    suceess = false;
                }
                suceess = true;

            }
            catch (Exception e)
            {
               // MessageBox.Show("系统问题：更新", "提示");
                suceess = false;
                Console.Write(e);
            }
            finally
            {
               
                con.Close();

            }
            return suceess;
        }
     }
   
}
