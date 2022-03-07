using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class FilmContext : DbContext
    {
        public FilmContext()
        {
            Database.SetInitializer<FilmContext>(new InitDB());
        }

        public DbSet<Film> Filmler { get; set; }
        public DbSet<Oyuncu> Oyuncular { get; set; }
        public DbSet<Yapimci> Yapimcilar { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<FilmOyuncu> FilmOyuncu { get; set; }
    }
}