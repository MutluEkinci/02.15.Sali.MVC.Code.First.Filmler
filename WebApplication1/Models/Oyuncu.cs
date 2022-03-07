using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Oyuncu
    {
        public int OyuncuID { get; set; }
        public string OyuncuAdi { get; set; }
        //public DateTime DogumTarihi { get; set; }
        public string Biyografi { get; set; }

        public ICollection<Film> Filmler { get; set; }  
    }
}