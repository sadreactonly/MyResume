using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MyCvService.Models;
using System.Reflection;
using System.Text;
using MyResume.Models;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCvService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResumeController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			string filePath = "MyResume.Assets.Stefan_Vasić-Software_Developer.pdf";

			var assembly = Assembly.GetExecutingAssembly();

			using (Stream resourceStream = assembly.GetManifestResourceStream(filePath))
			{
				if (resourceStream == null) return null;
				byte[] fileBytes = new byte[resourceStream.Length];
				resourceStream.Read(fileBytes, 0, fileBytes.Length);
				return File(fileBytes, "application/pdf", "CV.pdf");
			}	
		}

		[HttpGet]
		[Route("about-me")]
		public AboutMe GetAboutMe()
		{
		
			return new AboutMe()
			{
				Id = "0",
				Name = "Stefan Vasić",
				Job = "Software developer",
				Summary = "Enthusiastic software developer with a true passion for programming. Almost three years of experience in developing, implementing and testing software to meet specific project requirements. Have practical knowledge of programming in C# and different technologies and methodologies.",
				Image = "data:image/jpg;base64," + GetImage("MyResume.Assets.profileimage.jpg"),
			};
		}

		[HttpGet]
		[Route("experience")]
		public IEnumerable<Experience> GetExperience()
		{
			var x = new Experience()
			{
				Id = "0",
				Title = "Developer",
				Subtitle = "Schneider electric DMS, Novi Sad",
				StartDate = 2017,
				EndDate = 0,
				Work = new List<string>()
				{
					"Worked on company product software UI and back-end services.",
					"Coding, debbuging and testing product and internal tools for company.",
					"Working on multiple user stories in VanComm protocol implementation,including a writing Slave for VanComm protocol that is used as company internal tool.",
				}

			};
			var y = new Experience()
			{
				Id = "0",
				Title = "Internship",
				Subtitle = "Schneider electric DMS, Novi Sad",
				StartDate = 2015,
				EndDate = 2015,
				Work = new List<string>()
				{
					"Worked on small scale company product software back-end services.",
					"Programm is written in C#, using WCF and EntityFramework.",
					"Succesfully done, started scoolarship.",
				}
			};
			var z = new Experience()
			{
				Id = "2",
				Title = "Scoolarship",
				Subtitle = "Schneider electric DMS, Novi Sad",
				StartDate = 2015,
				EndDate = 0,
				Work = new List<string>()
				{
					"Enter scholarship program.",
					"Different levels of scholarship over the years."
				}
			};
			var t = new Experience()
			{
				Id = "3",
				Title = "Faculty of Technical Sciences",
				Subtitle = "Novi Sad",
				StartDate = 2013,
				EndDate = 0,
				Work = new List<string>()
				{
					"Learned and worked programming languages such as: C, C++, C#.",
					"Worked with databases, web and windows aplications."
				}
			};
			return new List<Experience>() { x, y,z,t }.OrderBy(x => x.StartDate).Reverse();
		}

		[HttpPost("send-mail")]
		public IActionResult SendEmail([FromBody] Email email)
		{
			if (email != null)
			{

				MimeMessage message = new MimeMessage();

				MailboxAddress from = new MailboxAddress(email.name,email.email);
				message.From.Add(from);

				MailboxAddress to = new MailboxAddress("Stefan Vasic","stefan_94@rocketmail.com");
				message.To.Add(to);

				message.Subject = email.subject + ", from: " + email.email;

				BodyBuilder bodyBuilder = new BodyBuilder();
				bodyBuilder.TextBody = GenerateMessage(email);
				message.Body = bodyBuilder.ToMessageBody();



				using (SmtpClient client = new SmtpClient())
				{
					client.CheckCertificateRevocation = false;
					client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTlsWhenAvailable);
					client.Authenticate("vasic.resume@gmail.com", "myresume");

					client.Send(message);
					client.Disconnect(true);
					client.Dispose();
				}
				

				return Ok();
			}


			return NotFound();
		}

		[HttpGet]
		[Route("hobbies")]
		public IEnumerable<Hobby> GetHobbies()
		{
			var sports = new Hobby("0", "data:image/png;base64," + GetImage("MyResume.Assets.sports.png"), "Sports", "Playing and watching basketball and football with friends. Huge Partizan fan.");

			var electronic = new Hobby("1", "data:image/png;base64," + GetImage("MyResume.Assets.circuit.png"), "Electronics", "Restoring and scrapping old electronic devices and using with arduino for automation projects.");

			var programming = new Hobby("2", "data:image/png;base64," + GetImage("MyResume.Assets.programming.png"), "Programming", "Learning new programming languages and technologies. Interested in android programming.");

			var music = new Hobby("3", "data:image/png;base64," + GetImage("MyResume.Assets.dj.png"), "Music", "Learning new instruments and music production.");

			return new List<Hobby>() { sports, electronic, programming, music };
		}

		[HttpGet]
		[Route("skills")]
		public IEnumerable<Skills> GetSkills()
		{

			var x = new Skills()
			{
				Id = "0",
				Title = "Practical experience",
				Subtitle = "Languages and technologies used on previous jobs",
				Technologies = new List<Technology>()
				{
					new Technology("0","C#","WPF,.NET, ASP.NET, EntityFramework"),
					new Technology("1","Debugging and testing (Unit, Behavioral, Automated)",""),
					new Technology("2","Working with agile methodology, git and CI.","")
				}
			};

			var y = new Skills()
			{
				Id = "1",
				Title = "Worked with/Familiar with:",
				Subtitle = "Personal projects and self improvements",
				Technologies = new List<Technology>()
				{
					new Technology("0","JavaScript/TypeScript","Got familiar with JS in college (Angular framework). I used ReactJS to build this website as self improvement."),
					new Technology("1","Xamarin.Android/Xamarin.Forms","I am interested in building android apps, mostly for personal use."),
					new Technology("2","Databases","SQL, SQLite, MongoDB.")
				}
			};

			return new List<Skills>() { x, y };
		}


		private string GenerateMessage(Email email)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("-Sender:\n");
			stringBuilder.AppendFormat("\tName:{0}\n", email.name);
			stringBuilder.AppendFormat("\tMail:{0}\n", email.email);
			stringBuilder.AppendFormat("\tSubject:{0}\n", email.subject);
			stringBuilder.Append("\n\n-Message:\n");
			stringBuilder.Append(email.message);

			stringBuilder.Append("\n\nMail sent from my-resume app.\n");

			return stringBuilder.ToString();
		}

		private string GetImage(string path)
		{
			var assembly = Assembly.GetExecutingAssembly();

			using (Stream resourceStream = assembly.GetManifestResourceStream(path))
			{
				if (resourceStream == null) return null;
				byte[] imageArray = new byte[resourceStream.Length];
				resourceStream.Read(imageArray, 0, imageArray.Length);
				return Convert.ToBase64String(imageArray);
			}

		}


	}
}