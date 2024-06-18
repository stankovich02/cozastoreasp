using Application.DTO.Discounts;
using Application.UseCases.Commands.Discounts;
using Application.UseCases.Queries.Discounts;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public DiscountsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<DiscountController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchDiscount search, [FromServices] IGetDiscountsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query,search));

        // GET api/<DiscountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DiscountController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateDiscountDTO dto, ICreateDiscountCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<DiscountController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateDiscountDTO dto,IUpdateDiscountCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<DiscountController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteDiscountCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
