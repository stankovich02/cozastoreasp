using Application.DTO.Messages;
using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Messages;
using Application.UseCases.Queries.Discounts;
using Application.UseCases.Queries.Messages;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
         private readonly UseCaseHandler _useCaseHandler;

        public MessagesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<MessagesController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchMessage search, IGetMessagesQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<MessagesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetMessageQuery query)
          => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<MessagesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateMessageDTO dto, ICreateMessageCommand command)
        {
            _useCaseHandler.HandleCommand(command,dto);

            return StatusCode(StatusCodes.Status201Created);    
        }

        // DELETE api/<MessagesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteMessageCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
