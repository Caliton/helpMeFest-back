﻿using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Models.Contract.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User CreateFillProps(User user);
    }
}
