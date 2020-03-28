using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Models.Utils
{
    public class AuthenticationResult
    {
        public bool IsSuccessfully { get; set; }

        public string Message { get; set; }

        public User ReturnedUser { get; set; }

    }
}
