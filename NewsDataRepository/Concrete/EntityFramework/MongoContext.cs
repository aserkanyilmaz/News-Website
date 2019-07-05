//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using NewsDataRepositoryNewsDataRepository.Concrete.EntityFramework;
//using NewsEntities.Entities;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace NewsDataRepository.Concrete.EntityFramework
//{
//  public  class MongoContext
//    {
//        private readonly IMongoDatabase _database = null;

//        public MongoContext(IOptions<DatabaseSettings> settings)
//        {
//            var client = new MongoClient(settings.Value.MongoConnection);
//            if (client != null)
//                _database = client.GetDatabase(settings.Value.Database);
//        }
//        public IMongoCollection<NewsModel> newsmodel
//        {
//            get
//            {
//                return _database.GetCollection<NewsModel>("news");
//            }
//        }
//    }
//}
