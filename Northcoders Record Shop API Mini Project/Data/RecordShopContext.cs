using Microsoft.EntityFrameworkCore;
using NorthcodersRecordShopAPI.Models;

namespace NorthcodersRecordShopAPI.Data;

public class RecordShopContext(DbContextOptions<RecordShopContext> options) : DbContext(options)
{
    public DbSet<Album> Albums { get; set; }
}
