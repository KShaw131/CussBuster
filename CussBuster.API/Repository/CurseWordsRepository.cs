using System;
using System.Collections.Generic;
using System.Linq;
using CussBuster.Database.Context;
using CussBuster.Database.Entities;
using CussBuster.Database.Repository;
using Microsoft.EntityFrameworkCore;

namespace CussBuster.API.Repository
{
    public class CurseWordsRepository : Repository<CurseWords>, ICurseWordsRepository
    {
        public CurseWordsRepository(CussBusterContext context) : base(context)
        {
        }

        public override IEnumerable<CurseWords> Queryable()
        {
            return _context.CurseWords.Include(cw => cw.Type);
        }

        public CurseWords GetById(int id)
        {
            return _context.CurseWords.Find(id);
        }
    }
}
