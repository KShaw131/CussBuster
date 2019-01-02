using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CussBuster.API.Services;
using CussBuster.Database.Entities;
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

        [HttpPost]
        public IActionResult parseMessage(MessageModel message)
        {
            try
            {
                return Ok(_messageService.parseMessage(message));
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
