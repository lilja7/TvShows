using Microsoft.EntityFrameworkCore;
using TvShows.Models;

namespace TvShows.Data.Repository;

public class TvShowsRepository : IRepository
{
    private readonly TvShowDbContext _dbContext;

    public TvShowsRepository()
    {
        _dbContext = new TvShowDbContext();
    }
    
    public List<Actor> GetAllActors()
    {
        using (var db = _dbContext)
        {
            return db.Actors.ToList();
        }
    }

    public Actor GetActorById(int id)
    {
        using (var db = _dbContext)
        {
            return db.Actors.FirstOrDefault(x => x.id == id);
        }
    }
    
    public List<TvShow> GetAllTvShows()
    {
        using (var db = _dbContext)
        {
            return db.TvShows.ToList();
        }
    }
    public TvShow GetTvShowById(int id)
    {
        using (var db = _dbContext)
        {
            return db.TvShows.FirstOrDefault(x => x.id == id);
        }
            
    }
    public void CreateTvShow(TvShow tvShow)
    {
        using (var db = _dbContext)
        {
            db.TvShows.Add(tvShow);
            db.SaveChanges();
        }
    }

    public void CreateActor(Actor actor)
    {
        using (var db = _dbContext)
        {
            db.Actors.Add(actor);
            db.SaveChanges();
        }
    }
    
}