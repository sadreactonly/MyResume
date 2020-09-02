using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text;
using MyResume.Models;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MyResume.Services;


namespace MyCvService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResumeController : ControllerBase
	{

		private readonly AboutMeService _supplementService;

		public ResumeController(AboutMeService supplementService)
		{
			_supplementService = supplementService;
		}


		[HttpGet]
		public IActionResult GetCV()
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

	

		}


	}
