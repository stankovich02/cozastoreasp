using Application.DTO.Brands;
using Application.DTO.Genders;
using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Genders;
using Application.UseCases.Queries.Discounts;
using Application.UseCases.Queries.Genders;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public GendersController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }
        // GET: api/<GendersController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchGender search, [FromServices] IGetGendersQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<GendersController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetGenderQuery query)
          => Ok(_useCaseHandler.HandleQuery(query, id));

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateGenderDTO dto, ICreateGenderCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateGenderDTO dto, IUpdateGenderCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGenderCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
