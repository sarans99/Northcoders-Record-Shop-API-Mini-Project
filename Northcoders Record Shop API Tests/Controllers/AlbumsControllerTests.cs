using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using NorthcodersRecordShopAPI.Controllers;
using NorthcodersRecordShopAPI.Models;
using NorthcodersRecordShopAPI.Services;

namespace NorthcodersRecordShopAPITests.Controllers;

[TestFixture]
public class AlbumsControllerTests
{
    private Mock<IAlbumService> _mockService;
    private AlbumsController _controller;

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IAlbumService>();
        _controller = new AlbumsController(_mockService.Object);
    }

    [Test]
    public void GetAllAlbums_Returns200Ok_WithEmptyList_WhenNoAlbumsExist()
    {
        // ARRANGE
        _mockService.Setup(s => s.GetAllAlbums()).Returns([]);

        // ACT
        var result = _controller.GetAllAlbums();

        // ASSERT
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.StatusCode, Is.EqualTo(200));
        var albums = okResult.Value as IEnumerable<Album>;
        Assert.That(albums, Is.Empty);
    }

    [Test]
    public void GetAllAlbums_Returns200Ok_WithListOfAlbums_WhenAlbumsExist()
    {
        // ARRANGE
        var albums = new List<Album>
        {
            new() { Id = 1, Name = "Abbey Road", Artist = "The Beatles", Genre = "Rock", ReleaseYear = 1969, Stock = 5, Price = 12.99m },
            new() { Id = 2, Name = "Rumours", Artist = "Fleetwood Mac", Genre = "Rock", ReleaseYear = 1977, Stock = 3, Price = 10.99m }
        };
        _mockService.Setup(s => s.GetAllAlbums()).Returns(albums);

        // ACT
        var result = _controller.GetAllAlbums();

        // ASSERT
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.StatusCode, Is.EqualTo(200));
        var returnedAlbums = (okResult.Value as IEnumerable<Album>)!.ToList();
        Assert.That(returnedAlbums, Has.Count.EqualTo(2));
        Assert.That(returnedAlbums[0].Name, Is.EqualTo("Abbey Road"));
        Assert.That(returnedAlbums[1].Name, Is.EqualTo("Rumours"));
    }

    [Test]
    public void GetAllAlbums_CallsServiceOnce()
    {
        // ARRANGE
        _mockService.Setup(s => s.GetAllAlbums()).Returns([]);

        // ACT
        _controller.GetAllAlbums();

        // ASSERT
        _mockService.Verify(s => s.GetAllAlbums(), Times.Once);
    }
}
