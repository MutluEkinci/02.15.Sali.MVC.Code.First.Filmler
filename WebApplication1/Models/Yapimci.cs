using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Yapimci
    {
        public int YapimciID { get; set; }
        public string YapimciAdi { get; set; }

        public ICollection<Film> Filmler { get; set; }
    }
}