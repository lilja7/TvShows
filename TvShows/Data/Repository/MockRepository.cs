using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
using TvShows.Models;
using TvShows.Models.DTO;

namespace TvShows.Data.Repository
{
    public class MockRepository : IRepository

    {
    private readonly TvShowDbContext _dbContext;

    public List<TvShow> TvShows { get; } = new List<TvShow>()
    {
        new TvShow() { Genre = "FBi", id = 1, Year = 2005, Name = "Criminal Minds" },
        new TvShow() { Genre = "Crime", id = 2, Year = 2000, Name = "CSI" }
    };

    public List<ActorDTO> Actors { get; } = new List<ActorDTO>()
    {
        new ActorDTO() { ActorName = "Thomas Gibson", id = 1 },
    };

    // Getter methods to access the data
    public List<TvShow> GetAllTvShows()
    {
        return TvShows;
    }

    public TvShow UpdateTvShow(int id, TvShow tvShow)
    {
        throw new NotImplementedException();
    }

    public List<ActorDTO> GetAllActors()
    {
        return Actors;
    }

    public ActorDTO GetActorById(int id)
    {
        throw new NotImplementedException();
    }

    public Actor UpdateActor(int id, Actor actor)
    {
        throw new NotImplementedException();
    }

    public TvShow? GetTvShowById(int id)
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

    public bool DeleteTvShow(int id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteActor(int id)
    {
        throw new NotImplementedException();
    }
    }
}