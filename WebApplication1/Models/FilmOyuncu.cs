using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FilmOyuncu
    {
        public int FilmOyuncuID { get; set; }

        //[ForeignKey("Film")]
        public int FilmID { get; set; }
        //[ForeignKey("Oyuncu")]
        public int OyuncuID { get; set; }

        public Oyuncu Oyuncu { get; set; }
        public Film Film { get; set; }

    }
}