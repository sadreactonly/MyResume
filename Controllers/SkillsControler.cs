using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MyCvService.Models;
using MyResume.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCvService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkillsController : ControllerBase
	{

		private readonly SkillsService _skillsService;

		public SkillsController(SkillsService skillsService)
		{
			_skillsService = skillsService;
		}


		[HttpGet]
		public IEnumerable<Skills> GetSkills()
		{
			return _skillsService.Get();
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public Skills Get(string id)
		{
			return _skillsService.Get(id);
		}

		[HttpPut("{id}")]
		public void Put(string id, [FromBody] Skills aboutMe)
		{
			if (IsExist(id))
			{
				_skillsService.Update(id, aboutMe);
			}
		}

		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			_skillsService.Remove(_skillsService.Get(id));
		}
		[HttpPost]
		public void Post(Skills value)
		{
			_skillsService.Create(value);
		}
		private bool IsExist(string id)
		{
			var obj = _skillsService.Get().Where(x => x.Id == id);
			if (obj != null)
				return true;
			return false;
		}


	}
}