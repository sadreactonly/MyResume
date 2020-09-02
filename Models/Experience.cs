using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace MyCvService.Models
{
	/// <summary>
	/// This class represents model of Experience.
	/// </summary>
	public class Experience
	{
		/// <summary>
		/// Represents id of object.
		/// </summary>
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		/// <summary>
		/// Represents title.
		/// </summary>
		[BsonElement("Title")]
		public string Title { get; set; }


		/// <summary>
		/// Represents year of start. 
		/// </summary>
		[BsonElement("StartDate")]
		public int StartDate { get; set; }

		/// <summary>
		/// Represents year of end.
		/// </summary>
		[BsonElement("EndDate")]
		public int EndDate { get; set; }

		/// <summary>
		/// Represents subtitle.
		/// </summary>
		[BsonElement("Subtitle")]
		public string Subtitle { get; set; }

		/// <summary>
		/// Represents list of technologies, languages and tools used.
		/// </summary>
		[BsonElement("Work")]
		public List<string> Work { get; set; }

		/// <summary>
		/// String representation of date in format "startYear - endYear".
		/// If end year is 0, string is "startYear - present".
		/// </summary>
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
