using Application.DTO.UsersBillingAddresses;
using Application.UseCases.Commands.UsersBillingAddresses;
using Application.UseCases.Queries.UsersBillingAddresses;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBillingAddressesController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public UserBillingAddressesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<UserBillingAddressesController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserBillingAddress search, [FromServices] IGetUsersBillingAddressesQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<UserBillingAddressesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //user moze da vidi samo svoje adrese
            return "value";
        }

        // POST api/<UserBillingAddressesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserBillingAddressDTO dto, ICreateUserBillingAddressCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UserBillingAddressesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserBillingAddressDTO dto, IUpdateUserBillingAddressCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<UserBillingAddressesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserBillingAddressCommand command)
        {
           _useCaseHandler.HandleCommand(command, id);

           return NoContent();
        }
    }
}
