using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace MyCvService.Models
{
	public class Hobby
	{
		
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("Image")]
		public string Image { get; set; }

		[BsonElement("Name")]
		public string Name { get; set; }

		[BsonElement("Explanation")]
		public string Explanation { get; set; }

	}
}
