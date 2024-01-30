using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
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
    
    public string FavoriteColor { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public List<TvShow> TvShows { get; set; } 
    
    
}
