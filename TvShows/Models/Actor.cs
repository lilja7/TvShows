using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TvShows.Models.DTO;

namespace TvShows.Models;

public class Actor
{
    public Actor()
    {
        TvShows = new List<TvShow>();
    }
    public int Id { get; set; }
    [Required]
    public String ActorName { get; set; }
    [Required]
    public int DateOfBirth { get; set; }
    [JsonIgnore]
    public List<TvShow> TvShows { get; set; } 
    
    
}
