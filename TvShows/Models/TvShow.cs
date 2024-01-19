namespace TvShows.Models;

public class TvShow
{
    public int id { get; set; }
    public String Name { get; set; }
    public int year { get; set; }
    public List<Actor> Actors { get; set; }
    public String Genre { get; set; }
}
