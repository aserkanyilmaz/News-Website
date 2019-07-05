using NewsEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace NewsCore.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}