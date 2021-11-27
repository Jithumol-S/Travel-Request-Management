using System;
using System.Collections.Generic;

namespace TravelRequestManagement_RestAPI.Models
{
    public partial class UserTypes
    {
        public UserTypes()
        {
            Login = new HashSet<Login>();
        }

        public int UserTypeId { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<Login> Login { get; set; }
    }
}
