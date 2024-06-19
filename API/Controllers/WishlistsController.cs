using Application.DTO.Wishlists;
using Application.UseCases.Commands.Wishlists;
using Application.UseCases.Queries;
using Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public WishlistsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<WishlistsController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchWishlist search, [FromServices] IGetWishlistsQuery query)
         => Ok(_useCaseHandler.HandleQuery(query, search));

        // POST api/<WishlistsController>
        [HttpPost]
        public IActionResult Post([FromBody] AddProductToWishlistDTO dto,IAddProductToWishlistCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<WishlistsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveProductFromWishlistCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
