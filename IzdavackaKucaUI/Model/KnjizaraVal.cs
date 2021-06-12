using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class KnjizaraVal : ValidationBase
    {
        Knjizara knjizara;
        KnjizaraDao dao;
        bool DaLiJeIzmena;

        public Knjizara Knjizara
        {
            get { return knjizara; }
            set
            {
                knjizara = value;
                OnPropertyChanged("Knjizara");
            }
        }

        public KnjizaraVal(bool daLiJeIzmena)
        {
            Knjizara = new Knjizara();
            dao = new KnjizaraDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.Knjizara.Mesto))
            {
                this.ValidationErrors["Mesto"] = "Unesite mesto!";
            }
            else if ((this.Knjizara.Mesto).Length > 20)
            {
                this.ValidationErrors["Mesto"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Knjizara.Ulica))
            {
                this.ValidationErrors["Ulica"] = "Unesite ulicu!";
            }
            else if ((this.Knjizara.Ulica).Length > 20)
            {
                this.ValidationErrors["Ulica"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Knjizara.Naziv))
            {
                this.ValidationErrors["Naziv"] = "Unesite naziv!";
            }
            else if ((this.Knjizara.Naziv).Length > 20)
            {
                this.ValidationErrors["Naziv"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Knjizara.Pib))
            {
                this.ValidationErrors["Pib"] = "Unesite pib!";
            }
            else if ((this.Knjizara.Pib).Length > 20)
            {
                this.ValidationErrors["Pib"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Knjizara.Telefon))
            {
                this.ValidationErrors["Telefon"] = "Unesite telefon!";
            }
            else if ((this.Knjizara.Telefon).Length > 20)
            {
                this.ValidationErrors["Telefon"] = "Maksimalno je 20 karaktera!";
            }

            if (this.Knjizara.Broj == 0)
            {
                this.ValidationErrors["Broj"] = "Unesite broj!";
            }

            /*
            if(this.Knjizara.KnjizaraId == 0)
            {
                this.ValidationErrors["Id"] = "Unesite id!";
            }*/

            if (!DaLiJeIzmena)
            {
                if (dao.FindById(this.Knjizara.KnjizaraId) != null)
                {
                    this.ValidationErrors["Id"] = "Postoji knjizara sa istim id-em!";
                }
            }
        }
    }
}
