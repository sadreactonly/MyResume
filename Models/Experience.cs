using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace MyCvService.Models
{
	public class Experience
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("Title")]
		public string Title { get; set; }

		[BsonElement("StartDate")]
		public int StartDate { get; set; }

		[BsonElement("EndDate")]
		public int EndDate { get; set; }

		[BsonElement("Subtitle")]
		public string Subtitle { get; set; }

		[BsonElement("Work")]
		public List<string> Work { get; set; }

		public string Date
		{
			get
			{
				if (EndDate != 0)
					return StartDate + " - " + EndDate;

				return StartDate + " - present";
			}
		}

	}
}
