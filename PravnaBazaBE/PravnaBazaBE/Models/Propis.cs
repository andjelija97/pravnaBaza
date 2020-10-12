﻿using System;
using System.Collections.Generic;

namespace PravnaBazaBE.Models
{
    public partial class Propis
    {
        public Propis()
        {
            Clan = new HashSet<Clan>();
            Podnaslov = new HashSet<Podnaslov>();
            SluzbenoMisljenje = new HashSet<SluzbenoMisljenje>();
            SudskaPraksa = new HashSet<SudskaPraksa>();
        }

        public int Id { get; set; }
        public string Naslov { get; set; }
        public int? IdRubrike { get; set; }
        public int? IdPodrubrike { get; set; }
        public string GlasiloIdatumObjavljivanja { get; set; }
        public string VrstaPropisa { get; set; }
        public string Donosilac { get; set; }
        public string NivoVazenja { get; set; }
        public DateTime? DatumStupanjaNaSnaguVerzijePropisa { get; set; }
        public DateTime? DatumPrestankaVerzije { get; set; }
        public DateTime? DatumObjavljivanjaVerzije { get; set; }
        public DateTime? DatumObjavljivanjaOsnovnogTeksta { get; set; }
        public DateTime? DatumStupanjaNaSnaguMeđunarodnogUgovora { get; set; }
        public DateTime? DatumStupanjaNaSnaguOsnovnogTekstaPropisa { get; set; }
        public DateTime? DatumPrestankaVazenjaPropisa { get; set; }
        public DateTime? DatumPocetkaPrimene { get; set; }
        public string PravniOsnovZaDonosenjaPropisa { get; set; }
        public string NormaOsnovaZaDonosenje { get; set; }
        public string PropisKojiJePrestaoDaVazi { get; set; }
        public string NormaOsnovaZaPrestanakVazenja { get; set; }
        public string DatumPrestankaVazenjaPravnogPrethodnika { get; set; }
        public string IstorijskaVerzijaPropisa { get; set; }
        public string Napomena { get; set; }
        public string ReferencaNaPropis { get; set; }
        public string NapomeneGlasnika { get; set; }
        public string TekstPropisa { get; set; }
        public string Preambula { get; set; }

        public Podrubrika IdPodrubrikeNavigation { get; set; }
        public Rubrika IdRubrikeNavigation { get; set; }
        public ICollection<Clan> Clan { get; set; }
        public ICollection<Podnaslov> Podnaslov { get; set; }
        public ICollection<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public ICollection<SudskaPraksa> SudskaPraksa { get; set; }
    }
}
