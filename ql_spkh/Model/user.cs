using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_spkh.Model
{
    public static class user
    {
        public static int userid = -1;
        public static string username;
        public static string fullname;
        public static string email;
        public static string address;
        public static string phone;
        public static string password;
        public static int role;

        /*public user(int userid,string username, string fullname, string email, string address, string phone, string password, int role)
        {
            this.userid = userid;
            this.username = username;
            this.fullname = fullname;
            this.email = email;
            this.address = address;
            this.phone = phone;
            this.password = password;
            this.role = role;
        }*/
        public static void clearUser()
        {
            user.userid = -1;
            user.username = "";
            user.fullname = "";
            user.email = "";
            user.address = "";
            user.phone = "";
            user.password = "";
            user.role =0;
        }
    }
}
