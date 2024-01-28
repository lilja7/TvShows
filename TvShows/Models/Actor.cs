using System.ComponentModel.DataAnnotations;
using TvShows.Models.DTO;

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
    [Required]
    public int DateOfBirth { get; set; }
    public List<TvShow> TvShows { get; set; } 
    
    
}
