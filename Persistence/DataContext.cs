using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence;

public class DataContext : DbContext
{
    public string DbPath { get; }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public DataContext()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = System.IO.Path.Join(folder, "weatherforecast.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}