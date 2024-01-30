using Microsoft.AspNetCore.Mvc;
using TvShows.Data;
using TvShows.Data.Repository;
using TvShows.Models;
using TvShows.Models.DTO;

namespace TvShows.Controllers;

[Route("api/actors")]
[Controller]
public class ActorController : ControllerBase
{
    private readonly IRepository _repo;

    public ActorController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<ActorDTO>>> GetAllActors()
    {
        try
        {
            List<ActorDTO> actors = await _repo.GetAllActorsAsync();
            return Ok(actors);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ActorDTO>> GetActorById(int id)
    {
        try
        {
            ActorDTO actor = await _repo.GetActorByIdAsync(id);
            if(actor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(actor);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateActor([FromBody] Actor actor)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateActorAsync(actor);
                return CreatedAtAction(nameof(GetActorById), new { id = actor.Id }, actor);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateActor(int id, [FromBody] Actor actor)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var updatedActor = await _repo.UpdateActorAsync(id, actor);
                if (updatedActor == null)
                {
                    return NotFound();
                }

                return CreatedAtAction(nameof(GetActorById), new { id = updatedActor.Id }, updatedActor);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Actor>> DeleteActor(int id)
    {
        try
        {
            bool deleted = await _repo.DeleteActorAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
    
}