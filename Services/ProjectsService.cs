using MyResume.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MyCvService.Models;

namespace MyResume.Services
{
    public class ProjectsService
    {
        private readonly IMongoCollection<Project> _Projects;

        public ProjectsService(IMyResumeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Projects = database.GetCollection<Project>(settings.ProjectsCollectionName);
        }

        public List<Project> Get() =>
            _Projects.Find(Project => true).ToList();

        public Project Get(string id) =>
            _Projects.Find<Project>(Project => Project.Id == id).FirstOrDefault();

        public Project Create(Project Project)
        {
            _Projects.InsertOne(Project);
            return Project;
        }

        public void Update(string id, Project ProjectsIn) =>
            _Projects.ReplaceOne(Project => Project.Id == id, ProjectsIn);

        public void Remove(Project ProjectsIn) =>
            _Projects.DeleteOne(Project => Project.Id == ProjectsIn.Id);

        public void Remove(string id) =>
            _Projects.DeleteOne(Project => Project.Id == id);
    }
}