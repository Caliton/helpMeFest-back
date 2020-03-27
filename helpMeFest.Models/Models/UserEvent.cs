using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Models.Models
{
    public class UserEvent
    {
        public int IdUser { get; set; }
        public User User { get; set; }

        public int IdEvent { get; set; }
        public Event Evet { get; set; }
    }
}
