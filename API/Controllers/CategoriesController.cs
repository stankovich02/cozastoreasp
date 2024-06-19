using Application.DTO.Categories;
using Application.UseCases.Commands.Categories;
using Application.UseCases.Queries.Brands;
using Application.UseCases.Queries.Categories;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public CategoriesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<CategoriesController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCategory search, [FromServices] IGetCategoriesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<CategoriesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCategoryQuery query)
          => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<CategoriesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDTO dto, [FromServices] ICreateCategoryCommand command)
        {
            _useCaseHandler.HandleCommand(command,dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CategoriesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryDTO dto, IUpdateCategoryCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
