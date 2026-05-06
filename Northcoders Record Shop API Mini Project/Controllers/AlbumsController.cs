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
}
