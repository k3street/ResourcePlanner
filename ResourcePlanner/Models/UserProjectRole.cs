using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourcePlanner.Models
{
    public class UserProjectRole
    {
        public int UserProjectRoleId { get; set; }

        public int PersonID { get; set; }
        public int ProjectID { get; set; }

        public Role Role { get; set; }

        public virtual Person Person { get; set; }
        public virtual Project Project { get; set; }
    }
}