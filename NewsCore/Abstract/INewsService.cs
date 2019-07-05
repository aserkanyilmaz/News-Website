using System.Collections.Generic;
using NewsEntities.Entities;

namespace NewsCore.Abstract
{
    public interface INewsService
    {
        List<News> GetAll();
        List<News> GetByCategory(int categoryId);
        void Add(News news);
        void Update(News news);
        void Delete(int newsId);
        News GetById(int newsId);
    }
}