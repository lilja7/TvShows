namespace TvShows.Models;

public class TvShow
{
    public int id { get; set; }
    public String Name { get; set; }
    public int Year { get; set; }
    public List<Actor> Actors { get; set; }
    public String Genre { get; set; }
    
    public List<ActorTvShow> ActorTvShows { get; set; }

}
