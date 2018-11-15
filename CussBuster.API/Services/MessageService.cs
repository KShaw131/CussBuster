using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CussBuster.Models;
using CussBuster.Database.Repository;

namespace CussBuster.API.Services
{
    public class MessageService : IMessageService
    {
        // private readonly IRepository _repository;
        
        // public MessageService(IRepository repository)
        // {
        //     var _repository = repository;
        // }

        public void Add(string naughtyWord)
        {
            //todo
        }

        public MessageModel GetMessage(){

            // return _messageRepository.Get();
            MessageModel message = new MessageModel(){
				MessageId = 1,
				Message = "Hello World"
			};

            return message;
        }

    }
}
