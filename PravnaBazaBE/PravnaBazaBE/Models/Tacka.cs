using System;
using System.Collections.Generic;

namespace PravnaBazaBE.Models
{
    public partial class Tacka
    {
        public Tacka()
        {
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? IdStav { get; set; }
        public string Tekst { get; set; }

        public Stav IdStavNavigation { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
    }
}
