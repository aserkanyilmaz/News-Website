using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NewsEntities.Entities
{
    [DisplayName("news")]
    public class NewsModel : IMongoEntity
    {

        [BsonElement("NewsName")]
        public string NewsName { get; set; }

        [BsonElement("NewsTitle")]
        public string NewsTitle { get; set; }

        [BsonElement("NewsContent")]
        public string NewsContent { get; set; }

        [BsonElement("NewsExpo")]
        public string NewsExpo { get; set; }

        [BsonElement("CategoryName")]
        public string CategoryName { get; set; }

        public ObjectId Id { get; set; }
    }
}

