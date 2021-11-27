using System;
using System.Collections.Generic;

namespace TravelRequestManagement_RestAPI.Models
{
    public partial class Projects
    {
        public Projects()
        {
            RequestTable = new HashSet<RequestTable>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<RequestTable> RequestTable { get; set; }
    }
}
