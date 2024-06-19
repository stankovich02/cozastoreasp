using Application.DTO.Users;
using Application.UseCases.Commands.Users;
using Application.UseCases.Queries.Users;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UsersController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromServices] IGetUsersQuery query, [FromQuery] SearchUser search)
            => Ok(_useCaseHandler.HandleQuery(query, search));

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDTO dto, [FromServices] IRegisterUserCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDTO data, [FromServices] IUpdateUserCommand command)
        {
            data.Id = id;
            
            _useCaseHandler.HandleCommand(command, data);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [Authorize]
        [HttpPatch("{id}/image")]
        public IActionResult ChangeImage(int id, [FromBody] UpdateUserImageDTO dto, [FromServices] IUpdateUserImageCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateUserAccessDTO dto,
                                                  [FromServices] IUpdateUserAccessCommand command)
        {
            dto.UserId = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
    }
}
