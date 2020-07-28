using MyResume.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MyCvService.Models;

namespace MyResume.Services
{
    public class HobbiesService
    {
        private readonly IMongoCollection<Hobby> _Hobbies;

        public HobbiesService(IMyResumeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Hobbies = database.GetCollection<Hobby>(settings.HobbiesCollectionName);
        }

        public List<Hobby> Get() =>
            _Hobbies.Find(Hobby => true).ToList();

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