using System;
using System.Collections.Generic;

namespace PravnaBazaBE.Models
{
    public partial class NivoPodnaslova
    {
        public NivoPodnaslova()
        {
            Podnaslov = new HashSet<Podnaslov>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Podnaslov> Podnaslov { get; set; }
    }
}
