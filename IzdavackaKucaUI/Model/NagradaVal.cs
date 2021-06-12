using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class NagradaVal : ValidationBase
    {
        Nagrada nagrada;
        NagradaDao dao;
        bool DaLiJeIzmena;

        public Nagrada Nagrada
        {
            get { return nagrada; }
            set
            {
                nagrada = value;
                OnPropertyChanged("Nagrada");
            }
        }

        public NagradaVal(bool daLiJeIzmena)
        {
            Nagrada = new Nagrada();
            dao = new NagradaDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.Nagrada.Naziv))
            {
                this.ValidationErrors["Naziv"] = "Unesite naziv!";
            }
            else if ((this.Nagrada.Naziv).Length > 20)
            {
                this.ValidationErrors["Naziv"] = "Maksimalno je 20 karaktera!";
            }

            if (this.Nagrada.NovcanaNagrada == 0)
            {
                this.ValidationErrors["NovcanaNagrada"] = "Unesite iznos novcane nagrade!";
            }

            /*
            if (this.Nagrada.NagradaId == 0)
            {
                this.ValidationErrors["Id"] = "Unesite id nagrade!";
            }*/

            if (!DaLiJeIzmena)
            {
                if (dao.FindById(this.Nagrada.NagradaId) != null)
                {
                    this.ValidationErrors["Id"] = "Postoji nagrada sa istim id-em!";
                }
            }
        }
    }
}