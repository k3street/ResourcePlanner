using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class TaskDependancy
    {
        public int TaskDependacyId { get; set; }
        public Task Task { get; set; }
        public Task DependantTask { get; set;}
    }
}