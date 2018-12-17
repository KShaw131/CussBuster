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

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
			try
			{
				var messageModel = _messageService.GetCurseWord(id);

                return Ok(messageModel);
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
                return BadRequest("Message not found");
                
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
			try
			{
				var messageModel = _messageService.GetCurseWords();

                return Ok(messageModel);
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
                return BadRequest("Message not found");

            }
        }

        [HttpPost]
        public IActionResult Post()
        {
			try
			{
                return Ok();
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
				return BadRequest("Unable to post message");
			}
        }

    }
}
