using Application.DTO.Brands;
using Application.DTO.Categories;
using Application.UseCases.Commands.Brands;
using Application.UseCases.Queries.Brands;
using Application.UseCases.Queries.Categories;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public BrandsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchBrand search, [FromServices] IGetBrandsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<BrandsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetBrandQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, id));

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateBrandDTO dto, ICreateBrandCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBrandDTO dto,IUpdateBrandCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
