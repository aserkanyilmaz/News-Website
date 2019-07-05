using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbRep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbRep.Services.MongoRepository
{
    public abstract class BaseMongoRepository<TModel>
        where TModel : MongoBaseModel
    {
        private readonly IMongoCollection<MongoBaseModel> mongoCollection;

        public BaseMongoRepository(string mongoDBConnectionString, string news, string CategoryName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(news);
            mongoCollection = database.GetCollection<MongoBaseModel>(CategoryName);
        }
        public virtual List<TModel> GetList()
        {
            return mongoCollection.Find<TModel>(book => true).ToList();
        }
        public virtual TModel GetById(string id)
        {
            var docId = new ObjectId(id);
            return mongoCollection.Find<TModel>(m => m.Id == docId).FirstOrDefault();
        }
        public virtual TModel Create(TModel model)
        {
            mongoCollection.InsertOne(model);
            return model;
        }
        public virtual void Update(string id, TModel model)
        {
            var docId = new ObjectId(id);
            mongoCollection.ReplaceOne(m => m.Id == docId, model);
        }

        public virtual void Delete(TModel model)
        {
            mongoCollection.DeleteOne(m => m.Id == model.Id);
        }

        public virtual void Delete(string id)
        {
            var docId = new ObjectId(id);
            mongoCollection.DeleteOne(m => m.Id == docId);
        }
    }
}