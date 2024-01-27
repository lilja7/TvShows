using Microsoft.AspNetCore.Mvc;
using TvShows.Data;
using TvShows.Models;

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
        public ActionResult<List<TvShow>> GetAllTvShows()
        {
            try
            {
                var tvShows = _repo.GetAllTvShows();
                return Ok(tvShows);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        
        //Get tvshow by id
        [HttpGet]
        [Route("{id}")]
        public ActionResult<TvShow> GetTvShowById(int id)
        {
            try
            {
                return Ok(_repo.GetTvShowById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        
        //Create tvshow
        [HttpPost]
        public IActionResult CreateTvShow([FromBody] TvShow tvShow)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.CreateTvShow(tvShow);
                    return CreatedAtAction(nameof(GetTvShowById), new { id = tvShow.id }, tvShow);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        
        //Update tvshow
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTvShow(int id, TvShow tvShow)
        {
          
            try
            {
                TvShow updatedTvShow = _repo.UpdateTvShow(id, tvShow);
                
                if (updatedTvShow == null)
                {
                    return NotFound();
                }
                else
                {
                    return  CreatedAtAction(nameof(GetTvShowById), new { id = updatedTvShow.id }, updatedTvShow);
                    
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        
        //Delete tvshow
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTvShow(int id)
        {
            try
            {
                _repo.DeleteTvShow(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }

}