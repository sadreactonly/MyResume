using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MyResume.Models
{
	public class Project
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("Name")]
		public string Name { get; set; }

		[BsonElement("Technologies")]
		public string Technologies { get; set; }

		[BsonElement("Description")]
		public string Description { get; set; }

		[BsonElement("GithubLink")]
		public string GithubLink { get; set; }
	}
}
