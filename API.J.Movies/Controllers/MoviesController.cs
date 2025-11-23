using API.J.Movies.DAL.Models.Dto;
using API.J.Movies.Services;
using API.J.Movies.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.J.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<MovieDto>>> GetMoviesAsync()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }
        [HttpGet("{id:int}", Name = "GetMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
        {
            try
            {
                var movieDto = await _movieService.GetMovieAsync(id);
                return Ok(movieDto);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No se encontró"))
            {
                return NotFound(new { ex.Message });
            }
        }

        [HttpPost(Name = "CreateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<MovieDto>> CreateMovieAsync([FromBody] MovieCreateUpdateDto movieCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdMovie = await _movieService.CreateMovieAsync(movieCreateDto);
                return CreatedAtRoute("GetMovieAsync", new { id = createdMovie.Id }, createdMovie);

            }
            catch (ArgumentException ex) when (ex.Message.Contains("La duración de la película"))
            {
                return Conflict(ex.Message);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe"))
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id:int}", Name = "UpdateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<MovieDto>> UpdateMovieAsync(int id, [FromBody] MovieCreateUpdateDto movieUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedMovie = await _movieService.UpdateMovieAsync(id, movieUpdateDto);
                return Ok(updatedMovie);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe"))
            {
                return Conflict(new { ex.Message });
            }
            catch (ArgumentException ex) when (ex.Message.Contains("La duración de la película"))
            {
                return Conflict(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No se encontró"))
            {
                return NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteMovieAsync")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                var deletedMovie = await _movieService.DeleteMovieAsync(id);
                return Ok(deletedMovie);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { ex.Message });
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No se encontró"))
            {
                return NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
