using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModel
{
    public class FilmOyuncuVM
    {
        public string FilmAdi { get; set; }
        public SelectList Oyuncular { get; set; }
        public List<FilmOyuncu> FilmOyuncuları { get; set; }
        public int OyuncuId { get; set; }
        public int FilmID { get; set; } 
    }
}