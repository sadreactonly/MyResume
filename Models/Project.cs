using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyResume.Models
{
	/// <summary>
	/// Class represention of project.
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Represents id.
		/// </summary>
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		/// <summary>
		/// Represents name of project.
		/// </summary>
		[BsonElement("Name")]
		public string Name { get; set; }

		/// <summary>
		/// Represents technologies used in project.
		/// </summary>
		[BsonElement("Technologies")]
		public string Technologies { get; set; }

		/// <summary>
		/// Represents short description of project.
		/// </summary>
		[BsonElement("Description")]
		public string Description { get; set; }

		/// <summary>
		/// Represents project's repository link.
		/// </summary>
		[BsonElement("GithubLink")]
		public string GithubLink { get; set; }
	}
}
