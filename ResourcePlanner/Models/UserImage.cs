using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class UserImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserImageId { get; set; }
        public string Filename { get; set; }
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
        public string ContentType { get; set; }
        public string File { get; set; }
        public int Length { get; set; }
    }
}