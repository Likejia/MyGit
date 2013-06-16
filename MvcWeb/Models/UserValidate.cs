using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWeb.Models;
using MvcWeb.Controllers;

namespace MvcWeb.Models
{
    public class UserValidates
    {
        DataBaseConnection connection = new DataBaseConnection();
        DataClassesDataContext data = new DataClassesDataContext();

        public UserValidates()
        {
            connection.Connec();
        }

        public bool TeacherValidate(string id, string password)
        {
            
            var teacherResult = from t in data.Teachers
                                where t.ID == id && t.Password == password
                                select t;
            foreach (var r in teacherResult)
            {
                if (r.ID != null)
                {
                    return true;
                }
            }   
            return false;
        }

        public bool StudentValidate(string id, string password)
        {

            var studentResult = from s in data.Students
                                where s.ID == id && s.Password == password
                                select s;
            foreach (var r in studentResult)
            {
                if (r.ID != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}