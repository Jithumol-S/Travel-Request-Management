using System;
using System.Collections.Generic;

namespace TravelRequestManagement_RestAPI.Models
{
    public partial class Employees
    {
        public Employees()
        {
            RequestTable = new HashSet<RequestTable>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal PhoneNumber { get; set; }
        public int LoginId { get; set; }
        public bool IsActive { get; set; }

        public virtual Login Login { get; set; }
        public virtual ICollection<RequestTable> RequestTable { get; set; }
    }
}
