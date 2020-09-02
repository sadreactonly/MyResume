using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyCvService.Models
{
	/// <summary>
	/// Class that represents hobby.
	/// </summary>
	public class Hobby
	{
		
		/// <summary>
		/// Represents id of object.
		/// </summary>
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		/// <summary>
		/// Represents binary representation of hobby icon.
		/// </summary>
		[BsonElement("Image")]
		public string Image { get; set; }

		/// <summary>
		/// Represents name of hobby.
		/// </summary>
		[BsonElement("Name")]
		public string Name { get; set; }

		/// <summary>
		/// Represents short explanation of hobby.
		/// </summary>
		[BsonElement("Explanation")]
		public string Explanation { get; set; }

	}
}
