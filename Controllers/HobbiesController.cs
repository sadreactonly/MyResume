using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCvService.Models;
using MyResume.Services;

namespace MyResume.Controllers
{

	/// <summary>
	/// Provides functionality to the '/hobbies' route.
	/// </summary>
	[Route("api/hobbies")]
	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class HobbiesController : ControllerBase
	{

		private readonly HobbiesService hobbiesService;

		/// <summary>
		/// Represents contructor of controller.
		/// </summary>
		/// <param name="hobbiesService"> Represents instance of HobbyService.</param>
		public HobbiesController(HobbiesService hobbiesService)
		{
			this.hobbiesService = hobbiesService;
		}

		/// <summary>
		/// Represents HttpGet method with route "/api/hobbies".
		/// </summary>
		/// <returns>
		/// List of Hobby objects.
		/// </returns>
		[HttpGet]
		[AllowAnonymous]
		public IEnumerable<Hobby> GetHobbies()
		{

			return hobbiesService.Get();

		}


		/// <summary>
		/// Represents HttpGet method with route "/api/hobbies/{id}".
		/// </summary>
		/// <param name="id">
		/// Represents id of Hobby object.
		/// </param>
		/// <returns>
		/// Single Hobby object with same id.
		/// </returns>
		[HttpGet("{id}")]
		[AllowAnonymous]
		public Hobby Get(string id)
		{
			return hobbiesService.Get(id);
		}

		/// <summary>
		/// HttpPut method with route "/api/hobbies/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		/// <param name="hobby">Object representation of Hobby class.</param>
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] Hobby hobby)
		{
			if (IsExist(id))
			{
				hobbiesService.Update(id, hobby);
			}
		}

		/// <summary>
		/// HttpDelete method with route "/api/hobbies/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			hobbiesService.Remove(hobbiesService.Get(id));
		}
		[HttpPost]

		/// <summary>
		/// HttpPost method with route "/api/hobbies/{hobby}".
		/// </summary>
		/// <param name="hobby">Instance of Hobby class.</param>
		public void Post([FromBody] Hobby hobby)
		{
			hobbiesService.Create(hobby);
		}
		private bool IsExist(string id)
		{
			var obj = hobbiesService.Get().Where(x => x.Id == id);
			if (obj != null)
				return true;
			return false;
		}

	}
}