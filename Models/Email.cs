using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResume.Models
{
	/// <summary>
	/// Class that represents email.
	/// </summary>
	public class Email
	{
		/// <summary>
		/// Represents sender's name.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Represents sender's email.
		/// </summary>
		public string email { get; set; }

		/// <summary>
		/// Represents subject of email.
		/// </summary>
		public string subject { get; set; }

		/// <summary>
		/// Represents body of email message.
		/// </summary>
		public string message { get; set; }
	}
}
