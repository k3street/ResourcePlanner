using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class TaskItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskItemId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int TaskID { get; set; }
        public virtual Task Task { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }
    }
}