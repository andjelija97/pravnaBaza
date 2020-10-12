using System;
using System.Collections.Generic;

namespace PravnaBazaBE.Models
{
    public partial class Clan
    {
        public Clan()
        {
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            Stav = new HashSet<Stav>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdPodnaslov { get; set; }
        public int? IdPropis { get; set; }

        public Podnaslov IdPodnaslovNavigation { get; set; }
        public Propis IdPropisNavigation { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public ICollection<Stav> Stav { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
    }
}
