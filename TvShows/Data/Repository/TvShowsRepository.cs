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

            db.SaveChanges();

            return actorToUpdate;
        }
    }

    public List<ActorDTO> GetAllActors()
    {
        try
        {
            List<ActorDTO> actorsDtoList;

            using (var db = _dbContext)
            {
                var actors = db.Actors.Include(x => x.TvShows).ToList();
                actorsDtoList = _mapper.Map<List<ActorDTO>>(actors);
            }

            return actorsDtoList;
        }
        catch (Exception e)
        {
            throw new Exception();
        }
    }

    public ActorDTO GetActorById(int id)
    {
       
        
        using (var db = _dbContext)
        {
            Actor actor = db.Actors.Include(x => x.TvShows).FirstOrDefault(x => x.id == id);
            ActorDTO actorToReturn = _mapper.Map<ActorDTO>(actor);
            return actorToReturn;
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
            TvShow tv = db.TvShows.Include(a => a.Actors).FirstOrDefault(x => x.id == id);
            return tv;
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

    public bool DeleteTvShow(int id)
    {
        TvShow tvShowToDelete;
        using (var db = _dbContext)
        {
            tvShowToDelete = db.TvShows.FirstOrDefault(x => x.id == id);
            if (tvShowToDelete == null)
            {
                return false;
            }
            else
            {
                db.TvShows.Remove(tvShowToDelete);
                db.SaveChanges();
                return true;
            }
        }
    }

    public bool DeleteActor(int id)
    {
        using (var db = _dbContext)
        {
            var actorToDelete = db.Actors.FirstOrDefault(x => x.id == id);
            if (actorToDelete == null)
            {
                return false;
            }
            else
            {
                db.Actors.Remove(actorToDelete);
                db.SaveChanges();
                return true;
            }
        }
    }
}