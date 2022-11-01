using Microsoft.EntityFrameworkCore;
using samuraiApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<SamuraiContext>
    (
    opt=>opt.UseSqlServer("SamuraiConnex")
    .EnableSensitiveDataLogging()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();


app.Run();

