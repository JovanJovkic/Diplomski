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
    
    public partial class Recenzija
    {
        public int RecenzijaId { get; set; }
        public int Ocena { get; set; }
        public int BrojStrana { get; set; }
        public int KnjigaKnjigaId { get; set; }
    
        public virtual Knjiga Knjiga { get; set; }
        public virtual Kriticar Kriticar { get; set; }
    }
}
