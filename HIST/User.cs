using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIST
{
    //传值  用户名，密码
    class User
    {
        private static string name;
        private static string ysbh;
        private static string kes;
        private static string jzkh;

        public static void setName(string n)
        {
            name = n;
        }
        public static string getName()
        {
            return name;
        }

        public static void setYsbh(string Y)
        {
            ysbh = Y;
        }
        public static string get_Ysbh()
        {
            return ysbh;
        }
        public static void setKes(string k)
        {
            kes = k;
        }
        public static string getKes()
        {
            return kes;
        }
        public static void setJzkh(string j)
        {
            jzkh = j;
        }
        public static string getJzkh()
        {
            return jzkh;
        }
    }
}
