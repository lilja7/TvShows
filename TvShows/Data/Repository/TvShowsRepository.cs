using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TvShows.Models;

namespace TvShows.Data.Repository;

public class TvShowsRepository : IRepository
{
    private readonly TvShowDbContext _dbContext;

    public TvShowsRepository()
    {
        _dbContext = new TvShowDbContext();
    }

    public TvShow UpdateTvShow(int id, TvShow tvshow)
    {
        TvShow tvShowToUpdate;
        using (var db = _dbContext)
        {
            tvShowToUpdate = db.TvShows.FirstOrDefault(x => x.id == id);
            
            if (tvShowToUpdate == null)
            {
                return null;
            }

            tvShowToUpdate.Name = tvshow.Name;
            tvShowToUpdate.Actors = tvshow.Actors;
            tvShowToUpdate.Year = tvshow.Year;
            tvShowToUpdate.Genre = tvshow.Genre;

            db.SaveChanges();

            return tvShowToUpdate;
        }
        
    }
    public Actor UpdateActor(int id, Actor actor)
    {
        Actor actorToUpdate;
        using (var db = _dbContext)
        {
            actorToUpdate = db.Actors.FirstOrDefault(x => x.id == id);
            
            if (actorToUpdate == null)
            {
                return null;
            }

            actorToUpdate.ActorName = actor.ActorName;
            actorToUpdate.DateOfBirth = actor.DateOfBirth;
            actorToUpdate.TvShows = actor.TvShows;

            db.SaveChanges();

            return actorToUpdate;
        }
    }

    public List<Actor> GetAllActors()
    {
        using (var db = _dbContext)
        {
            return db.Actors.Include(x => x.TvShows).ToList();
        }
    }

    public Actor GetActorById(int id)
    {
        using (var db = _dbContext)
        {
            return db.Actors.Include(x => x.TvShows).FirstOrDefault(x => x.id == id);
        }
    }
    

    public List<TvShow> GetAllTvShows()
    {
        using (var db = _dbContext)
        {
            return db.TvShows.Include(x => x.Actors).ToList();
        }
    }
    public TvShow GetTvShowById(int id)
    {
        using (var db = _dbContext)
        {
            return db.TvShows.Include(a => a.Actors).FirstOrDefault(x => x.id == id);
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

    public void DeleteTvShow(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteActor(int id)
    {
        throw new NotImplementedException();
    }
}