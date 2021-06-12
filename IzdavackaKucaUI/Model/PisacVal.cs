using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class PisacVal : ValidationBase
    {
        Pisac pisac;
        PisacDao dao;
        bool DaLiJeIzmena;

        public Pisac Pisac
        {
            get { return pisac; }
            set
            {
                pisac = value;
                OnPropertyChanged("Pisac");
            }
        }

        public PisacVal(bool daLiJeIzmena)
        {
            Pisac = new Pisac();
            dao = new PisacDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {
            //if (string.IsNullOrWhiteSpace(this.Pisac.Jmbg))
            //{
            //    this.ValidationErrors["Ulica"] = "Unesite ulicu!";
            //}
            //else if ((this.Pisac.Ulica).Length > 20)
            //{
            //    this.ValidationErrors["Ulica"] = "Maksimalno je 20 karaktera!";
            //}
        }
    }
}
