using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyCvService.Models;
using MyResume.Services;

namespace MyResume.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutMeController : ControllerBase
	{
		private readonly AboutMeService _aboutMeService;

		public AboutMeController(AboutMeService aboutMeService)
		{
			_aboutMeService = aboutMeService;
		}
		[HttpGet]
		public AboutMe GetAboutMe()
		{

			return _aboutMeService.Get().FirstOrDefault();
		}

		[HttpPut("{id}")]
		public void Put(string id, [FromBody] AboutMe aboutMe)
		{
			if(IsExist(id))
			{
				_aboutMeService.Update(id, aboutMe);
			}
		}
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
