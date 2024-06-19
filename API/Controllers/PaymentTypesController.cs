using Application.DTO.Brands;
using Application.DTO.PaymentTypes;
using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.PaymentTypes;
using Application.UseCases.Queries.Discounts;
using Application.UseCases.Queries.PaymentTypes;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public PaymentTypesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }
        // GET: api/<PaymentTypesController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchPaymentType search, [FromServices] IGetPaymentTypesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<PaymentTypesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPaymentTypeQuery query)
          => Ok(_useCaseHandler.HandleQuery(query, id));

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreatePaymentTypeDTO dto, ICreatePaymentTypeCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePaymentTypeDTO dto, IUpdatePaymentTypeCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePaymentTypeCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
