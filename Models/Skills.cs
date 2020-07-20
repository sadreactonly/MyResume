using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCvService.Models
{
	public class Skills
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public List<Technology> Technologies { get; set; }
	}

	public class Technology
	{
		public Technology(string id, string name, string description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
