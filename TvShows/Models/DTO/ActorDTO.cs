
using Newtonsoft.Json;

namespace TvShows.Models.DTO;

public class ActorDTO
{
    public ActorDTO()
    {
        TvShows = new List<TvShow>();
    }
    public int Id { get; set; }
    public String ActorName { get; set; }
    
    public int DateOfBirth { get; set; }
    
    public List<TvShow> TvShows { get; set; }
    
}