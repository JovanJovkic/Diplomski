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
    
    public partial class Nagrada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nagrada()
        {
            this.Izdajes = new HashSet<Izdaje>();
        }
    
        public int NagradaId { get; set; }
        public string Naziv { get; set; }
        public int NovcanaNagrada { get; set; }
        public bool Drzavna { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Izdaje> Izdajes { get; set; }
    }
}
