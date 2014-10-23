using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TaskItem> TaskItems { get; set; }

        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public string ReferenceNumber { get; set; }
        public int StateID { get; set; }
        public State State { get; set; }
    }
}