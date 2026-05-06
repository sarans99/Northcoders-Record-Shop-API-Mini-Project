using NorthcodersRecordShopAPI.Models;

namespace NorthcodersRecordShopAPI.Repository;

public interface IAlbumRepository
{
    IEnumerable<Album> GetAllAlbums();
}
