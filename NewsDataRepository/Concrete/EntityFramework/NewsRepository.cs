using NewsCore.DataAccess.EntityFramework;
using NewsEntities.Entities;
using NewsDataRepository.Interfaces;
using NewsDataRepositoryNewsDataRepository.Concrete.EntityFramework;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using Microsoft.Extensions.Configuration;

namespace NewsDataRepository.Concrete.EntityFramework
{
    public class NewsRepository : EfEntityRepositoryBase<News, NContext> 
    {
        public NewsRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}

    