using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CussBuster.API.Services;
using CussBuster.Database.Entities;

namespace CussBuster.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
			try
			{
				return Ok(_adminService.GetCurseWord(id));
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
				return Ok(_adminService.GetCurseWords());
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
                return BadRequest("Message not found");

            }
        }

        [HttpPost]
        public IActionResult AddCurseWord(CurseWords curseWord)
        {
			try
			{
                return Ok(_adminService.AddCurseWord(curseWord));
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
				return BadRequest("Unable to post message");
			}
        }

        [HttpDelete]
        public IActionResult RemoveCurseWord(CurseWords curseWord)
        {
			try
			{
                _adminService.RemoveCurseWord(curseWord);
                return Ok("Successfully removed: " + curseWord.CurseWord);
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
				return BadRequest("Unable to post message");
			}
        }

        [HttpPut]
        public IActionResult UpdateCurseWord(CurseWords curseWord)
        {
			try
			{
                return Ok(_adminService.UpdateCurseWord(curseWord));
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
				return BadRequest("Unable to post message");
			}
        }

    }
}
