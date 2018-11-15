using System;
using System.ComponentModel.DataAnnotations;

namespace CussBuster.Models
{
	public class MessageModel
	{
		[Key]
		public int MessageId { get; set; }
		[Required]
		public string Message { get; set; }
		
	}
}
