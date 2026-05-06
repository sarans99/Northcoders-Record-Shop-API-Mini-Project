using Moq;
using NUnit.Framework;
using NorthcodersRecordShopAPI.Models;
using NorthcodersRecordShopAPI.Repository;
using NorthcodersRecordShopAPI.Services;

namespace NorthcodersRecordShopAPITests.Services;

[TestFixture]
public class AlbumServiceTests
{
    private Mock<IAlbumRepository> _mockRepo;
    private AlbumService _service;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IAlbumRepository>();
        _service = new AlbumService(_mockRepo.Object);
    }

    [Test]
    public void GetAllAlbums_ReturnsEmptyList_WhenNoAlbumsExist()
    {
        // ARRANGE
        _mockRepo.Setup(r => r.GetAllAlbums()).Returns([]);

        // ACT
        var result = _service.GetAllAlbums();

        // ASSERT
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GetAllAlbums_ReturnsAllAlbums_WhenAlbumsExist()
    {
        // ARRANGE
        var albums = new List<Album>
        {
            new() { Id = 1, Name = "Abbey Road", Artist = "The Beatles", Genre = "Rock", ReleaseYear = 1969, Stock = 5, Price = 12.99m },
            new() { Id = 2, Name = "Rumours", Artist = "Fleetwood Mac", Genre = "Rock", ReleaseYear = 1977, Stock = 3, Price = 10.99m }
        };
        _mockRepo.Setup(r => r.GetAllAlbums()).Returns(albums);

        // ACT
        var result = _service.GetAllAlbums().ToList();

        // ASSERT
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result[0].Name, Is.EqualTo("Abbey Road"));
        Assert.That(result[1].Name, Is.EqualTo("Rumours"));
    }

    [Test]
    public void GetAllAlbums_CallsRepositoryOnce()
    {
        // ARRANGE
        _mockRepo.Setup(r => r.GetAllAlbums()).Returns([]);

        // ACT
        _service.GetAllAlbums();

        // ASSERT
        _mockRepo.Verify(r => r.GetAllAlbums(), Times.Once);
    }
}
