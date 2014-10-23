using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class EntityListView
    {
        public enum EntityType{
            Person,
            Project
        }
        public EntityType Type { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}