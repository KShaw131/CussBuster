using System;
using System.ComponentModel.DataAnnotations;

namespace CussBuster.Models
{
	public class MessageModel
	{
		public int MessageId { get; set; }
		public string Message { get; set; }
		public int SeverityLimit { get; set; }
		
		//public CurseWords CurseWordsFound { get; set; }
	}
}
