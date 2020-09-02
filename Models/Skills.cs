using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyCvService.Models
{
	/// <summary>
	/// Class representation of skills.
	/// </summary>
	public class Skills
	{
		/// <summary>
		/// Represents if of object.
		/// </summary>
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		/// <summary>
		/// Represents name of skill.
		/// </summary>
		[BsonElement("Title")]
		public string Title { get; set; }

		/// <summary>
		/// Represents subtitle.
		/// </summary>
		[BsonElement("Subtitle")]
		public string Subtitle { get; set; }

		/// <summary>
		/// Represents technologies.
		/// </summary>
		[BsonElement("Technologies")]
		public List<string> Technologies { get; set; }
	}

	
}
