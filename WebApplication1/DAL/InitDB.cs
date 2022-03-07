using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.DAL
{
    public class InitDB : DropCreateDatabaseAlways<FilmContext>  //DropCreateDatabaseIfModelChanges<FilmContext>
    {
        protected override void Seed(FilmContext context)
        {
            context.Turler.Add(new Tur { TurAdi = "Korku" });
            context.Turler.Add(new Tur { TurAdi = "Savaş" });
            context.Turler.Add(new Tur { TurAdi = "Uzay" });

            context.Yapimcilar.Add(new Yapimci { YapimciAdi = "Paramount" });
            context.Yapimcilar.Add(new Yapimci { YapimciAdi = "Warner Bros" });

            context.Oyuncular.Add(new Oyuncu { OyuncuAdi = "Tom Hanks" });
            context.Oyuncular.Add(new Oyuncu { OyuncuAdi = "Vin Diesel" });
            context.Oyuncular.Add(new Oyuncu { OyuncuAdi = "Matt Damon" });

            context.SaveChanges();

            //context.Filmler.Add(new Film { FilmAdi = "Er Ryan'ı Kurtarmak", YapimciID = 1, TurID = 2, Oyuncular = context.Oyuncular.ToList() , Sure=120});
            context.Filmler.Add(new Film { FilmAdi = "Er Ryan'ı Kurtarmak", YapimciID = 1, TurID = 2, Süre = 120 });

            //context.Filmler.Add(new Film { FilmAdi = "Yüzüklerin Efendisi", YapimciID = 2, TurID = 2, Oyuncular = context.Oyuncular.Where(o=>o.OyuncuID %2==1).ToList(), Sure = 120 });

            context.SaveChanges();

            context.FilmOyuncu.Add(new FilmOyuncu { FilmID = 1, OyuncuID = 1 });
            context.FilmOyuncu.Add(new FilmOyuncu { FilmID = 1, OyuncuID = 2 });
            context.FilmOyuncu.Add(new FilmOyuncu { FilmID = 1, OyuncuID = 3 });

            context.SaveChanges();
        }

    }


}