using MyCvService.Models;
using MyResume.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyResume.Helpers
{
	public class DatabaseMock
	{

		public IEnumerable<AboutMe> GetAboutMeInformations()
		{
			return JsonConvert.DeserializeObject<List<AboutMe>>(File.ReadAllText("Assets/DatabaseMock/aboutme.json"));
		}

		public IEnumerable<Experience> GetExperienceInformations()
		{
			return JsonConvert.DeserializeObject<List<Experience>>(File.ReadAllText("Assets/DatabaseMock/experience.json"));
		}

		public IEnumerable<Hobby> GetHobbiesInformations()
		{
			return JsonConvert.DeserializeObject<List<Hobby>>(File.ReadAllText("Assets/DatabaseMock/hobbies.json"));
		}
		public IEnumerable<Skills> GetSkillsInformations()
		{
			return JsonConvert.DeserializeObject<List<Skills>>(File.ReadAllText("Assets/DatabaseMock/skills.json"));
		}
		public IEnumerable<Project> GetProjectsInformations()
		{
			return JsonConvert.DeserializeObject<List<Project>>(File.ReadAllText("Assets/DatabaseMock/projects.json"));
		}
	}
}
