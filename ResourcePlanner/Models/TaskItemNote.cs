using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class TaskItemNote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskItemNoteId { get; set; }
        public int TaskItemID { get; set; }
        public virtual TaskItem TaskItem { get; set; }
        public int NoteID { get; set; }
        public virtual Note Note { get; set; }
    }
}