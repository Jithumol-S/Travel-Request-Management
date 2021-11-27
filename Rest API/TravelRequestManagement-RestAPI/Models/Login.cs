using System;
using System.Collections.Generic;

namespace TravelRequestManagement_RestAPI.Models
{
    public partial class Login
    {
        public Login()
        {
            Employees = new HashSet<Employees>();
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }

        public virtual UserTypes UserTypeNavigation { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
