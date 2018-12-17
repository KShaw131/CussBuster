using System;
using System.Collections.Generic;
using System.Text;
using CussBuster.Models;

namespace CussBuster.Database.Repository
{
	public interface IRepository<T>
	{
		T Add(T entity);
		IEnumerable<T> Queryable();
		T Update(T entity);
		void Delete(T entity);
	}
}
