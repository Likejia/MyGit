using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    //只取各数据表的前8条记录
    public class shortList<T> : List<T>
    {

        public shortList(List<T> source)
        {
            int i;
            for (i = 0; i < 8 && i < source.Count; i++)
            {
                this.Add(source[i]);
            }
        }

    }

    //转化数据表的各列内容，获得新的数据
    public class newUpLoadFiles
    {
        public int UID;
        public string UName;
        public string CName;
        public string FileName;
        public string FileUrl;
        public System.DateTime UploadTime;
        public int DownloadCount;

    }

    public class newapplyNewCourse
    {
        public int AI;
        public string applyerName;
        public string courseName;
        public System.DateTime applyTime;
    }


    public class GetNewData
    {
        public GetNewData()
        { }

        public List<newUpLoadFiles> GetNewUpLoadFiles()
        {
            List<newUpLoadFiles> newfileslist = new List<newUpLoadFiles>();
            DataDataContext db = new DataDataContext();

            foreach (var item in db.UpLoadFile)
            {
                newUpLoadFiles file = new newUpLoadFiles();

                file.UID = item.UID;
                file.UName = (from n in db.Users
                              where n.ID == item.ID
                              select n.Name).First();
                file.CName = (from n in db.Courses
                              where n.CID == item.CID
                              select n.CName).First();

                file.FileName = item.FileName;
                file.FileUrl = item.FUrl;
                file.UploadTime = item.UpLoadTime;
                file.DownloadCount = item.DownLoadCount;

                newfileslist.Add(file);

            }
            return newfileslist;
        }

        public List<newapplyNewCourse> GetapplyNewCourse()
        {
            List<newapplyNewCourse> courses = new List<newapplyNewCourse>();
            DataDataContext db = new DataDataContext();

            foreach (var item in db.ApplyNewCourse)
            {
                newapplyNewCourse course = new newapplyNewCourse();
                course.AI = item.AI;
                course.applyerName = (from n in db.Users
                                      where n.ID == item.ID
                                      select n.Name).First();
                course.courseName = item.CourseName;
                course.applyTime = item.ApplyTime;

                courses.Add(course);

            }
            return courses;
        }

    }

}