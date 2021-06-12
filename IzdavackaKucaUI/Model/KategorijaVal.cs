using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class KategorijaVal : ValidationBase
    {
        Kategorija kategorija;
        KategorijaDao dao;
        bool DaLiJeIzmena;

        public Kategorija Kategorija
        {
            get { return kategorija; }
            set
            {
                kategorija = value;
                OnPropertyChanged("Kategorija");
            }
        }

        public KategorijaVal(bool daLiJeIzmena)
        {
            Kategorija = new Kategorija();
            dao = new KategorijaDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.Kategorija.KnjizevniRod))
            {
                this.ValidationErrors["KnjizevniRod"] = "Unesite knjizevni rod!";
            }
            else if((this.Kategorija.KnjizevniRod).Length>20)
            {
                this.ValidationErrors["KnjizevniRod"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Kategorija.Naziv))
            {
                this.ValidationErrors["Naziv"] = "Unesite naziv!";
            }
            else if ((this.Kategorija.Naziv).Length > 20)
            {
                this.ValidationErrors["Naziv"] = "Maksimalno je 20 karaktera!";
            }

            if (!DaLiJeIzmena)
            {
                if (dao.FindById(this.Kategorija.KategorijaId) != null)
                {
                    this.ValidationErrors["Id"] = "Postoji kategorija sa istim id-em!";
                }
            }
            /*
            if (this.Kategorija.KategorijaId == 0)
            {
                this.ValidationErrors["Id"] = "Morate uneti id!";
            }*/
        }
    }
}
