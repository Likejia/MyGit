using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using Test;
using System.IO;
using System.Data.Linq;



namespace Test.Models
{
    #region 模型

     
    public class NewSelCourse
    {
        public string CName { get; set; }
        public string Teacher { get; set; }
        public string Flag { get; set; }
        public DateTime Seltime { get; set; }
    }
    //public class StudentInfo : DbContext
    //{
    //    public StudentInfo() : base("StudentInfo") { }
    //    public DbSet<NewSelCourse> SI { get; set; }
    //}
    public class UpLoadFileModel
    {
        [Required]
        [DisplayName("所属课程")]
        public string CName { get; set; }
    }

    public class HandInEssayModel
    {
        [Required]
        [DisplayName("所属课程")]
        public string CName { get; set; }

        [Required]
        [DisplayName("指导老师")]
        public string Teacher { get; set; }

        [Required]
        [DisplayName("提交时间")]
        public DateTime ApTime { get; set; }

    }

    public class MangerReModel
    {
        public int UID { get; set; }

        public string Fitter { get; set; }

        public string FName { get; set; }

        public DateTime Updatetime { get; set; }
    }

    #endregion

    #region Service


    public interface GetData
    {
       
        //SqlDataReader GetStudentReInfo(string name);
        int GetUserID(string name);
        int GetCourseID(string name);
        int GetNextUID_InUpLoadFile();
        int GetNextAuID();
        string GetFUrl(int uid);
        List<SelectListItem> GetCourseName();
        List<SelectListItem> Getfitter(string value);
        List<SelectListItem> GetTeacherName();
        List<UpLoadFile> GetUpLoadFileInfobyID(int id);
        List<UpLoadFile> GetUpLoadFileInfobyCID(int cid);
        List<SelCourses> GetSelCoursesInfo(string name);
        List<MangerReModel> GetMangerRe(int id,string fitter);
        List<MangerReModel> GetMangerRe(int id);
    }

    public class GetUserData : GetData
    {
        /*public SqlDataReader GetStudentCourseInfo(string name)
        {
            GetInfo GI = new GetInfo();
            SqlDataReader sqld = GI.GetUserCourseInfo(name);
            return sqld;
        }*/

        /*  
        public SqlDataReader GetStudentReInfo(string name)
        {
            GetInfo GI = new GetInfo();
            SqlDataReader sqld = GI.GetUserReInfo(name);
            return sqld;
        }*/
        public int GetUserID(string userName)
        {
            int res = 0;

            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.Users
                         where n.Name == userName
                         select n;

            foreach (var n in result)
                res = n.ID;

            return res;
        }

        public int GetCourseID(string CourseName)
        {
            int res = 0;

            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.Courses
                         where n.CName == CourseName
                         select n;

            foreach (var n in result)
                res = n.CID;

            return res;
        }

        public int GetNextUID_InUpLoadFile()
        {
            int res = 0;

            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.UpLoadFile
                         select n.UID;

            foreach (var n in result)

                res = n + 1;

            return res;
        }

        public int GetNextAuID()
        {
            int res = 0;

            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.AuditFile
                         select n.AuID;

            foreach (var n in result)

                res = n + 1;

            return res;
        }

        public string GetFUrl(int uid)
        {
            string res = "";

            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.UpLoadFile
                         where n.UID == uid
                         select n.FUrl;

            foreach (var n in result)
                res = n ;

            return res;
        }

        public List<SelectListItem> GetCourseName()
        {
            DataDataContext dbc = new DataDataContext();
            List<SelectListItem> res = new List<SelectListItem>();
            var result = from n in dbc.Courses
                         select n.CName;
            foreach (var n in result)
            {
                SelectListItem SL = new SelectListItem();
                SL.Text = n;
                SL.Value = n;
                res.Add(SL);
            }
            res[0].Selected = true;

            return res;
        }

        public List<SelectListItem> GetTeacherName()
        {
            DataDataContext dbc = new DataDataContext();
            List<SelectListItem> res = new List<SelectListItem>();
            var result = from n in dbc.Users
                         where  n.UserType == "Teacher"
                         select n.Name;
            foreach (var n in result)
            {
                SelectListItem SL = new SelectListItem();
                SL.Text = n;
                SL.Value = n;
                res.Add(SL);
            }
            res[0].Selected = true;

            return res;
        }

        public List<SelectListItem> Getfitter(string value)
        {
            DataDataContext dbc = new DataDataContext();
            
            List<SelectListItem> res = new List<SelectListItem>();

            SelectListItem FI = new SelectListItem
            {
                Text = "全部",
                Value = "全部",
            };
            res.Add(FI);
            
            var result = from n in dbc.Courses
                         select n.CName;
            foreach (var n in result)
            {
                SelectListItem SL = new SelectListItem();
                SL.Text = n;
                SL.Value = n;
                res.Add(SL);
            }


            //确定true
            for (int i = 0; i < res.Count; i++)
            {
                if (res[i].Value == value)
                    res[i].Selected = true;
            }



            return res;
        }

        public List<UpLoadFile> GetUpLoadFileInfobyID(int id)
        {
            DataDataContext dbc = new DataDataContext();

            List<UpLoadFile> res = new List<UpLoadFile>();

            var result = from n in dbc.UpLoadFile
                         where n.ID == id
                         select n;

            foreach (var n in result)
            {
                UpLoadFile item = new UpLoadFile();
                item.ID = n.ID;
                item.CID = n.CID;
                item.FileName = n.FileName;
                item.FUrl = n.FUrl;
                item.UpLoadTime = n.UpLoadTime;
                item.DownLoadCount = n.DownLoadCount;
                item.UID = item.UID;

                res.Add(item);
            }
            return res;

        }

        public List<UpLoadFile> GetUpLoadFileInfobyCID(int cid)
        {
            DataDataContext dbc = new DataDataContext();

            List<UpLoadFile> res = new List<UpLoadFile>();

            var result = from n in dbc.UpLoadFile
                         where n.CID == cid
                         select n;

            foreach (var n in result)
            {
                UpLoadFile item = new UpLoadFile();
                item.ID = n.ID;
                item.CID = n.CID;
                item.FileName = n.FileName;
                item.FUrl = n.FUrl;
                item.UpLoadTime = n.UpLoadTime;
                item.DownLoadCount = n.DownLoadCount;
                item.UID = item.UID;

                res.Add(item);
            }
            return res;

        }

        public List<SelCourses> GetSelCoursesInfo(string name)
        {
            List<SelCourses> res = new List<SelCourses>();
            DataDataContext dbc = new DataDataContext();

            int id = this.GetUserID(name);

            var result = from n in dbc.SelCourses
                         where n.ID == id
                         select n;

            foreach (var n in result)
            {
                SelCourses item = new SelCourses();
                item.ID = n.ID;
                item.CID = n.CID;
                item.SelTime = n.SelTime;
                item.SID = n.SID;
                res.Add(item);
            }
            return res;
        }

        public List<MangerReModel> GetMangerRe(int id,string fitter)
        {
            List<MangerReModel> res = new List<MangerReModel>();
            DataDataContext dbc = new DataDataContext();

            int cid = GetCourseID(fitter);

            var result = from n in dbc.UpLoadFile
                         where n.ID == id && n.CID == cid
                         select n;
            foreach (var n in result)
            {
                MangerReModel item = new MangerReModel();
                item.UID = n.UID;
                item.FName = n.FileName;
                item.Updatetime = n.UpLoadTime;
                item.Fitter = fitter;

                res.Add(item);
            }

            return res;
        }

        public List<MangerReModel> GetMangerRe(int id)
        {
            List<MangerReModel> res = new List<MangerReModel>();
            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.UpLoadFile
                         where n.ID == id 
                         select n;
            foreach (var n in result)
            {
                MangerReModel item = new MangerReModel();
                item.UID = n.UID;
                item.FName = n.FileName;
                item.Updatetime = n.UpLoadTime;
                item.Fitter = "全部";

                res.Add(item);
            }

            return res;
        }

       
    }

    public interface SendData
    {
        List<UpLoadFile> GetFilebyID(string username);
        //List<UpLoadFile> GetFilebyCID(string username);
    }

    public class SendFileData : SendData
    {
        GetData GD = new GetUserData();
        public List<UpLoadFile> GetFilebyID(string username)
        {
            int id = GD.GetUserID(username);
            string uploadFolder = AppDomain.CurrentDomain.BaseDirectory + "Reference/"+username;
            string[] files = Directory.GetFiles(uploadFolder);
            List<UpLoadFile> fileDescriptions = GD.GetUpLoadFileInfobyID(id);
            return fileDescriptions;
        }
    }

    public interface DeleteData
    {
        void DeleteUpLoadFile(int uid);
    }

    public class UDeleteData : DeleteData
    {
        public void DeleteUpLoadFile(int uid)
        {
            DataDataContext dbc = new DataDataContext();
            dbc.Log = Console.Out;
            //取出student
            var student = dbc.UpLoadFile.SingleOrDefault<UpLoadFile>(s => s.UID == uid);
            //if (student == null)
            //{
            //    Console.WriteLine("student is null");
            //    return;
            //}
            dbc.UpLoadFile.DeleteOnSubmit(student);
            dbc.SubmitChanges();
        }
    }

    #endregion
}