//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
using NewsCore.Entities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEntities.Entities
{
    [Table("Categories")]
    public class Category : IEntity
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int CategoryId { get; set; }
        //[BsonElement("CategoryName")]
        public string CategoryName { get; set; }

        public virtual IEnumerable<News> News { get; set; }


    }
}
