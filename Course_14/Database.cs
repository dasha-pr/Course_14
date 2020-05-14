using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_14
{
    class Database
    {
        //здесь храниться вся информация об абонентах;
        public static int size, count;
        public static string password;
        public static string[] phone_number = new string[size];
        public static string[] name = new string[size];
        public static string[] surname = new string[size];
        public static string[] patronymic = new string[size];
        public static string[] address = new string[size];
    }
}
