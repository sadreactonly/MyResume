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
using System.Xml.Serialization;
using System.Xml;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using MyResume.Helpers;
using System.Resources;
using MyResume.Services;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCvService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExperienceController : ControllerBase
	{

		private readonly ExperienceService _expirienceService;

		public ExperienceController(ExperienceService expirienceService)
		{
			_expirienceService = expirienceService;
		}
	

		[HttpGet]
		public IEnumerable<Experience> GetExperience()
		{

			return _expirienceService.Get();
		}
		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public Experience Get(string id)
		{
			return _expirienceService.Get(id);
		}

		[HttpPut("{id}")]
		public void Put(string id, [FromBody] Experience aboutMe)
		{
			if (IsExist(id))
			{
				_expirienceService.Update(id, aboutMe);
			}
		}

		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			_expirienceService.Remove(_expirienceService.Get(id));
		}
		[HttpPost]
		public void Post(Experience value)
		{
			_expirienceService.Create(value);
		}
		private bool IsExist(string id)
		{
			var obj = _expirienceService.Get().Where(x => x.Id == id);
			if (obj != null)
				return true;
			return false;
		}


	}
}