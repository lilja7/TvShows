using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TvShows.Models;

public class TvShow
{

    public TvShow()
    {
        Actors = new List<Actor>();
    }
    
    public int id { get; set; }
    [Required]
    public String Name { get; set; }
    [Required]
    public int Year { get; set; }
    [JsonIgnore]
    public List<Actor> Actors { get; set; }
    [Required]
    public String Genre { get; set; }

}
