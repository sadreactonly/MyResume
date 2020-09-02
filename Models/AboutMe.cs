using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MyCvService.Models
{
	/// <summary>
	/// Represents information about me.
	/// </summary>
	public class AboutMe
	{
		/// <summary>
		/// Represents id of object.
		/// </summary>
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		/// <summary>
		/// Represents name.
		/// </summary>
		[BsonElement("Name")]
		public string Name { get; set; }

		/// <summary>
		/// Represets job position.
		/// </summary>
		[BsonElement("Job")]
		public string Job { get; set; }

		/// <summary>
		/// Represents summary text about programmer.
		/// </summary>
		[BsonElement("Summary")]
		public string Summary { get; set; }


		/// <summary>
		/// Represents binary representation of profile image.
		/// </summary>
		[BsonElement("Image")]
		public string Image
		{
			get;set;
		}


		/// <summary>
		/// Represents binary representation of resume.
		/// </summary>
		[BsonElement("Resume")]
		public string Resume
		{
			get; set;
		}
		/// <summary>
		/// Represents link of Github profile.
		/// </summary>
		[BsonElement("GithubProfileLink")]
		public string GithubProfileLink
		{
			get;set;
		}

		/// <summary>
		/// Represents link of Linkedin profile.
		/// </summary>
		[BsonElement("LinkedinProfileLink")]
		public string LinkedinProfileLink
		{
			get; set;
		}



	}
}
