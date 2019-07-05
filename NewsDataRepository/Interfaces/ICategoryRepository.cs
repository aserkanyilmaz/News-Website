using NewsEntities.Entities;
using NewsDataRepository.Interfaces;
using NewsCore;
using NewsCore.DataAccess;

namespace NewsDataRepository.Interfaces
{
    public interface ICategoryRepository:IEntityRepository<Category>
    {
       
    }
}
