using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public string FilmAdi { get; set; }
        public int TurID { get; set; }
        public int YapimciID { get; set; }
        public short Süre { get; set; }


        //public ICollection<Oyuncu> Oyuncular { get; set; }
        //public virtual Tur Tur { get; set; } //Virtual eklememin sebebi index sayfasında tur id yerine film tablosunda idler yerine o idlere karşılık gelen isimleri verir.
        //public virtual Yapimci Yapimci { get; set; }
        //
        public ICollection<FilmOyuncu> Oyuncular { get; set; }

        //icluding yapcağımız için virtualları sildik bu da 2. yöntem
        public Tur Tur { get; set; } 
        public Yapimci Yapimci { get; set; }

    }
}