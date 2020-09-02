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
	/// Provides functionality to the '/experience' route.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ExperienceController : ControllerBase
	{

		private readonly ExperienceService _expirienceService;


		/// <summary>
		/// Represents contructor of controller.
		/// </summary>
		/// <param name="expirienceService"> Represents instance of ExperienceService.</param>
		public ExperienceController(ExperienceService expirienceService)
		{
			_expirienceService = expirienceService;
		}
	


		/// <summary>
		/// Represents HttpGet method with route "/api/experience".
		/// </summary>
		/// <returns>
		/// List of Experience objects.
		/// </returns>
		[HttpGet]
		[AllowAnonymous]
		public IEnumerable<Experience> GetExperience()
		{

			return _expirienceService.Get().OrderByDescending(x => x.StartDate).ThenBy(y => y.EndDate);
		}

		/// <summary>
		/// Represents HttpGet method with route "/api/experience/{id}".
		/// </summary>
		/// <param name="id">
		/// Represents id of Experience object.
		/// </param>
		/// <returns>
		/// Single Experience object with same id.
		/// </returns>
		[HttpGet("{id}")]
		[AllowAnonymous]
		public Experience Get(string id)
		{
			return _expirienceService.Get(id);
		}

		/// <summary>
		/// HttpPut method with route "/api/experience/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		/// <param name="experience">Object representation of Experience class.</param>
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] Experience experience)
		{
			if (IsExist(id))
			{
				_expirienceService.Update(id, experience);
			}
		}

		/// <summary>
		/// HttpDelete method with route "/api/experience/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			_expirienceService.Remove(_expirienceService.Get(id));
		}

		/// <summary>
		/// HttpPost method with route "/api/experience/{value}".
		/// </summary>
		/// <param name="experience">Instance of Experience class.</param>
		[HttpPost]
		public void Post(Experience experience)
		{
			_expirienceService.Create(experience);
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