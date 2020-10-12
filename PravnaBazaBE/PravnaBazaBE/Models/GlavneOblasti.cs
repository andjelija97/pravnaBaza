﻿using System;
using System.Collections.Generic;

namespace PravnaBazaBE.Models
{
    public partial class GlavneOblasti
    {
        public GlavneOblasti()
        {
            Rubrika = new HashSet<Rubrika>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Rubrika> Rubrika { get; set; }
    }
}
