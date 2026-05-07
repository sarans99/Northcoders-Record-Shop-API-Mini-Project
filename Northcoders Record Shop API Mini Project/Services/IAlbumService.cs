using NorthcodersRecordShopAPI.Models;

namespace NorthcodersRecordShopAPI.Services;

public interface IAlbumService
{
    IEnumerable<Album> GetAllAlbums();
    Album? GetAlbumById(int id);
    Album AddAlbum(Album album);
    Album? UpdateAlbum(int id, Album album);
    bool DeleteAlbum(int id);
}
