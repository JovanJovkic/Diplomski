using Mongo.entiteti;
using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mongo.dao;

namespace IzdavackaKucaUI.ViewModel
{
    public class RadnikAddViewModel : BindableBase
    {

        private RadnikAddWindow window;
        private RadnikVal radnik;
        private List<string> spisakOdeljenja;
        private string izabranoOdeljenja;
        private string izabranoOdeljenjeGreska;
        private bool daLiJeIzmena;
        private int odeljenjeStaro = 0;

        private OdeljenjeDao daoOdelj = new OdeljenjeDao();

        private bool daLiJeEdit = false;

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public RadnikVal Radnik
        {
            get { return radnik; }
            set
            {
                radnik = value;
                OnPropertyChanged("Radnik");
            }
        }

        public List<string> SpisakOdeljenja { get => spisakOdeljenja; set { spisakOdeljenja = value; OnPropertyChanged("SpisakOdeljenja"); } }
        public string IzabranoOdeljenja { get => izabranoOdeljenja; set { izabranoOdeljenja = value; OnPropertyChanged("IzabranoOdeljenja"); } }
        public string IzabranoOdeljenjeGreska { get => izabranoOdeljenjeGreska; set { izabranoOdeljenjeGreska = value; OnPropertyChanged("IzabranoOdeljenjeGreska"); } }
        public bool DaLiJeIzmena { get => daLiJeIzmena; set { daLiJeIzmena = value; OnPropertyChanged("DaLiJeIzmena"); } }
        public RadnikAddViewModel(RadnikAddWindow window)
        {
            this.window = window;
            Radnik = new RadnikVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddRadnik, this.CanAddRadnik);
            UcitajOdeljenja();
            IzabranoOdeljenja = "";
            DaLiJeIzmena = false;
        }

        public RadnikAddViewModel(RadnikAddWindow window, Radnik r)
        {
            daLiJeEdit = true;
            DaLiJeIzmena = true;
            this.window = window;
            Radnik = new RadnikVal(true);
            Radnik.Radnik = r;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddRadnik, this.CanAddRadnik);
            UcitajOdeljenja();
           
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddRadnik()
        {
            return true;
        }

        public void AddRadnik()
        {
            Radnik.Validate();

            if(IzabranoOdeljenja == "")
            {
                IzabranoOdeljenjeGreska = "Morate izabrati odeljenje!";
            }
            else
            {
                IzabranoOdeljenjeGreska = "";
            }

            if (Radnik.IsValid && IzabranoOdeljenja!="")
            {
                OdrediOdeljenje();
                RadnikDao k = new RadnikDao();

                if (daLiJeEdit)
                {
                    k.Update(Radnik.Radnik.Jmbg, Radnik.Radnik, odeljenjeStaro);
                }
                else
                {
                    k.Insert(Radnik.Radnik);
                }

                window.Close();
            }
        }

        public void UcitajOdeljenja()
        {
            SpisakOdeljenja = new List<string>();

            foreach (Odeljenje item in daoOdelj.GetList())
            {
                spisakOdeljenja.Add("ID:" + item.OdeljenjeId.ToString() + " - Naziv:" + item.Naziv);

                if(DaLiJeIzmena)
                {
                    if(item.OdeljenjeId == Radnik.Radnik.OdeljenjeOdeljenjeId)
                    IzabranoOdeljenja = "ID:" + item.OdeljenjeId.ToString() + " - Naziv:" + item.Naziv;
                }
            }
        }

        public void OdrediOdeljenje()
        {
            string[] niz = IzabranoOdeljenja.Split('-');
            string[] nizTemp = niz[0].Split(':');

            int broj = Int32.Parse(nizTemp[1]);
            odeljenjeStaro = Radnik.Radnik.OdeljenjeOdeljenjeId;
            Radnik.Radnik.OdeljenjeOdeljenjeId = broj;
            Radnik.Radnik.Odeljenje = broj;
        }
    }
}