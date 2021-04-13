using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace BlazorCookies.Models
{
	public class CURRENCY
	{
		[Key]
		public int CY_ID { get; set; }
		public string CY_NAME { get; set; }
		public string CY_SNAME { get; set; }
		public string CY_NAC { get; set; }
		public string CY_CALC { get; set; }
		public string DEL { get; set; }

	}
}
