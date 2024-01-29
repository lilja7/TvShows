using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TvShows.Data;
using TvShows.Models;
using TvShows.Models.DTO;

namespace TvShows.Controllers
{
    [Route("api/tvshows")]
    [Controller]
    public class TvShowsController : ControllerBase
    {
        private readonly IRepository _repo;

        public TvShowsController(IRepository repo)
        {
            _repo = repo;
        }
        
        //Get ALL tvshows
        [HttpGet]
        public async Task<ActionResult<List<TvShow>>> GetAllTvShows()
        {
            try
            {
                var tvShows = await _repo.GetAllTvShowsAsync();
                return Ok(tvShows);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        //Get tvshow by id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TvShowDTO>> GetTvShowById(int id)
        {
            try
            {
                TvShowDTO tvShow = await _repo.GetTvShowByIdAsync(id);
                if (tvShow == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(tvShow);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        //Create tvshow
        [HttpPost]
        public async Task<IActionResult> CreateTvShow([FromBody] TvShow tvShow)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repo.CreateTvShowAsync(tvShow);
                    return CreatedAtAction(nameof(GetTvShowById), new { id = tvShow.id }, tvShow);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        //Update tvshow
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTvShow(int id, [FromBody]TvShow tvShow)
        {
          
            try
            {
                TvShow updatedTvShow = await _repo.UpdateTvShowAsync(id, tvShow);
                
                if (updatedTvShow == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetTvShowById), new { id = updatedTvShow.id }, updatedTvShow);
                    
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        //Delete tvshow
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<TvShow>> DeleteTvShow(int id)
        {
            try
            {
                bool deleted = await _repo.DeleteTvShowAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }

}