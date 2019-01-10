using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CussBuster.Models
{
	public class MessageModel
	{
		public string message { get; set; }
		public IEnumerable<Object> foundCurseWords { get; set; }
		public int occurrences { get; set; }
		
	}
}
