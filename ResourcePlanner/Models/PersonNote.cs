using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class PersonNote
    {
        public int PersonNoteId { get; set; }
        public Person Person { get; set; }
        public Note Note { get; set; }
    }
}