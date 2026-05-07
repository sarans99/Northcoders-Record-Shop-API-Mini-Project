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

    public Album AddAlbum(Album album)
    {
        _context.Albums.Add(album);
        _context.SaveChanges();
        return album;
    }

    public bool DeleteAlbum(int id)
    {
        var album = _context.Albums.FirstOrDefault(a => a.Id == id);
        if (album == null) return false;

        _context.Albums.Remove(album);
        _context.SaveChanges();
        return true;
    }

    public Album? UpdateAlbum(int id, Album album)
    {
        var existing = _context.Albums.FirstOrDefault(a => a.Id == id);
        if (existing == null) return null;

        existing.Name = album.Name;
        existing.Artist = album.Artist;
        existing.Genre = album.Genre;
        existing.ReleaseYear = album.ReleaseYear;
        existing.Stock = album.Stock;
        existing.Price = album.Price;

        _context.SaveChanges();
        return existing;
    }
}
