using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace NewsEntities.Entities
{
    public interface IMongoEntity
    {
        ObjectId Id { get; }
    }
}
