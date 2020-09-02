using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResume.Models
{
    public class MyResumeDatabaseSettings : IMyResumeDatabaseSettings
    {
        public string AboutMeCollectionName { get; set; }
        public string ExperienceCollectionName { get; set; }
        public string SkillsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string HobbiesCollectionName { get; set; }
        public string ProjectsCollectionName { get; set; }
    }

    public interface IMyResumeDatabaseSettings
    {
        string HobbiesCollectionName { get; set; }
        string ProjectsCollectionName { get; set; }
        string ExperienceCollectionName { get; set; }
        string AboutMeCollectionName { get; set; }
        string SkillsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
