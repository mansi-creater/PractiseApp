using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PractiseApp.Models
{
    public class ValidateUser
    {
        static string token;
        internal static bool Login(string Email, string Password)
        {
            StudentEntities dbcontext = new StudentEntities();
            Student s = dbcontext.Students.Where(st => st.Email == Email && st.Password == Password).FirstOrDefault();

            if(s != null)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{s.Email}:{s.Password}");
                token = System.Convert.ToBase64String(plainTextBytes);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetToken()
        {
            return token;
        }

       
    }
}