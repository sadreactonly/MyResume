using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCvService.Models;
using MyResume.Services;

namespace MyResume.Controllers
{
	/// <summary>
	/// Provides functionality to the '/aboutme' route.
	/// </summary>
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
	public class AboutMeController : ControllerBase
	{
		private readonly AboutMeService _aboutMeService;

		/// <summary>
		/// Represents contructor of controller.
		/// </summary>
		/// <param name="aboutMeService"> Represents instance of AboutMeService.</param>
		public AboutMeController(AboutMeService aboutMeService)
		{
			_aboutMeService = aboutMeService;
		}

		/// <summary>
		/// Represents HttpGet method with route "/api/experience".
		/// </summary>
		/// <returns>
		/// Single AboutMe object.
		/// </returns>
		[HttpGet]
		[AllowAnonymous]
		public AboutMe GetAboutMe()
		{

			return _aboutMeService.Get().FirstOrDefault();
		}

		/// <summary>
		/// HttpPut method with route "/api/aboutme/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		/// <param name="aboutMe">Instance of AboutMe class.</param>
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] AboutMe aboutMe)
		{
			if(IsExist(id))
			{
				_aboutMeService.Update(id, aboutMe);
			}
		}
		/// <summary>
		/// HttpGet for resume.
		/// </summary>
		/// <returns>Resume PDF</returns>
		[HttpGet("get-resume")]
		[AllowAnonymous]
		public IActionResult GetResume()
		{
			var aboutMe = _aboutMeService.Get().FirstOrDefault();
			byte[] PDFDecoded = Convert.FromBase64String(aboutMe.Resume);

			return File(PDFDecoded, "application/pdf", "CV.pdf");		
		}

		/// <summary>
		/// HttpPost method with route "/api/aboutme/{value}".
		/// </summary>
		/// <param name="aboutMe">Instance of AboutMe class.</param>
		[HttpPost]
		public void Post([FromBody] AboutMe value)
		{
			_aboutMeService.Create(value);
		}

		private bool IsExist(string id)
		{
			var obj = _aboutMeService.Get().Where(x => x.Id == id);
			if (obj != null)
				return true;
			return false;
		}
	}
}
