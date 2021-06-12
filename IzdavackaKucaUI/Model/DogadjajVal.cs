using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class DogadjajVal : ValidationBase
    {
        Dogadjaj dogadjaj;
        DogadjajDao dao;
        bool DaLiJeIzmena;

        public Dogadjaj Dogadjaj
        {
            get { return dogadjaj; }
            set
            {
                dogadjaj = value;
                OnPropertyChanged("Dogadjaj");
            }
        }

        public DogadjajVal(bool daLiJeIzmena)
        {
            Dogadjaj = new Dogadjaj();
            dao = new DogadjajDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.Dogadjaj.Ulica))
            {
                this.ValidationErrors["Ulica"] = "Unesite ulicu!";
            }
            else if ((this.Dogadjaj.Ulica).Length > 20)
            {
                this.ValidationErrors["Ulica"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Dogadjaj.Mesto))
            {
                this.ValidationErrors["Mesto"] = "Unesite mesto!";
            }
            else if ((this.Dogadjaj.Ulica).Length > 20)
            {
                this.ValidationErrors["Mesto"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Dogadjaj.Posveceno))
            {
                this.ValidationErrors["Posveceno"] = "Unesite kome je posveceno!";
            }
            else if ((this.Dogadjaj.Ulica).Length > 20)
            {
                this.ValidationErrors["Posveceno"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Dogadjaj.Tip))
            {
                this.ValidationErrors["Tip"] = "Unesite tip!";
            }
            else if ((this.Dogadjaj.Ulica).Length > 20)
            {
                this.ValidationErrors["Tip"] = "Maksimalno je 20 karaktera!";
            }

            if (!DaLiJeIzmena)
            {
                if (dao.FindById(this.Dogadjaj.DogadjajId) != null)
                {
                    this.ValidationErrors["Id"] = "Postoji dogadjaj sa istim id-em!";
                }
            }
            /*
            if (this.Dogadjaj.DogadjajId == 0)
            {
                this.ValidationErrors["Id"] = "Morate uneti id!";
            }*/

            if (this.Dogadjaj.Broj == 0)
            {
                this.ValidationErrors["Broj"] = "Morate uneti broj!";
            }

            if (this.Dogadjaj.BrojMesta == 0)
            {
                this.ValidationErrors["BrojMesta"] = "Morate uneti broj mesta!";
            }

        }
    }
}
