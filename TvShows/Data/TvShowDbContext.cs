using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using TvShows.Models;
using System.Linq;

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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
      
        
        
    }
    
    public static void SeedDBase()
    {
        using (var db = new TvShowDbContext())
        {
            db.Database.EnsureCreated();
            
            TvShow t1 = new TvShow() { Name = "The Office", Year = 2005, Genre = "Comedy", Rating = 8 };
            TvShow t2 = new TvShow() { Name = "Criminal Minds", Year = 2005, Genre = "FBi", Rating = 8 };
            TvShow t3 = new TvShow() { Name = "CSI", Year = 2000, Genre = "Crime", Rating = 8 };
            TvShow t4 = new TvShow() { Name = "Reacher", Year = 2007, Genre = "Action", Rating = 8 };
            
                
            Actor a1 = new Actor() { ActorName = "Steve Carell", DateOfBirth = 1962, FavoriteColor = "Blue" };
            Actor a2 = new Actor() { ActorName = "Thomas Gibson", DateOfBirth = 1962, FavoriteColor = "Blue" };
            Actor a3 = new Actor() { ActorName = "Shemar Moore", DateOfBirth = 1970, FavoriteColor = "Red" };
            Actor a4 = new Actor() { ActorName = "Matthew Gray Gubler", DateOfBirth = 1980, FavoriteColor = "Green" };
            Actor a5 = new Actor() { ActorName = "Inbar Lavi", DateOfBirth = 1986, FavoriteColor = "Red" };
            Actor a6 = new Actor() { ActorName = "Jorja Fox", DateOfBirth = 1968, FavoriteColor = "Green" };
            Actor a7 = new Actor() { ActorName = "Alan Ritchson", DateOfBirth = 1982, FavoriteColor = "Teal" };

                
            t1.Actors.Add(a1);
            t2.Actors.Add(a2);
            t2.Actors.Add(a3);
            t2.Actors.Add(a4);
            t2.Actors.Add(a5);
            t3.Actors.Add(a5);
            t3.Actors.Add(a6);
            t4.Actors.Add(a7);
            
            var t1_exists = db.TvShows.FirstOrDefault(x => x.Name == "The Office");
            if (t1_exists == null)
            {
                db.Add(t1);
            }
            
            var t2_exists = db.TvShows.FirstOrDefault(x => x.Name == "Criminal Minds");
            if (t2_exists == null)
            {
                db.Add(t2);
            }
            
            var t3_exists = db.TvShows.FirstOrDefault(x => x.Name == "CSI");
            if (t3_exists == null)
            {
                db.Add(t3);
            
            }
            
            var t4_exists = db.TvShows.FirstOrDefault(x => x.Name == "Reacher");
            if (t4_exists == null)
            {
                db.Add(t4);
            }
            
            db.SaveChanges();
            
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}