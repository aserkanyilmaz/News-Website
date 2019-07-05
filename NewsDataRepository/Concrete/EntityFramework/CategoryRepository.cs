using NewsCore.DataAccess.EntityFramework;
using System.Threading.Tasks;
using NewsEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsDataRepository.Interfaces;
using NewsDataRepositoryNewsDataRepository.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Microsoft.Extensions.Configuration;

namespace NewsDataRepository.Concrete.EntityFramework
{
    public class CategoryRepository : EfEntityRepositoryBase<Category, NContext>, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
//public CategoryRepository() : base()
        //{
        //    //Categories = new List<Category>()
        //    //{
        //    //new Category() { CategoryId = 1, CategoryName = "SPOR" },
        //    //new Category() { CategoryId = 2, CategoryName = "GÜNDEM" },
        //    //new Category() { CategoryId = 3, CategoryName="SEÇİM"},
        //    //new Category() { CategoryId = 4, CategoryName= "EKONOMİ"}
        //    //};
        //}      