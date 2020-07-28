using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCvService.Models;
using MyResume.Services;

namespace MyResume.Controllers
{
	[Route("api/hobbies")]
	[ApiController]
	public class HobbiesController : ControllerBase
	{

		private readonly HobbiesService _hobbiesService;

		public HobbiesController(HobbiesService hobbiesService)
		{
			_hobbiesService = hobbiesService;
		}

		[HttpGet]
		public IEnumerable<Hobby> GetHobbies()
		{

			return _hobbiesService.Get();

		}
		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public Hobby Get(string id)
		{
			return _hobbiesService.Get(id);
		}

		[HttpPut("{id}")]
		public void Put(string id, [FromBody] Hobby aboutMe)
		{
			if (IsExist(id))
			{
				_hobbiesService.Update(id, aboutMe);
			}
		}

		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			_hobbiesService.Remove(_hobbiesService.Get(id));
		}
		[HttpPost]

		public void Post([FromBody] Hobby value)
		{
			_hobbiesService.Create(value);
		}
		private bool IsExist(string id)
		{
			var obj = _hobbiesService.Get().Where(x => x.Id == id);
			if (obj != null)
				return true;
			return false;
		}


	}
}