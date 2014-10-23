using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class ProjectNote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectNoteId { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int NoteID { get; set; }
        public virtual Note Note { get; set;}
    }
}