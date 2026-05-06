using NorthcodersRecordShopAPI.Models;
using NorthcodersRecordShopAPI.Repository;

namespace NorthcodersRecordShopAPI.Services;

public class AlbumService(IAlbumRepository albumRepository) : IAlbumService
{
    private readonly IAlbumRepository _albumRepository = albumRepository;

    public IEnumerable<Album> GetAllAlbums()
    {
        return _albumRepository.GetAllAlbums();
    }

    public Album? GetAlbumById(int id)
    {
        return _albumRepository.GetAlbumById(id);
    }

    public Album AddAlbum(Album album)
    {
        return _albumRepository.AddAlbum(album);
    }
}
