using Microsoft.AspNetCore.Mvc;
using TvShows.Data.Repository;
using TvShows.Models;

namespace TvShows.Controllers
{
    [ApiController]
    [Route("api/tvshows")]
    public class TvShowsController : ControllerBase
    {
        private readonly TvShowsRepository _repo;

        public TvShowsController()
        {
            _repo = new TvShowsRepository();
        }

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

        [HttpPost]
        public IActionResult CreateTvShow(TvShow tvShow)
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
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }

    // TryCATCH  POST PUT DELETE
}