using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CussBuster.Models
{
	public class MessageModel
	{
		public string Message { get; set; }
		public IEnumerable<CurseWordModel> FoundCurseWords { get; set; }
	}
}
