//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IzdavackaKuca
{
    using System;
    using System.Collections.Generic;
    
    public partial class Radnik
    {
        public long Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Plata { get; set; }
        public string Mesto { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string Telefon { get; set; }
        public int OdeljenjeOdeljenjeId { get; set; }
    
        public virtual Odeljenje Odeljenje { get; set; }
        public virtual Pisac Pisac { get; set; }
        public virtual Kriticar Kriticar { get; set; }
    }
}
