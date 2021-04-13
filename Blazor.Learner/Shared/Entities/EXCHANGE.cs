using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlazorCookies.Models
{
	public class EXCHANGE
	{
		[Key]
		public int EX_ID { get; set; }
		public DateTime EX_DATE { get; set; }
		public decimal EX_K { get; set; }
		public decimal EX_KMAT { get; set; }
		public decimal EX_KCASH { get; set; }
		public int CY_IDFROM { get; set; }
		public int CY_IDTO { get; set; }
		public string EX_REM { get; set; }
		public string EDUSER { get; set; }
		public DateTime EDITDATE { get; set; }
		public string REGUSER { get; set; }
		public DateTime REGDATE { get; set; }
		public int EC_ID { get; set; }

		
	}
}
