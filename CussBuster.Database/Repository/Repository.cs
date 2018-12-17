using System;
using System.Collections.Generic;
using System.Linq;
using CussBuster.Models;
using CussBuster.Database.Context;
using CussBuster.Database.Entities;


namespace CussBuster.Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CussBusterContext _context;

        public Repository(CussBusterContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Queryable()
        {
            return _context.Set<T>();
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
