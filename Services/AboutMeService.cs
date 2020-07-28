using MyResume.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MyCvService.Models;

namespace MyResume.Services
{
    public class AboutMeService
    {
        private readonly IMongoCollection<AboutMe> _AboutMes;

        public AboutMeService(IMyResumeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _AboutMes = database.GetCollection<AboutMe>(settings.AboutMeCollectionName);
        }

        public List<AboutMe> Get() =>
            _AboutMes.Find(AboutMe => true).ToList();

        public AboutMe Get(string id) =>
            _AboutMes.Find<AboutMe>(AboutMe => AboutMe.Id == id).FirstOrDefault();

        public AboutMe Create(AboutMe AboutMe)
        {
            _AboutMes.InsertOne(AboutMe);
            return AboutMe;
        }

        public void Update(string id, AboutMe AboutMeIn) =>
            _AboutMes.ReplaceOne(AboutMe => AboutMe.Id == id, AboutMeIn);

        public void Remove(AboutMe AboutMeIn) =>
            _AboutMes.DeleteOne(AboutMe => AboutMe.Id == AboutMeIn.Id);

        public void Remove(string id) =>
            _AboutMes.DeleteOne(AboutMe => AboutMe.Id == id);
    }
}