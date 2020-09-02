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
    public class HobbiesService
    {
        private readonly IMongoCollection<Hobby> _Hobbies;
        //private readonly DatabaseMock databaseMock;

        public HobbiesService(IMyResumeDatabaseSettings settings)
        {
            MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.ConnectionString));
            mongoSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(mongoSettings);
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _Hobbies = database.GetCollection<Hobby>(settings.HobbiesCollectionName);
		}

        public List<Hobby> Get() 
	    {
            try
            {
                return _Hobbies.Find(Hobby => true).ToList();
                //return databaseMock.GetHobbiesInformations().ToList();
            }
            catch (Exception)
            {
                return new List<Hobby>();
            }
        }

        public Hobby Get(string id) =>
            _Hobbies.Find<Hobby>(Hobby => Hobby.Id == id).FirstOrDefault();

        public Hobby Create(Hobby Hobby)
        {
            _Hobbies.InsertOne(Hobby);
            return Hobby;
        }

        public void Update(string id, Hobby HobbiesIn) =>
            _Hobbies.ReplaceOne(Hobby => Hobby.Id == id, HobbiesIn);

        public void Remove(Hobby HobbiesIn) =>
            _Hobbies.DeleteOne(Hobby => Hobby.Id == HobbiesIn.Id);

        public void Remove(string id) =>
            _Hobbies.DeleteOne(Hobby => Hobby.Id == id);
    }
}