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
        new TvShow() { Genre = "Crime", id = 2, Year = 2000, Name = "CSI" },
        new TvShow() { Genre = "Comedy", id = 3, Year = 2007, Name = "The Big Bang Theory" },
    };

    public List<ActorDTO> Actors { get; } = new List<ActorDTO>()
    {
        new ActorDTO() { ActorName = "Thomas Gibson", id = 1 },
    };

    // Getter methods to access the data
    public async Task<List<TvShowDTO>> GetAllTvShowsAsync()
    {
        throw new NotImplementedException();

    }

    public async Task<TvShow> UpdateTvShowAsync(int id, TvShow tvShow)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ActorDTO>> GetAllActorsAsync()
    {
        return Actors;
    }
    

    public async Task<ActorDTO> GetActorByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Actor> UpdateActorAsync(int id, Actor actor)
    {
        throw new NotImplementedException();
    }
    

    public Task<TvShowDTO> GetTvShowByIdAsync(int id)
    {
        throw new NotImplementedException();

    }

    public Task CreateTvShowAsync(TvShow tvShow)
    {
        throw new NotImplementedException();
    }

    public Task CreateActorAsync(Actor actor)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTvShowAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteActorAsync(int id)
    {
        throw new NotImplementedException();
    }
    }
}