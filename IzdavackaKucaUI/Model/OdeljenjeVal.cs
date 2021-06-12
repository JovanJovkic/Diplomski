using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class OdeljenjeVal : ValidationBase
    {
        Odeljenje odeljenje;
        OdeljenjeDao dao;
        bool DaLiJeIzmena;

        public Odeljenje Odeljenje
        {
            get { return odeljenje; }
            set
            {
                odeljenje = value;
                OnPropertyChanged("Odeljenje");
            }
        }

        public OdeljenjeVal(bool daLiJeIzmena)
        {
            Odeljenje = new Odeljenje();
            dao = new OdeljenjeDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.Odeljenje.Naziv))
            {
                this.ValidationErrors["Naziv"] = "Unesite naziv!";
            }
            else if ((this.Odeljenje.Naziv).Length > 20)
            {
                this.ValidationErrors["Naziv"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Odeljenje.Ulica))
            {
                this.ValidationErrors["Ulica"] = "Unesite ulicu!";
            }
            else if ((this.Odeljenje.Ulica).Length > 20)
            {
                this.ValidationErrors["Ulica"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Odeljenje.Mesto))
            {
                this.ValidationErrors["Mesto"] = "Unesite mesto!";
            }
            else if ((this.Odeljenje.Mesto).Length > 20)
            {
                this.ValidationErrors["Mesto"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Odeljenje.ImeOsnivaca))
            {
                this.ValidationErrors["ImeOsnivaca"] = "Unesite ime osnivaca!";
            }
            else if ((this.Odeljenje.ImeOsnivaca).Length > 20)
            {
                this.ValidationErrors["ImeOsnivaca"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Odeljenje.PrezimeOsnivaca))
            {
                this.ValidationErrors["PrezimeOsnivaca"] = "Unesite prezime osnivaca!";
            }
            else if ((this.Odeljenje.PrezimeOsnivaca).Length > 20)
            {
                this.ValidationErrors["PrezimeOsnivaca"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Odeljenje.Telefon))
            {
                this.ValidationErrors["Telefon"] = "Unesite telefon!";
            }
            else if ((this.Odeljenje.Telefon).Length > 20)
            {
                this.ValidationErrors["Telefon"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Odeljenje.Pib))
            {
                this.ValidationErrors["Pib"] = "Unesite pib!";
            }
            else if ((this.Odeljenje.Pib).Length > 20)
            {
                this.ValidationErrors["Pib"] = "Maksimalno je 20 karaktera!";
            }

            if (!DaLiJeIzmena)
            {
                if (dao.FindById(this.Odeljenje.OdeljenjeId) != null)
                {
                    this.ValidationErrors["Id"] = "Postoji odeljenje sa istim id-em!";
                }
            }
            /*
            if(this.Odeljenje.OdeljenjeId==0)
            {
                this.ValidationErrors["Id"] = "Unesite validan id!";
            }*/

            if (this.Odeljenje.Broj == 0)
            {
                this.ValidationErrors["Broj"] = "Unesite validan broj!";
            }
        }
    }
}
