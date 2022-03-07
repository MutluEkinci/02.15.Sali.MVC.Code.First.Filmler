using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tur
    {
        public int TurID { get; set; }
        public string TurAdi { get; set; }

        public ICollection<Film> Filmler { get; set; }
    }
}