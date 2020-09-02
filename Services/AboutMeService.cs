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
    public class AboutMeService
    {
        private readonly IMongoCollection<AboutMe> _AboutMes;

        public AboutMeService(IMyResumeDatabaseSettings settings)
        {
            MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.ConnectionString));
            mongoSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
           
            var mongoClient = new MongoClient(mongoSettings);
			var database = mongoClient.GetDatabase(settings.DatabaseName);

			_AboutMes = database.GetCollection<AboutMe>(settings.AboutMeCollectionName);
		}

        public List<AboutMe> Get()
        {
            try
            {
                return _AboutMes.Find(AboutMes => true).ToList();
            }
            catch (Exception)
            {
                return new List<AboutMe>();
            }
        }

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