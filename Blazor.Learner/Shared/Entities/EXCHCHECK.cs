using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GridShared.DataAnnotations;
using GridShared.Sorting;

namespace BlazorCookies.Models
{
	public partial class EXCHCHECK
	{
		[Key]
		[Required]
		[GridColumn(Position = 0)]
		public int EC_ID { get; set; }
		[GridColumn(Position = 1)]
		public DateTime EC_DATE { get; set; }
		[GridColumn(Position = 2)]
		public string EC_REM { get; set; }

		
	}
}
