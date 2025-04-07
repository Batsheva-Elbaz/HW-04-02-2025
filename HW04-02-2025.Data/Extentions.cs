//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HW04_02_2025.Data
//{
//    public static  class Extensions
//    {
//        public static class NullExtension
//        {
//            public static T GetOrNull<T>(this SqlDataReader reader, string columnName)
//            {
//                var value = reader[columnName];
//                if (value == DBNull.Value)
//                {
//                    return default(T);
//                }

//                return (T)value;

//            }
//        }
//    }
//}
