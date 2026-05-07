using NorthcodersRecordShopAPI.Models;

namespace NorthcodersRecordShopAPI.Repository;

public interface IAlbumRepository
{
    IEnumerable<Album> GetAllAlbums();
    Album? GetAlbumById(int id);
    Album AddAlbum(Album album);
    Album? UpdateAlbum(int id, Album album);
}
