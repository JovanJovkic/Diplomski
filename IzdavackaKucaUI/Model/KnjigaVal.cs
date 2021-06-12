using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class KnjigaVal : ValidationBase
    {
        Knjiga knjiga;
        KnjigaDao dao;
        bool DaLiJeIzmena;

        public Knjiga Knjiga
        {
            get { return knjiga; }
            set
            {
                knjiga = value;
                OnPropertyChanged("Knjiga");
            }
        }

        public KnjigaVal(bool daLiJeIzmena)
        {
            Knjiga = new Knjiga();
            dao = new KnjigaDao();
            DaLiJeIzmena = daLiJeIzmena;
        }

        protected override void ValidateSelf()
        {/*
            if (this.Knjiga.KnjigaId == 0)
            {
                this.ValidationErrors["Id"] = "Unesite id!";
            }*/

            if (this.Knjiga.BrojPoglavlja == 0)
            {
                this.ValidationErrors["BrojPoglavlja"] = "Unesite broj poglavlja!";
            }

            if (this.Knjiga.BrojStrana == 0)
            {
                this.ValidationErrors["BrojStrana"] = "Unesite broj strana!";
            }

            if (string.IsNullOrWhiteSpace(this.Knjiga.Naziv))
            {
                this.ValidationErrors["Naziv"] = "Unesite naziv!";
            }

            if (!DaLiJeIzmena)
            {
                if (dao.FindById(this.Knjiga.KnjigaId) != null)
                {
                    this.ValidationErrors["Id"] = "Postoji knjiga sa istim id-em!";
                }
            }
        }
    }
}
