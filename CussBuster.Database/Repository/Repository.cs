using System;
using System.Collections.Generic;
using System.Linq;
using CussBuster.Database.Context;
using CussBuster.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CussBuster.Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CussBusterContext _context;
        protected DbSet<T> dbSet;

        public Repository(CussBusterContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            var entry = dbSet.Add(entity);
            
            _context.SaveChanges();
            return entry.Entity;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> Queryable() 
        {
            return dbSet;
        }

        public T Update(T entity)
        {
            var entry = dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            
            return entry.Entity;
        }
    }
}
