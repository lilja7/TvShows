namespace TvShows.Models;

public class Actor
{
    public int id { get; set; }
    
    public String ActorName { get; set; }
    
    public List<TvShow> TvShows { get; set; }
    
    public int DateOfBirth { get; set; }
}