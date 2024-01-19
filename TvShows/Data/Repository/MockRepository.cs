using System.Collections.Generic;
using TvShows.Models;

namespace TvShows.Data.Repository
{
    public class MockRepository
    {
        public List<TvShow> TvShows { get; } = new List<TvShow>()
        {
            new TvShow() { Genre = "FBi", id = 1, year = 2005, Name = "Criminal Minds" },
            new TvShow() { Genre = "Crime", id = 2, year = 2000, Name = "CSI" }
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
    }
}