using MyResume.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MyCvService.Models;
using System;
using MyResume.Helpers;
using System.Data;
using System.Security.Authentication;

namespace MyResume.Services
{
    public class SkillsService
    {
        private readonly IMongoCollection<Skills> _Skills;
        private readonly DatabaseMock databaseMock;

        public SkillsService(IMyResumeDatabaseSettings settings)
        {
            MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.ConnectionString));
            mongoSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(mongoSettings);
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _Skills = database.GetCollection<Skills>(settings.SkillsCollectionName);
			//databaseMock = new DatabaseMock();
		}

        public List<Skills> Get() {
			try
			{
                return _Skills.Find(Skills => true).ToList();
               // return databaseMock.GetSkillsInformations().ToList();
            }
            catch(Exception)
			{
                return new List<Skills>();
			}
        }
            


        public Skills Get(string id) =>
            _Skills.Find<Skills>(Skills => Skills.Id == id).FirstOrDefault();

        public Skills Create(Skills Skills)
        {
            _Skills.InsertOne(Skills);
            return Skills;
        }

        public void Update(string id, Skills SkillsIn) =>
            _Skills.ReplaceOne(Skills => Skills.Id == id, SkillsIn);

        public void Remove(Skills SkillsIn) =>
            _Skills.DeleteOne(Skills => Skills.Id == SkillsIn.Id);

        public void Remove(string id) =>
            _Skills.DeleteOne(Skills => Skills.Id == id);
    }
}