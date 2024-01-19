using Microsoft.EntityFrameworkCore;
using TvShows.Models;

namespace TvShows.Data.Repository;

public class TvShowsRepository
{
    private readonly TvShowDbContext _dbContext;

    public TvShowsRepository()
    {
        _dbContext = new TvShowDbContext();
    }
    

    public void CreateTvShow(TvShow tvshow)
    {
        _dbContext.TvShows.Add(tvshow);
    }
    
    public List<TvShow> GetAllTvShows()
    {
        using (var db = _dbContext)
        {
            return db.TvShows.ToList();
        }
    }

    public List<Actor> GetAllActors()
    {
        using (var db = _dbContext)
        {
            return db.Actors.ToList();
        }
    }
}