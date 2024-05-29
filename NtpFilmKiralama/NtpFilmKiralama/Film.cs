using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NtpFilmKiralama
{
    class Film
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    public Film(int id, string name, decimal price)
        {
        Id = id;
        Name = name;
        Price = price;
        }
    }
    
}
