//using Microsoft.AspNetCore.Mvc;
//using MongoDbLibrary.DataAccess;
//using MongoDbLibrary.DataAccess.EntityFramework;
//using NewsEntities;
//using NewsEntities.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace News7.Controllers
//{
//    public abstract class BaseMongoController<TModel> : ControllerBase
//        where TModel : IMongoEntity
//    {
//        private readonly BaseMongoRepository<TModel> baseMongoRepository;

//        //public BaseMongoRepository<TModel> BaseMongoRepository { get; set; }

//        public BaseMongoController(BaseMongoRepository<TModel> baseMongoRepository)
//        {
//            BaseMongoRepository = baseMongoRepository;
//            this.baseMongoRepository = baseMongoRepository;
//        }

//        [HttpGet("{id}")]
//        public virtual ActionResult GetModel(string id)
//        {
//            return Ok(this.BaseMongoRepository.GetById(id));
//        }

//        [HttpGet]
//        public virtual ActionResult GetModelList()
//        {
//            return Ok(this.BaseMongoRepository.GetList());
//        }

//        [HttpPost]
//        public virtual ActionResult AddModel(TModel model)
//        {
//            return Ok(this.BaseMongoRepository.Create(model));
//        }

//        [HttpPut]
//        public virtual ActionResult UpdateModel(string id, TModel model)
//        {
//            BaseMongoRepository.Update(id, model);
//            return Ok();
//        }

//        [HttpDelete("{id}")]
//        public virtual void DeleteModel(string id)
//        {
//            BaseMongoRepository.Delete(id);
//        }

//    }
//}