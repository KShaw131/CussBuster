using System;
using System.Collections.Generic;
using CussBuster.Database.Entities;
using CussBuster.API.DataAccess;
using CussBuster.API.Repository;

namespace CussBuster.API.DataAccess
{
    
    public class BadWordCache : IBadWordCache
    {

        public IEnumerable<CurseWords> CurseWords
        {
            get; set;
        }
    }
}