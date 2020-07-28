using MyResume.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MyCvService.Models;

namespace MyResume.Services
{
    public class ExperienceService
    {
        private readonly IMongoCollection<Experience> _Experiences;

        public ExperienceService(IMyResumeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Experiences = database.GetCollection<Experience>(settings.ExperienceCollectionName);
        }

        public List<Experience> Get() =>
            _Experiences.Find(Experience => true).ToList();

        public Experience Get(string id) =>
            _Experiences.Find<Experience>(Experience => Experience.Id == id).FirstOrDefault();

        public Experience Create(Experience Experience)
        {
            _Experiences.InsertOne(Experience);
            return Experience;
        }

        public void Update(string id, Experience ExperienceIn) =>
            _Experiences.ReplaceOne(Experience => Experience.Id == id, ExperienceIn);

        public void Remove(Experience ExperienceIn) =>
            _Experiences.DeleteOne(Experience => Experience.Id == ExperienceIn.Id);

        public void Remove(string id) =>
            _Experiences.DeleteOne(Experience => Experience.Id == id);
    }
}