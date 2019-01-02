using System;
using System.Collections.Generic;
using System.Linq;
using CussBuster.Database.Context;
using CussBuster.Database.Entities;
using CussBuster.Database.Repository;


namespace CussBuster.API.Repository
{
    public class CurseWordsRepository : Repository<CurseWords>, ICurseWordsRepository
    {
        public CurseWordsRepository(CussBusterContext context) : base(context)
        {
        }

        public CurseWords GetById(int id)
        {
            return _context.CurseWords.Find(id);
        }
    }
}
