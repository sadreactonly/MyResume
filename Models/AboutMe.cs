using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyCvService.Models
{
	public class AboutMe
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("Name")]
		public string Name { get; set; }

		[BsonElement("Job")]
		public string Job { get; set; }

		[BsonElement("Summary")]
		public string Summary { get; set; }

		[BsonElement("Image")]
		public string Image
		{
			get;set;
		}

	}
}
