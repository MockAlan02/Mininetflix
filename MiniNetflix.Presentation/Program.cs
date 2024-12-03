using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Interface;
using MiniNetflix.Core.Interface.Repository;
using MiniNetflix.Core.Interface.Services;
using MiniNetflix.Core.Service;
using MiniNetflix.InfraEstructure.Context;
using MiniNetflix.InfraEstructure.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("sqlConnection");
builder.Services.AddDbContext<MiniNetflixContext>(option => option.UseSqlServer(connection), ServiceLifetime.Transient);

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ISerieService, SerieService>();
builder.Services.AddScoped<IProductionService, ProductionService>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IProductionRepository, ProductionRepository>();
builder.Services.AddScoped<IGenreSerieRepository, GenreSerieRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)); // Allow any origin  


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MiniNetflix}/{action=Index}/{id?}");

app.Run();
