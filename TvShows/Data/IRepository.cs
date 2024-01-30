using Microsoft.EntityFrameworkCore.Query;
using TvShows.Models;
using TvShows.Models.DTO;

namespace TvShows.Data;

public interface IRepository
{
    Task<List<TvShowDTO>> GetAllTvShowsAsync();

    Task<TvShowDTO> GetTvShowByIdAsync(int id);

    Task<TvShow> UpdateTvShowAsync(int id, TvShow tvShow);

    Task<List<ActorDTO>> GetAllActorsAsync();

    Task<ActorDTO> GetActorByIdAsync(int id);

    Task<Actor> UpdateActorAsync(int id, Actor actor);

    Task CreateTvShowAsync(TvShow tvShow);

    Task CreateActorAsync(Actor actor);
    
    Task<bool> DeleteTvShowAsync(int id);

    Task<bool> DeleteActorAsync(int id);
    
}