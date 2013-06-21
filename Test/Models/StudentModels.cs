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


}