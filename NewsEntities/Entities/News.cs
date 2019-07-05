///using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
using NewsCore.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewsEntities.Entities
{
    public class News: IEntity
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int NewsId { get; set; }
        //[BsonElement("NewsName")]
        public string NewsName { get; set; }
        //[BsonElement("NewsTitle")]
        public string NewsTitle { get; set; }
        //[BsonElement("NewsContent")]
        public string NewsContent { get; set; }
        //[BsonElement("NewsExpo")]
        public string NewsExpo { get; set; }
        public int CategoryId { get; set; }



    }
}
