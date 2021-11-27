using System;
using System.Collections.Generic;

namespace TravelRequestManagement_RestAPI.Models
{
    public partial class RequestTable
    {
        public int RequestId { get; set; }
        public string CauseTravel { get; set; }
        public string Source { get; set; }
        public decimal Destination { get; set; }
        public string Mode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NoDays { get; set; }
        public string Priority { get; set; }
        public int ProjectId { get; set; }
        public int EmpId { get; set; }
        public string Status { get; set; }

        public virtual Employees Emp { get; set; }
        public virtual Projects Project { get; set; }
    }
}
