using Application.DTO.Brands;
using Application.DTO.Colors;
using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Colors;
using Application.UseCases.Queries.Colors;
using Application.UseCases.Queries.Genders;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public ColorsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }
        // GET: api/<ColorsController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchColor search, [FromServices] IGetColorsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<ColorsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateColorDTO dto, ICreateColorCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateColorDTO dto, IUpdateColorCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteColorCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
