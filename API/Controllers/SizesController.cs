using Application.DTO.Brands;
using Application.DTO.Sizes;
using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Sizes;
using Application.UseCases.Queries.Reviews;
using Application.UseCases.Queries.Sizes;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public SizesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }
        // GET: api/<SizesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchSize search, [FromServices] IGetSizesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSizeQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, id));

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateSizeDTO dto, ICreateSizeCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateSizeDTO dto, IUpdateSizeCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteSizeCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
