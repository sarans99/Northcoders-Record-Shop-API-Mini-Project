using NorthcodersRecordShopAPI.Data;
using NorthcodersRecordShopAPI.Models;

namespace NorthcodersRecordShopAPI.Repository;

public class AlbumRepository(RecordShopContext context) : IAlbumRepository
{
    private readonly RecordShopContext _context = context;

    public IEnumerable<Album> GetAllAlbums()
    {
        return _context.Albums.ToList();
    }

    public Album? GetAlbumById(int id)
    {
        return _context.Albums.FirstOrDefault(a => a.Id == id);
    }
}
