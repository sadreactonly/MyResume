using MyResume.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MyCvService.Models;
using System;
using MyResume.Helpers;
using System.Security.Authentication;

namespace MyResume.Services
{
    public class ProjectsService
    {
        private readonly IMongoCollection<Project> _Projects;
       // private readonly DatabaseMock databaseMock;

        public ProjectsService(IMyResumeDatabaseSettings settings)
        {
            MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.ConnectionString));
            mongoSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(mongoSettings);
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _Projects = database.GetCollection<Project>(settings.ProjectsCollectionName);
		}

        public List<Project> Get()
        {
            try
            {
                return _Projects.Find(Project => true).ToList();
                //return databaseMock.GetProjectsInformations().ToList();
            }
            catch (Exception)
            {
                return new List<Project>();
            }
        }
        
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