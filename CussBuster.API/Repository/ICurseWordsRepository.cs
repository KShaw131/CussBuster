using System;
using System.Collections.Generic;
using CussBuster.Database.Entities;
using CussBuster.Database.Repository;

namespace CussBuster.API.Repository
{
	public interface ICurseWordsRepository : IRepository<CurseWords>
	{
        CurseWords GetById(int id);
	}
}