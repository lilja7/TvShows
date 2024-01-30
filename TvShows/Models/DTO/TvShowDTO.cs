
namespace TvShows.Models.DTO;

public class TvShowDTO
{
    public TvShowDTO()
    {
        Actors = new List<Actor>();
    }
    public int Id { get; set; }

    public String Name { get; set; }

    public int Year { get; set; }
    public List<Actor> Actors { get; set; }

    public String Genre { get; set; }
}