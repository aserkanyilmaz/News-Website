using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDbLibrary.DataAccess;
using MongoDbLibrary.DataAccess.EntityFramework;
using NewsCore.DataAccess.EntityFramework;
using NewsCore.Entities;
using NewsDataRepository.Interfaces;
using NewsDataRepositoryNewsDataRepository.Concrete.EntityFramework;
using NewsEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NewsDataRepository.Concrete.EntityFramework
{
    public class NewsGatewayRepository : INewsRepository 
    {

        private BaseMongoRepository<NewsModel> _baseMongoRepository;
        private EfEntityRepositoryBase<Category,NContext> _categoryRepository;

        EfEntityRepositoryBase<News, NContext> _efEntityRepositoryBase;

        public NewsGatewayRepository(IConfiguration configuration) 
        {
            _baseMongoRepository = new BaseMongoRepository<NewsModel>(configuration);
            _efEntityRepositoryBase = new EfEntityRepositoryBase<News, NContext>(configuration);
            _categoryRepository = new EfEntityRepositoryBase<Category, NContext>(configuration);
        }
        public void Add(News entity)
        {
            _efEntityRepositoryBase.Add(entity);

            NewsModel model = new NewsModel();
            model.NewsContent = entity.NewsContent;
            model.NewsExpo = entity.NewsExpo;
            model.NewsName = entity.NewsName;
            model.NewsTitle = entity.NewsTitle;
            model.CategoryName = _categoryRepository.Get(p => p.CategoryId == entity.CategoryId).CategoryName;

            _baseMongoRepository.Add(model);
        }

        public void Delete(News entity)
        {
            _efEntityRepositoryBase.Delete(entity);

            NewsModel model = new NewsModel();
            model.NewsContent = entity.NewsContent;
            model.NewsExpo = entity.NewsExpo;
            model.NewsName = entity.NewsName;
            model.NewsTitle = entity.NewsTitle;

            _baseMongoRepository.Delete(model);
        }

        public List<News> GetList(Expression<Func<News, bool>> filter = null)
        {
            var haber= _efEntityRepositoryBase.GetList();
            if (haber==null)
            {
                _baseMongoRepository.GetList();
            }
            return haber;
        }

        public void Update(News entity)
        {
            _efEntityRepositoryBase.Update(entity);

            NewsModel model = new NewsModel();
            model.NewsContent = entity.NewsContent;
            model.NewsExpo = entity.NewsExpo;
            model.NewsName = entity.NewsName;
            model.NewsTitle = entity.NewsTitle;

            _baseMongoRepository.Update(model);

        }

        public News Get(Func<object, bool> p)
        {

            var haber = _efEntityRepositoryBase.Get(p);
            if (haber==null)
            {
                _baseMongoRepository.GetType();
            }
            return haber;     
        }

        public News Get(Func<News, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}