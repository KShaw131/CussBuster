using System;
using System.Collections.Generic;
using CussBuster.Database.Entities;

namespace CussBuster.API.DataAccess
{
    public interface IBadWordCache
    {
        IEnumerable<CurseWords> CurseWords { get; }
    }
}

