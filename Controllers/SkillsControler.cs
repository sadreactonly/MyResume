using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyCvService.Models;
using MyResume.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace MyCvService.Controllers
{
	/// <summary>
	/// Provides functionality to the '/skills' route.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class SkillsController : ControllerBase
	{

		private readonly SkillsService skillsService;

		/// <summary>
		/// Represents contructor of controller.
		/// </summary>
		/// <param name="expirienceService"> Represents instance of SkillsService.</param>
		public SkillsController(SkillsService skillsService)
		{
			this.skillsService = skillsService;
		}

		/// <summary>
		/// Represents HttpGet method with route "/api/skills".
		/// </summary>
		/// <returns>
		/// List of Skills objects.
		/// </returns>
		[HttpGet]
		[AllowAnonymous]
		public IEnumerable<Skills> GetSkills()
		{
			return skillsService.Get();
		}

		/// <summary>
		/// Represents HttpGet method with route "/api/skills/{id}".
		/// </summary>
		/// <param name="id">
		/// Represents id of Skills object.
		/// </param>
		/// <returns>
		/// Single Skills object with same id.
		/// </returns>
		[HttpGet("{id}")]
		[AllowAnonymous]
		public Skills Get(string id)
		{
			return skillsService.Get(id);
		}

		/// <summary>
		/// HttpPut method with route "/api/skills/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		/// <param name="skills">Object representation of Skills class.</param>
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] Skills skills)
		{
			if (IsExist(id))
			{
				skillsService.Update(id, skills);
			}
		}

		/// <summary>
		/// HttpDelete method with route "/api/skills/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			skillsService.Remove(skillsService.Get(id));
		}

		/// <summary>
		/// HttpPost method with route "/api/skills/{value}".
		/// </summary>
		/// <param name="skills">Instance of Skills class.</param>
		[HttpPost]
		public void Post(Skills value)
		{
			skillsService.Create(value);
		}
		private bool IsExist(string id)
		{
			var obj = skillsService.Get().Where(x => x.Id == id);
			if (obj != null)
				return true;
			return false;
		}


	}
}