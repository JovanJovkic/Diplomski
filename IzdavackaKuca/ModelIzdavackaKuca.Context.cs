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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ModelIzdavackaKucaContainer : DbContext
    {
        public ModelIzdavackaKucaContainer()
            : base("name=ModelIzdavackaKucaContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Odeljenje> Odeljenjes { get; set; }
        public virtual DbSet<Dogadjaj> Dogadjajs { get; set; }
        public virtual DbSet<Nagrada> Nagradas { get; set; }
        public virtual DbSet<Recenzija> Recenzijas { get; set; }
        public virtual DbSet<Knjiga> Knjigas { get; set; }
        public virtual DbSet<Kategorija> Kategorijas { get; set; }
        public virtual DbSet<Knjizara> Knjizaras { get; set; }
        public virtual DbSet<Radnik> Radniks { get; set; }
        public virtual DbSet<Izdaje> Izdajes { get; set; }
        public virtual DbSet<Pisac> Pisacs { get; set; }
        public virtual DbSet<Kriticar> Kriticars { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
    
        [DbFunction("ModelIzdavackaKucaContainer", "Funkcija1")]
        public virtual IQueryable<Funkcija1_Result> Funkcija1(string nazivKategorije)
        {
            var nazivKategorijeParameter = nazivKategorije != null ?
                new ObjectParameter("nazivKategorije", nazivKategorije) :
                new ObjectParameter("nazivKategorije", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Funkcija1_Result>("[ModelIzdavackaKucaContainer].[Funkcija1](@nazivKategorije)", nazivKategorijeParameter);
        }
    
        [DbFunction("ModelIzdavackaKucaContainer", "Funkcija5")]
        public virtual IQueryable<Funkcija5_Result> Funkcija5(string knjRod)
        {
            var knjRodParameter = knjRod != null ?
                new ObjectParameter("knjRod", knjRod) :
                new ObjectParameter("knjRod", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Funkcija5_Result>("[ModelIzdavackaKucaContainer].[Funkcija5](@knjRod)", knjRodParameter);
        }
    
        [DbFunction("ModelIzdavackaKucaContainer", "Funkcija9")]
        public virtual IQueryable<Funkcija9_Result> Funkcija9(string knjRod)
        {
            var knjRodParameter = knjRod != null ?
                new ObjectParameter("knjRod", knjRod) :
                new ObjectParameter("knjRod", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Funkcija9_Result>("[ModelIzdavackaKucaContainer].[Funkcija9](@knjRod)", knjRodParameter);
        }
    
        public virtual int Procedure1(Nullable<int> id1, string naziv, string knjrod)
        {
            var id1Parameter = id1.HasValue ?
                new ObjectParameter("id1", id1) :
                new ObjectParameter("id1", typeof(int));
    
            var nazivParameter = naziv != null ?
                new ObjectParameter("naziv", naziv) :
                new ObjectParameter("naziv", typeof(string));
    
            var knjrodParameter = knjrod != null ?
                new ObjectParameter("knjrod", knjrod) :
                new ObjectParameter("knjrod", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Procedure1", id1Parameter, nazivParameter, knjrodParameter);
        }
    }
}
