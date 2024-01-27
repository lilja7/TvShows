using System.ComponentModel.DataAnnotations;

namespace TvShows.Models;

public class Actor
{
    public Actor()
    {
        TvShows = new List<TvShow>();
    }
    public int id { get; set; }
    [Required]
    public String ActorName { get; set; }
    
    public List<TvShow>? TvShows { get; set; } 
    [Required]
    public int DateOfBirth { get; set; }
    
}
