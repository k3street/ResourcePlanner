using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WorkingHours { get; set; }
        public string TimeZone {  get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        [Display(Name = "Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public EmployeeStatus.Employment Employee { get; set;}
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }

    public class EmployeeStatus
    {
        public enum Employment
        {
            Permanent,
            Contract
        }

        public enum Status
        {
            Active,
            Released,
            OnLeave,
            Vacation
        }
    }
}