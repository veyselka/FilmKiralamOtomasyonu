using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpFilmKiralama
{
    class rentedfilm
    {
        public int FilmId { get; set; }
        public string Name { get; set; }
        public DateTime RentedDate { get; set; }
        public int RentingDays { get; set; }
        public decimal Price { get; set; }

        public rentedfilm(int filmId ,string name ,DateTime rentedDate,int rentingDays,decimal price)
        {
            FilmId = filmId;
            Name = name;
            RentedDate = rentedDate;
            RentingDays = rentingDays;
            Price = price;
        }
    }
}
