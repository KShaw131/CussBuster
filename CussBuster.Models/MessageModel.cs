using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CussBuster.Models
{
	public class MessageModel
	{
		public string Message { get; set; }
		public IEnumerable<Object> FoundCurseWords { get; set; }
	}
}
