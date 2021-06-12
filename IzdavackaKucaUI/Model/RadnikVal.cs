using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class RadnikVal : ValidationBase
    {
        Radnik radnik;
        RadnikDao dao;
        bool DaLiJeIzmena;

        public Radnik Radnik
        {
            get { return radnik; }
            set
            {
                radnik = value;
                OnPropertyChanged("Radnik");
            }
        }

        public RadnikVal(bool daLiJeIzmena)
        {
            Radnik = new Radnik();
            dao = new RadnikDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.Radnik.Ulica))
            {
                this.ValidationErrors["Ulica"] = "Unesite ulicu!";
            }
            else if ((this.Radnik.Ulica).Length > 20)
            {
                this.ValidationErrors["Ulica"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Radnik.Ime))
            {
                this.ValidationErrors["Ime"] = "Unesite ime!";
            }
            else if ((this.Radnik.Ime).Length > 20)
            {
                this.ValidationErrors["Ime"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Radnik.Prezime))
            {
                this.ValidationErrors["Prezime"] = "Unesite prezime!";
            }
            else if ((this.Radnik.Prezime).Length > 20)
            {
                this.ValidationErrors["Prezime"] = "Maksimalno je 20 karaktera!";
            }

            //if (string.IsNullOrWhiteSpace(this.Radnik.Plata))
            //{
            //    this.ValidationErrors["Plata"] = "Unesite platu!";
            //}
            //else if ((this.Radnik.Plata).Length > 20)
            //{
            //    this.ValidationErrors["Plata"] = "Maksimalno je 20 karaktera!";
            //}

            if (string.IsNullOrWhiteSpace(this.Radnik.Mesto))
            {
                this.ValidationErrors["Mesto"] = "Unesite mesto!";
            }
            else if ((this.Radnik.Mesto).Length > 20)
            {
                this.ValidationErrors["Mesto"] = "Maksimalno je 20 karaktera!";
            }

            //if (string.IsNullOrWhiteSpace(this.Radnik.Broj))
            //{
            //    this.ValidationErrors["Broj"] = "Unesite broj!";
            //}
            //else if ((this.Radnik.Mesto).Length > 20)
            //{
            //    this.ValidationErrors["Broj"] = "Maksimalno je 20 karaktera!";
            //}

            if (string.IsNullOrWhiteSpace(this.Radnik.Telefon))
            {
                this.ValidationErrors["Telefon"] = "Unesite telefon!";
            }
            else if ((this.Radnik.Telefon).Length > 20)
            {
                this.ValidationErrors["Telefon"] = "Maksimalno je 20 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.Radnik.Telefon))
            {
                this.ValidationErrors["Telefon"] = "Unesite telefon!";
            }
            else if ((this.Radnik.Telefon).Length > 20)
            {
                this.ValidationErrors["Telefon"] = "Maksimalno je 20 karaktera!";
            }

            if (!DaLiJeIzmena)
            {
                if (dao.FindById(this.Radnik.Jmbg) != null)
                {
                    this.ValidationErrors["Jmbg"] = "Postoji radnik sa istim jmbg-om!";
                }
            }

            if(this.Radnik.Plata == 0)
            {
                this.ValidationErrors["Plata"] = "Morate uneti broj koji je veci od 0!";
            }

            if (this.Radnik.Broj == 0)
            {
                this.ValidationErrors["Broj"] = "Morate uneti broj koji je veci od 0!";
            }

            string jmbgString = this.Radnik.Jmbg.ToString();

            if (jmbgString.Length<12 || jmbgString.Length>13)
            {
                this.ValidationErrors["Jmbg"] = "Morate uneti 13 cifara!";
            }

            if(jmbgString.Length == 12)
            {
                string mesec = jmbgString.Substring(1, 2);
                string godina = jmbgString.Substring(3, 3);
            }
            else if(jmbgString.Length == 13)
            {
                string dan = jmbgString.Substring(0, 2);
                string mesec = jmbgString.Substring(2, 2);
                string godina = jmbgString.Substring(4, 3);
            }
        }
    }
}
