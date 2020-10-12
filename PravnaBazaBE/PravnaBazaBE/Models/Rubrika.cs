﻿using System;
using System.Collections.Generic;

namespace PravnaBazaBE.Models
{
    public partial class Rubrika
    {
        public Rubrika()
        {
            Podrubrika = new HashSet<Podrubrika>();
            Propis = new HashSet<Propis>();
        }

        public int Id { get; set; }
        public string NazivRubrike { get; set; }
        public int? IdOblast { get; set; }

        public GlavneOblasti IdOblastNavigation { get; set; }
        public ICollection<Podrubrika> Podrubrika { get; set; }
        public ICollection<Propis> Propis { get; set; }
    }
}
