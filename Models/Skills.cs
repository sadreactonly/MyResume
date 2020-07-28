using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyCvService.Models
{
	public class Skills
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Title")]
		public string Title { get; set; }
		[BsonElement("Subtitle")]
		public string Subtitle { get; set; }
		[BsonElement("Technologies")]
		public List<string> Technologies { get; set; }
	}

	
}
