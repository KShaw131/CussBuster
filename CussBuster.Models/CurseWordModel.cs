using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CussBuster.Models
{
	public class CurseWordModel
	{
		public string CurseWord { get; set; }
		public string Type { get; set; }
        public int Severity { get; set; }
        public int Occurrences { get; set; }
	}
}