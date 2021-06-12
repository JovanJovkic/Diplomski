using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class RecenzijaVal : ValidationBase
    {
        Recenzija recenzija;
        RecenzijaDao dao;
        bool DaLiJeIzmena;

        public Recenzija Recenzija
        {
            get { return recenzija; }
            set
            {
                recenzija = value;
                OnPropertyChanged("Recenzija");
            }
        }

        public RecenzijaVal(bool daLiJeIzmena)
        {
            Recenzija = new Recenzija();
            dao = new RecenzijaDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {
            if (this.Recenzija.Ocena == 0)
            {
                this.ValidationErrors["Ocena"] = "Unesite ocenu!";
            }
            else if (this.Recenzija.Ocena < 0 || this.Recenzija.Ocena > 10)
            {
                this.ValidationErrors["Ocena"] = "Ocena mora biti od 1 do 10!";
            }

            if (this.Recenzija.BrojStrana == 0)
            {
                this.ValidationErrors["BrojStrana"] = "Unesite broj strana!";
            }
            else if (this.Recenzija.BrojStrana < 0)
            {
                this.ValidationErrors["BrojStrana"] = "Broj strana mora biti veci od 0!";
            }
            /*
            if (this.Recenzija.RecenzijaId == 0)
            {
                this.ValidationErrors["Id"] = "Unesite id!";
            }
            else if (this.Recenzija.RecenzijaId < 0)
            {
                this.ValidationErrors["Id"] = "Id mora biti veci od 0!";
            }
            */
            if (!DaLiJeIzmena)
            {
                if (dao.FindById(this.Recenzija.RecenzijaId) != null)
                {
                    this.ValidationErrors["Id"] = "Postoji recenzija sa istim id-jem!";
                }
            }
        }
    }
}
