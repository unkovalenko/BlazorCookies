using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlazorCookies.Models
{
	public class EXCHCHECK
	{
		[Key]
		public int EC_ID { get; set; }
		public DateTime EC_DATE { get; set; }
		public string EC_REM { get; set; }

		
	}
}
