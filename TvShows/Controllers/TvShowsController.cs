using Microsoft.AspNetCore.Mvc;
using TvShows.Data.Repository;
using TvShows.Models;

namespace TvShows.Controllers
{
    [ApiController]
    [Route("api/tvshows")]
    public class TvShowsController : ControllerBase
    {
        private readonly MockRepository _repo;

        public TvShowsController(MockRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("all")]
        public ActionResult<List<TvShow>> GetAllTvShows()
        {
            var tvShows = _repo.GetAllTvShows();
            return Ok(tvShows);
        }

        [HttpGet("actors")]
        public ActionResult<List<Actor>> GetAllActors()
        {
            var actors = _repo.GetAllActors();
            return Ok(actors);
        }
    }

}

