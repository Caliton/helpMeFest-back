using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Models.Contract
{
    public interface ITokenService
    {
        public string GenerateToken(UserOld model);
    }
}
