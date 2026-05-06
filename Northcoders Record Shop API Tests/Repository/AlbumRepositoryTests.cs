using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NorthcodersRecordShopAPI.Data;
using NorthcodersRecordShopAPI.Models;
using NorthcodersRecordShopAPI.Repository;

namespace NorthcodersRecordShopAPITests.Repository;

[TestFixture]
public class AlbumRepositoryTests
{
    private RecordShopContext _context;
    private AlbumRepository _repository;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<RecordShopContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new RecordShopContext(options);
        _repository = new AlbumRepository(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public void GetAllAlbums_ReturnsEmptyList_WhenNoAlbumsExist()
    {
        // ARRANGE - empty database

        // ACT
        var result = _repository.GetAllAlbums();

        // ASSERT
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GetAllAlbums_ReturnsAllAlbums_WhenAlbumsExist()
    {
        // ARRANGE
        _context.Albums.AddRange(
            new Album { Name = "Abbey Road", Artist = "The Beatles", Genre = "Rock", ReleaseYear = 1969, Stock = 5, Price = 12.99m },
            new Album { Name = "Rumours", Artist = "Fleetwood Mac", Genre = "Rock", ReleaseYear = 1977, Stock = 3, Price = 10.99m }
        );
        _context.SaveChanges();

        // ACT
        var result = _repository.GetAllAlbums().ToList();

        // ASSERT
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result, Has.Some.Matches<Album>(a => a.Name == "Abbey Road"));
        Assert.That(result, Has.Some.Matches<Album>(a => a.Name == "Rumours"));
    }
}
