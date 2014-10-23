using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class Log
    {
        public int LogId { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public int RecordId { get; set; }
        public UserProfile User { get; set; }
        public string Scope { get; set; }
        public LogReference.Logtype LogType { get; set; }
        public LogReference.UserLogType UserLogType { get; set;}

    }

    public class LogReference
    {
        public enum Logtype
        {
            Error,
            Info,
            Warning
        }

        public enum UserLogType
        {
            Edit,
            Insert,
            Delete
        }
    }
}