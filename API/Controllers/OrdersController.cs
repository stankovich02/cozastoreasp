using Application.DTO.Orders;
using Application.UseCases.Commands.Orders;
using Application.UseCases.Queries.Orders;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public OrdersController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<OrdersController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchOrder search, [FromServices] IGetOrdersQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDTO dto, ICreateOrderCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<OrdersController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
