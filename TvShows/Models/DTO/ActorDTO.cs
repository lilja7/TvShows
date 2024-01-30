
namespace TvShows.Models.DTO;

public class ActorDTO
{
    public ActorDTO()
    {
        TvShows = new List<TvShowDTO>();
    }
    public int Id { get; set; }
    public String ActorName { get; set; }
    
    public int DateOfBirth { get; set; }
    
    public List<TvShowDTO> TvShows { get; set; }
    
}