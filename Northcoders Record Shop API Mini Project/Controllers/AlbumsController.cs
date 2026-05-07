using Microsoft.AspNetCore.Mvc;
using NorthcodersRecordShopAPI.Models;
using NorthcodersRecordShopAPI.Services;

namespace NorthcodersRecordShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController(IAlbumService albumService) : ControllerBase
{
    private readonly IAlbumService _albumService = albumService;

    [HttpGet]
    public ActionResult<IEnumerable<Album>> GetAllAlbums()
    {
        return Ok(_albumService.GetAllAlbums());
    }

    [HttpGet("{id}")]
    public ActionResult<Album> GetAlbumById(int id)
    {
        var album = _albumService.GetAlbumById(id);
        if (album == null) return NotFound();
        return Ok(album);
    }

    [HttpPost]
    public ActionResult<Album> AddAlbum([FromBody] Album album)
    {
        var createdAlbum = _albumService.AddAlbum(album);
        return CreatedAtAction(nameof(GetAlbumById), new { id = createdAlbum.Id }, createdAlbum);
    }

    [HttpPut("{id}")]
    public ActionResult<Album> UpdateAlbum(int id, [FromBody] Album album)
    {
        var updatedAlbum = _albumService.UpdateAlbum(id, album);
        if (updatedAlbum == null) return NotFound();
        return Ok(updatedAlbum);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAlbum(int id)
    {
        var deleted = _albumService.DeleteAlbum(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
