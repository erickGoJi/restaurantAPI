using System;
using System.Collections.Generic;

namespace restaurant_api.Domain
{
    public partial class Cat_Role
    {
        public Cat_Role()
        {
            Users = new HashSet<User>();
        }

        public Guid id { get; set; }
        public string role_name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
