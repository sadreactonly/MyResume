using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCvService.Models;
using MyResume.Models;
using MyResume.Services;

namespace MyResume.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectsController : ControllerBase
	{

		private readonly ProjectsService _projectsService;

		public ProjectsController(ProjectsService projectsService)
		{
			_projectsService = projectsService;
		}

		[HttpGet]
		public IEnumerable<Project> GetProjects()
		{

			return _projectsService.Get();
		}
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] Project aboutMe)
		{
			if (IsExist(id))
			{
				_projectsService.Update(id, aboutMe);
			}
		}

		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			_projectsService.Remove(_projectsService.Get(id));
		}
		[HttpPost]
		public void Post(Project value)
		{
			_projectsService.Create(value);
		}
		private bool IsExist(string id)
		{
			var obj = _projectsService.Get().Where(x => x.Id == id);
			if (obj != null)
				return true;
			return false;
		}


	}
}