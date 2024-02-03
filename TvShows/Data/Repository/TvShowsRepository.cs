using Microsoft.EntityFrameworkCore;
using TvShows.Models;
using TvShows.Models.DTO;
using AutoMapper;

namespace TvShows.Data.Repository;

public class TvShowsRepository : IRepository
{
    private readonly IMapper _mapper;
    private readonly TvShowDbContext _dbContext;

    public TvShowsRepository(IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = new TvShowDbContext();
    }

    public async Task<TvShow> UpdateTvShowAsync(int id, TvShow tvshow)
    {
        TvShow tvShowToUpdate;
        
        using (var db = _dbContext)
        {
            tvShowToUpdate = await db.TvShows.FirstOrDefaultAsync(x => x.Id == id);

            if (tvShowToUpdate == null)
            {
                return null;
            }

            tvShowToUpdate.Name = tvshow.Name;
            tvShowToUpdate.Year = tvshow.Year;
            tvShowToUpdate.Genre = tvshow.Genre;
            tvShowToUpdate.Rating = tvshow.Rating;

            await db.SaveChangesAsync();

            return tvShowToUpdate;
        }
    }

    public async Task<Actor> UpdateActorAsync(int id, Actor actor)
    {
        Actor actorToUpdate;
        using (var db = _dbContext)
        {
            actorToUpdate = await db.Actors.Include(t => t.TvShows).FirstOrDefaultAsync(x => x.Id == id);

            if (actorToUpdate == null)
            {
                return null;
            }

            actorToUpdate.ActorName = actor.ActorName;
            actorToUpdate.DateOfBirth = actor.DateOfBirth;
            actorToUpdate.FavoriteColor = actor.FavoriteColor;
            
            await db.SaveChangesAsync();

            return actorToUpdate;
        }
    }

    public async Task<List<ActorDTO>> GetAllActorsAsync()
    {
        List<ActorDTO> actorsDtoList;

        using (var db = _dbContext)
        {
            var actors = await db.Actors.Include(x => x.TvShows).ToListAsync();
            actorsDtoList = _mapper.Map<List<ActorDTO>>(actors);
        }

        return actorsDtoList;
    }

    public async Task<ActorDTO> GetActorByIdAsync(int id)
    {
        using (var db = _dbContext)
        {
            Actor actor = await db.Actors.Include(x => x.TvShows).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ActorDTO>(actor);
            
        }
    }

    public async Task<List<TvShowDTO>> GetAllTvShowsAsync()
    {
        using (var db = _dbContext)
        {
            var tvShows = await db.TvShows.Include(x => x.Actors).ToListAsync();
            return  _mapper.Map<List<TvShowDTO>>(tvShows);
            
        }
    }

    public async Task<TvShowDTO> GetTvShowByIdAsync(int id)
    {
        using (var db = _dbContext)
        {
            TvShow tv = await db.TvShows.Include(a => a.Actors).FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TvShowDTO>(tv);
        }
    }

    public async Task CreateTvShowAsync(TvShow tvShow)
    {
        using (var db = _dbContext)
        {
            await db.TvShows.AddAsync(tvShow);
            await db.SaveChangesAsync();
        }
    }

    public async Task CreateActorAsync(Actor actor)
    {
        using (var db = _dbContext)
        {
            await db.Actors.AddAsync(actor);
            await db.SaveChangesAsync();
        }
    }

    public async Task<bool> DeleteTvShowAsync(int id)
    {
        TvShow tvShowToDelete;
        using (var db = _dbContext)
        {
            tvShowToDelete = await db.TvShows.FirstOrDefaultAsync(x => x.Id == id);
            if (tvShowToDelete == null)
            {
                return false;
            }
            else
            {
                db.TvShows.Remove(tvShowToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }

    public async Task<bool> DeleteActorAsync(int id)
    {
        using (var db = _dbContext)
        {
            var actorToDelete = await db.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actorToDelete == null)
            {
                return false;
            }
            else
            {
                db.Actors.Remove(actorToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
}