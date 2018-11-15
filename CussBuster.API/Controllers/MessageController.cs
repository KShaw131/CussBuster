using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CussBuster.API.Services;
using CussBuster.Models;

namespace CussBuster.API.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public string Get()
        {
			try
			{
				//retrieve list of naughty words
				var message = _messageService.GetMessage();

				return message.Message;
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
				return "Message not found";
			}
        }
        
    }
}
