using Microsoft.EntityFrameworkCore;
using TvShows.Models;

namespace TvShows.Data;

public class TvShowDbContext : DbContext
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<TvShow> TvShows { get; set; }
    
    
    public string DbPath { get; }
    
    public TvShowDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "tvshows.db");
        
        Console.WriteLine(DbPath);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    
}