using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CussBuster.API.Services;
using CussBuster.API.Models;

namespace CussBuster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public List<string> Get()
        {
			try
			{
				//retrieve list of naughty words
				var list = new List<MessageModel>();

				return _messageService.GetList();
			}
			catch (Exception e)
			{
				return null;
			}
        }

        [HttpPost]
        public List<string> Post(MessageModel message)
        {
            try
            {
				var naughtyWord = message.Message;

                return _messageService.Add(naughtyWord);

                //return Ok("'" + naughtyWord + "' has been added!");
            }
            catch(Exception e)
            {
				return null;
                //return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public void Put(string naughtyWord)
        {

        }

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                return Ok();
            }
            // catch(NotFoundException e)
            // {
                
            // }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
