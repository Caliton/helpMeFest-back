using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Models.Models
{
    public class UserEvent
    {
        public int PersonId{ get; set; }
        public Person Person { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
