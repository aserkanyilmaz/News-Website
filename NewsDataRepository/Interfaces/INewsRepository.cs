using NewsEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using NewsCore.DataAccess;


namespace NewsDataRepository.Interfaces
{
    public interface INewsRepository : IEntityRepository<News>
    {
    }
}
