using Application.DTO.Carts;
using Application.UseCases.Commands.Carts;
using Application.UseCases.Queries.Carts;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public CartsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<CartsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCart search, IGetCartsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<CartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddProductToCartDTO dto, ICreateCartCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CartsController>/5]
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] UpdateProductInCartDTO dto, IUpdateProductInCartCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<CartsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductFromCartCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
