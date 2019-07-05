
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using NewsEntities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MongoDbLibrary.DataAccess.EntityFramework
{
    public class BaseMongoRepository<MEntity> : IBaseMongoRepository<MEntity>
        where MEntity : class, IMongoEntity, new()
    {
        private readonly IMongoCollection<MEntity> mongoCollection;

        public BaseMongoRepository(IConfiguration configuration)
        {
            var mongoDBConnectionString = configuration.GetSection("MongoConnection:Url").Value;
            var databaseString= configuration.GetSection("MongoConnection:Database").Value;
            string tableName = typeof(MEntity).CustomAttributes.First().ConstructorArguments.First().Value.ToString();
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(databaseString);
            mongoCollection = database.GetCollection<MEntity>(tableName);
        }
        public virtual MEntity Create(MEntity model)
        {
            mongoCollection.InsertOne(model);
            return model;
        }

        public virtual void Delete(string id)
        {
            var docId = new ObjectId(id);
            mongoCollection.DeleteOne(m => m.Id == docId);

        }

        public virtual void Delete(MEntity model)
        {
            mongoCollection.DeleteOne(m => m.Id == model.Id);
        }

        public virtual MEntity GetById(string id)
        {
            var docId = new ObjectId(id);
            return mongoCollection.Find<MEntity>(m => m.Id == docId).FirstOrDefault();
        }

        public List<MEntity> GetList()
        {
            return mongoCollection.Find<MEntity>(book => true).ToList();
        }

        public virtual void Update(string id, MEntity model)
        {
            var docId = new ObjectId(id);
            mongoCollection.ReplaceOne(m => m.Id == docId, model);
        }
        public virtual void Add(MEntity model)
        {
            mongoCollection.InsertOne(model);
        }

        public void Update(NewsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
