using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class KriticarVal : ValidationBase
    {
        Kriticar kriticar;
        KriticarDao dao;
        bool DaLiJeIzmena;

        public Kriticar Kriticar
        {
            get { return kriticar; }
            set
            {
                kriticar = value;
                OnPropertyChanged("Kriticar");
            }
        }

        public KriticarVal(bool daLiJeIzmena)
        {
            Kriticar = new Kriticar();
            dao = new KriticarDao();
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
