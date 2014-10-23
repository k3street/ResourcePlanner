using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class TaskPerson
    {
        public enum Quarter
        {
            Q1 = 1, 
            Q2 = 2,
            Q3 = 3,
            Q4 = 4
        }
        public int TaskPersonId { get; set; }
        public Person Person { get; set; }
        public TaskItem PlanItem { get; set; }
        public DateTime TaskPersonDate { get; set; }
        public Quarter TaskPersonQuarter { get; set; }
    }
}