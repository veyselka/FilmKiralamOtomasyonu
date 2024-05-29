using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpFilmKiralama
{
    class Kişi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string surname { get; set; }
        public List<string> Films { get; set; }
    public Kişi(int id,string name,string surname)
        {
            Id = id;
            Name = name;
            surname = surname;
            Films = new List<string>();
        }
    }
    
}
