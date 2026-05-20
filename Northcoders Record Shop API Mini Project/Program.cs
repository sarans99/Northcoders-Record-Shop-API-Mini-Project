using Microsoft.EntityFrameworkCore;
using NorthcodersRecordShopAPI.Data;
using NorthcodersRecordShopAPI.Repository;
using NorthcodersRecordShopAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumService, AlbumService>();

if (builder.Configuration.GetValue<bool>("UseInMemoryDatabase"))
    builder.Services.AddDbContext<RecordShopContext>(opt =>
        opt.UseInMemoryDatabase("RecordShopDb"));
else
    builder.Services.AddDbContext<RecordShopContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("RecordShopDb")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
        policy.WithOrigins("https://localhost:7043", "http://localhost:5258")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazor");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
