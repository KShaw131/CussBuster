using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<MessageController> _logger;


        public MessageController(IMessageService messageService, ILogger<MessageController> logger)
        {
          _messageService = messageService;
          _logger = logger;
        }

        [HttpPost]
        public IActionResult ParseMessage([FromBody]string message)
        {
            try
            {
                _logger.LogInformation("Request sent with message: " + message);
                return Ok(_messageService.ParseMessage(message));
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
