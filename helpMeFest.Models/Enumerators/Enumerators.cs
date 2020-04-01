using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Models
{
    public enum EnumLoginResult
    {
        FAIL,
        SUCCESS
    }

    public enum EnumProfile
    {
        ORGANIZER = 1,
        PARTICIPANT = 2
    }

    public enum EnumCrud 
    {
        CREATED = 'C', 
        UPDATED = 'U',
        DELETED = 'D',
        NON_CHANGE = 'N'
    }

}
