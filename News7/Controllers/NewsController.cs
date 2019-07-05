using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsCore.Abstract;
using NewsDataRepository.Concrete.EntityFramework;
using NewsDataRepository.Interfaces;
using NewsEntities.Entities;
using System.Collections.Generic;

namespace News7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;
        private readonly INewsRepository _newsGatewayRepository;
        public NewsController(INewsService newsService, INewsRepository newsGatewayRepository)
        {
            _newsService = newsService;
            _newsGatewayRepository = newsGatewayRepository;
        }

        [HttpPost("add/mongo")]
        public IActionResult GetTestMongAdd([FromBody] News entity)
        {
            _newsGatewayRepository.Add(entity);

            return Ok("DONE");
        }

        [HttpGet("get/mongo")]
        public IActionResult GetTestMongo([FromBody] News entity)
            {
            _newsGatewayRepository.GetList();
            return Ok("Getting");
            }
        [HttpGet("delete/mongo/{id}")]
        public IActionResult GetTestMongoDel([FromBody] News entity)
        {
            _newsGatewayRepository.Delete(entity);
            return Ok("Deleted");
        }

        [HttpPost("edit/mongo/{id}")]
        public IActionResult UpdateMongo( int id, [FromBody] News entity )
        {
            if (id != entity.NewsId)
                return BadRequest();
            _newsGatewayRepository.Update(entity);
            return Ok("Updated;");                      
        }

        [HttpGet("GetNews")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNews()
        {       
            var result = _newsService.GetAll();
            if (result == null)
                return NotFound();

            return Ok(result);       
        }


        [HttpGet("GetNew/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNew(int id)
        {
            var result = _newsService.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetNewsByCategory/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNewsByCategory(int id)
        {
            var result = _newsService.GetByCategory(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("AddNew")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNew([FromBody] News input)
        {
            _newsService.Add(input);           
            return Ok();
        }

        [HttpPost("EditNew/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateNew(int id,[FromBody] News input)
        {
            if (id != input.NewsId)
                return BadRequest();
            _newsService.Update(input);            
            return Ok();
        }

        [HttpGet("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateNew(int id)
        {
            _newsService.Delete(id);
            return Ok();
        }
    }
}
