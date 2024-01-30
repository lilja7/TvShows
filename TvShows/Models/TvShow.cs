using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TvShows.Models;

public class TvShow
{

    public TvShow()
    {
        Actors = new List<Actor>();
    }
    
    public int id { get; set; }
    [Required]
    [MaxLength(255)]
    public String Name { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    [MaxLength(30)]
    public String Genre { get; set; }
    public int Rating { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public List<Actor> Actors { get; set; }
  

}
