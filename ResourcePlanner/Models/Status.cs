using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}