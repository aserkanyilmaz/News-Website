using MongoDB.Driver;
using NewsCore.Abstract;
using NewsDataRepository.Interfaces;
using NewsDataRepositoryNewsDataRepository.Concrete.EntityFramework;
using NewsEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBusiness.Concrete
{
    public class NewsService : INewsService
    {
        private INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)//,IDatabaseSettings settings)
        {
            _newsRepository = newsRepository;
          //  var client = new MongoClient(settings.ConnectionString);
          //  var database = client.GetDatabase(settings.Database);
        }

        public void Add(News news)
        {
            _newsRepository.Add(news);
        }

        public void Delete(int newsId)
        {
            _newsRepository.Delete(new News { NewsId = newsId });
        }

        public List<News> GetByCategory(int CategoryId)
        {
            return _newsRepository.GetList(p => p.CategoryId == CategoryId || CategoryId == 0);
        }

        public News GetById(int newsId)
        {
            //throw new NotImplementedException();
            return _newsRepository.Get(p => p.NewsId == newsId);
        }

        public void Update(News news)
        {
            _newsRepository.Update(news);
        }

        public List<News> GetAll()
        {
            return _newsRepository.GetList();
        }
    }
}
