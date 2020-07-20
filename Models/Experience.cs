using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCvService.Models
{
	public class Experience
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public int StartDate { get; set; }
		public int EndDate { get; set; }
		public string Subtitle { get; set; }
		public List<string> Work { get; set; }

		public string Date
		{
			get
			{
				if (EndDate != 0)
					return StartDate + " - " + EndDate;

				return StartDate + " - present";
			}
		}

	}
}
