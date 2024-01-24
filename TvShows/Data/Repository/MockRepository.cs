using System.Collections.Generic;
using TvShows.Models;

namespace TvShows.Data.Repository
{
    public class MockRepository : Interpository

    {
    private readonly TvShowDbContext _dbContext;

    public List<TvShow> TvShows { get; } = new List<TvShow>()
    {
        new TvShow() { Genre = "FBi", id = 1, Year = 2005, Name = "Criminal Minds" },
        new TvShow() { Genre = "Crime", id = 2, Year = 2000, Name = "CSI" }
    };

    public List<Actor> Actors { get; } = new List<Actor>()
    {
        new Actor() { ActorName = "Thomas Gibson", id = 1, DateOfBirth = 1964 },
    };

    // Getter methods to access the data
    public List<TvShow> GetAllTvShows()
    {
        return TvShows;
    }

    public List<Actor> GetAllActors()
    {
        return Actors;
    }

    public Actor GetActorById(int id)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void CreateActor(Actor actor)
    {
        throw new NotImplementedException();
    }
    }
}