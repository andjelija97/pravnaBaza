using System;
using System.Collections.Generic;

namespace PravnaBazaBE.Models
{
    public partial class Stav
    {
        public Stav()
        {
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
            Tacka = new HashSet<Tacka>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public int? IdClan { get; set; }

        public Clan IdClanNavigation { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
        public ICollection<Tacka> Tacka { get; set; }
    }
}
