using Application.DTO.Reviews;
using Application.UseCases.Commands.Reviews;
using Application.UseCases.Queries.Discounts;
using Application.UseCases.Queries.Reviews;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public ReviewsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<ReviewsController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchReview search, [FromServices] IGetReviewsQuery query)
        => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<ReviewsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetReviewQuery query)
          => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<ReviewsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateReviewDTO dto, ICreateReviewCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ReviewsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateReviewDTO dto, IUpdateReviewCommand command)
        {
            dto.Id = id;

            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<ReviewsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReviewCommand command)
        {
            _useCaseHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
