using System;
using System.Collections.Generic;

namespace restaurant_api.Domain
{
    public partial class User
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string second_last_name { get; set; }
        public string phone { get; set; }
        public decimal salary { get; set; }
        public Guid role_id { get; set; }

        public virtual Cat_Role role { get; set; }
    }
}
