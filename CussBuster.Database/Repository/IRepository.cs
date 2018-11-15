using System;
using System.Text;
using CussBuster.Models;

namespace CussBuster.Database.Repository
{
	public interface IRepository
	{
		MessageModel Get();
	}
}
