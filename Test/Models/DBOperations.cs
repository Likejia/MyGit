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
using System.Collections;

namespace Test.Models
{
    public interface GetData
    {
        bool If_CourseName_Exist(string name);
        string GetUserName(int ID);
        int GetUserID(string name);
        int GetCourseID(string name);
        int GetNextUID_InUpLoadFile();
        int GetNextAuID();
        string GetFUrl(int uid);
        List<Courses> GetCourseName(string TeacherName);
        List<AuIModels> GetAuI(string name);
        List<SelectListItem> GetCourseName();
        List<SelectListItem> Getfitter(string value);
        List<SelectListItem> GetTeacherName();
        List<UpLoadFile> GetUpLoadFile();
        List<UpLoadFile> GetUpLoadFileInfobyID(int id);
        List<UpLoadFile> GetUpLoadFileInfobyCID(int cid);
        List<SelCourses> GetSelCoursesInfo(string name);
        List<Courses> GetCourses();
        List<MangerReModel> GetMangerRe(int id, string fitter);
        List<MangerReModel> GetMangerRe(int id);
    }

    public class GetUserData : GetData
    {
        public List<SelectListItem> GetTeacherName()
        {
            DataDataContext dbc = new DataDataContext();
            List<SelectListItem> res = new List<SelectListItem>();
            var result = from n in dbc.Users
                         where n.UserType == "Teacher"
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

        public string GetUserName(int ID)
        {
            string res = "";
            DataDataContext dbc = new DataDataContext();
            var result = from n in dbc.Users
                         where n.ID == ID
                         select n.Name;
            foreach (var n in result)
                res = n;
            return res;
        }

        public List<AuIModels> GetAuI(string name)
        {
            int TID = GetUserID(name);
            DataDataContext dbc = new DataDataContext();

            List<AuIModels> res = new List<AuIModels>();

            var result = from n in dbc.AuditFile
                         where n.AuditorID == TID
                         select n;

            foreach (var n in result)
            {
                AuIModels item = new AuIModels();
                item.filename = n.FileName;
                item.stuname = GetUserName(n.ID);
                item.filefrontname = n.FileName.Substring(0, n.FileName.IndexOf("."));
                item.fUrl = n.FileURL;
                item.auid = n.AuID;
                res.Add(item);
            }
            return res;
        }
        
        public bool If_CourseName_Exist(string name)
        {
            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.UpLoadFile
                         select n.FileName;

            foreach (var n in result)
                if (n == name)
                    return true;

            return false;
        }

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
                res = n;

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

        public List<Courses> GetCourseName(string TeacherName)
        {

            List<Courses> res = new List<Courses>();
            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.Courses
                         where n.Teacher == TeacherName
                         select n;
            foreach (var n in result)
            {
                Courses item = new Courses();
                item.CName = n.CName;

                item.CID = n.CID;
                item.Flag = n.Flag;
                item.Teacher = n.Teacher;

                res.Add(item);
            }

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

        public List<UpLoadFile> GetUpLoadFile()
        {
            DataDataContext dbc = new DataDataContext();

            List<UpLoadFile> res = new List<UpLoadFile>();

            var result = from n in dbc.UpLoadFile
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

            int id = GetUserID(name);

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

        public List<Courses> GetCourses()
        {
            DataDataContext dbc = new DataDataContext();
            List<Courses> res = new List<Courses>();
            var result = from n in dbc.Courses
                         select n;
            foreach (var n in result)
            {
                Courses SL = new Courses();
                SL.CID = n.CID;
                SL.CName = n.CName;
                SL.Flag = n.Flag;
                SL.Teacher = n.Teacher;
                res.Add(SL);
            }
            return res;
        }

        public List<MangerReModel> GetMangerRe(int id, string fitter)
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
            string uploadFolder = AppDomain.CurrentDomain.BaseDirectory + "Reference/" + username;

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            string[] files = Directory.GetFiles(uploadFolder);
            List<UpLoadFile> fileDescriptions = GD.GetUpLoadFileInfobyID(id);
            return fileDescriptions;
        }
    }

    public interface DeleteData
    {
        void DeleteUpLoadFile(int uid,string furl);
        void DeleteAuIFile(int auid,string furl,string newPath);
    }

    public class UDeleteData : DeleteData
    {
        GetData GD = new GetUserData();

        public static ArrayList getAllDir(string path)
        {
            ArrayList urlAddr = new ArrayList();//临时存放路径的链表
            if (Directory.Exists(path))
            {
                string[] fileList = Directory.GetFileSystemEntries(path);
                urlAddr.Clear();
                foreach (string file in fileList)
                {
                    string newStr = Path.GetFullPath(file);
                    string filename = Path.GetFileName(file);
                    string strExtension = Path.GetExtension(newStr).ToLower();
                    urlAddr.Add(filename);
                }
            }
            return urlAddr;
        }
        public void DeleteUpLoadFile(int uid,string furl)
        {
            DataDataContext dbc = new DataDataContext();
            dbc.Log = Console.Out;
            //取出student
            var student = dbc.UpLoadFile.SingleOrDefault<UpLoadFile>(s => s.UID == uid);
        
            ArrayList files = getAllDir(furl);
            for (int i = 0; i < files.Count; i++)
            {
                FileInfo ofile = new FileInfo(furl + files[i]);
                if (ofile.Exists)
                    ofile.Delete();
            }

            dbc.UpLoadFile.DeleteOnSubmit(student);
            dbc.SubmitChanges();
        }

        public void DeleteAuIFile(int auid, string furl,string newPath)
        {
            ArrayList files =getAllDir(furl);
            for (int i = 0; i < files.Count; i++)
            {
                FileInfo ofile = new FileInfo(furl + files[i]);
                if (ofile.Exists)
                    ofile.Delete();      
            }

            DataDataContext dbc = new DataDataContext();
            dbc.Log = Console.Out;
            //取出student
            var thestudent = from n in dbc.AuditFile where n.AuID == auid select n;
            var student = dbc.AuditFile.SingleOrDefault<AuditFile>(s => s.AuID == auid);
            //在UpLoad中添加
            int Uuid = GD.GetNextUID_InUpLoadFile();
            foreach(var n in thestudent)
            {
                UpLoadFile exp = new UpLoadFile
                {
                    UID = Uuid,
                    ID = n.ID,
                    CID = n.CID,
                    FileName = n.FileName,
                    FUrl = newPath,
                    UpLoadTime = DateTime.Now,
                    DownLoadCount = 0
                };
                dbc.UpLoadFile.InsertOnSubmit(exp);
                dbc.SubmitChanges();
            }
            
            //在Aui中删除
            dbc.AuditFile.DeleteOnSubmit(student);
            dbc.SubmitChanges();
        }
    }

    public interface ChangeData
    {
        void increaseDownLoadCount(string filename);
    }

    public class UChangeDate : ChangeData
    {
        public void increaseDownLoadCount(string filename)
        {
            DataDataContext dbc = new DataDataContext();

            var result = from n in dbc.UpLoadFile
                         where n.FileName == filename
                         select n;
            foreach (var n in result)
            {
                n.DownLoadCount += 1;
            }
            dbc.SubmitChanges();

        }
    }
}