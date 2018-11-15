using System;
using CussBuster.Models;

namespace CussBuster.Database.Repository
{
	public class Repository : IRepository
	{
		public MessageModel Get()
		{
			MessageModel message = new MessageModel(){
				MessageId = 1,
				Message = "Hello World"
			};
			
			return message;
		}

	}
}
