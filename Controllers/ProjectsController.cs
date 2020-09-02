using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyResume.Models;
using MyResume.Services;

namespace MyResume.Controllers
{
	/// <summary>
	/// Provides functionality to the '/projects' route.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ProjectsController : ControllerBase
	{

		private readonly ProjectsService projectsService;

		/// <summary>
		/// Represents contructor of controller.
		/// </summary>
		/// <param name="projectsService"> Represents instance of ProjectService.</param>
		public ProjectsController(ProjectsService projectsService)
		{
			this.projectsService = projectsService;
		}

		/// <summary>
		/// Represents HttpGet method with route "/api/projects".
		/// </summary>
		/// <returns>
		/// List of Project objects.
		/// </returns>
		[HttpGet]
		[AllowAnonymous]
		public IEnumerable<Project> GetProjects()
		{

			return projectsService.Get();
		}

		/// <summary>
		/// HttpPut method with route "/api/projects/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		/// <param name="project">Object representation of Project class.</param>
		[HttpPut("{id}")]
		[AllowAnonymous]
		public void Put(string id, [FromBody] Project project)
		{
			if (IsExist(id))
			{
				projectsService.Update(id, project);
			}
		}

		/// <summary>
		/// HttpDelete method with route "/api/projects/{id}".
		/// </summary>
		/// <param name="id">Represents ID of object.</param>
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			projectsService.Remove(projectsService.Get(id));
		}

		/// <summary>
		/// HttpPost method with route "/api/projects/{project}".
		/// </summary>
		/// <param name="project">Instance of Project class.</param>
		[HttpPost]
		public void Post(Project project)
		{
			projectsService.Create(project);
		}


		private bool IsExist(string id)
		{
			var obj = projectsService.Get().Where(x => x.Id == id);
			if (obj != null)
				return true;
			return false;
		}


	}
}