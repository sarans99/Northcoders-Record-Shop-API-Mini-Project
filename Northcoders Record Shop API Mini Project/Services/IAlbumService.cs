using NorthcodersRecordShopAPI.Models;

namespace NorthcodersRecordShopAPI.Services;

public interface IAlbumService
{
    IEnumerable<Album> GetAllAlbums();
}
