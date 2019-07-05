using NewsEntities.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using NewsDataRepository.Interfaces;
using NewsCore.Abstract;

namespace NewsBusiness.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetAll() => _categoryRepository.GetList();
    }
}

            
        
   
