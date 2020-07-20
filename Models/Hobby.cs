using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCvService.Models
{
	public class Hobby
	{
		public Hobby(string id, string image, string name, string explanation)
		{
			Id = id;
			Image = image;
			Name = name;
			Explanation = explanation;
		}

		public string Id { get; set; }
		public string Image { get; set; }
		public string Name { get; set; }
		public string Explanation { get; set; }
	}
}
