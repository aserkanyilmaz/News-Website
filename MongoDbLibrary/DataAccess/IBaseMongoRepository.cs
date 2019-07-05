using NewsEntities.Entities;
using System.Collections.Generic;

namespace MongoDbLibrary.DataAccess
{
    public interface IBaseMongoRepository<MEntity> where MEntity : IMongoEntity
    {
        MEntity Create(MEntity model);
        void Delete(string id);
        void Delete(MEntity model);
        MEntity GetById(string id);
        List<MEntity> GetList();
        void Update(string id, MEntity model);
        void Add(MEntity model);
        
    }
}
