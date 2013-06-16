using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Entity;


namespace Test.Models
{
    
    public class UserInfo : DbContext
    {
        public UserInfo() : base("StudentInfo") { }
        public DbSet<Users> UI { get; set; }
    }

    public class CourseInfo : DbContext
    {
        public CourseInfo() : base("StudentInfo") { }
        public DbSet<Courses> CI { get; set; }
    }

    public class SelCourseInfo : DbContext
    {
        public SelCourseInfo() : base("StudentInfo") { }
        public DbSet<SelCourses> SelI { get; set; }
    }

    public class UpLoadFileInfo : DbContext
    {
        public UpLoadFileInfo() : base("StudentInfo") { }
        public DbSet<UpLoadFile> ULFI { get; set; }
    }


}