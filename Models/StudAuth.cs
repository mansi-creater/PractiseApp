using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PractiseApp.Models
{
    public class StudAuth : IDisposable
    {
        private StudentEntities dbcontext;
        public StudAuth()
        {
            dbcontext = new StudentEntities();
        }
        public Student ValidateStud(string Username, string Password)
        {
            return dbcontext.Students.FirstOrDefault(
                stud => stud.Username.Equals(Username, StringComparison.OrdinalIgnoreCase)
                && stud.Password == Password);
        }
        public void Dispose()
        {
            dbcontext.Dispose();
        }
    }
}