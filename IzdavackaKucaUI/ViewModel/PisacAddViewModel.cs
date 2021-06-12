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
    public class PisacAddViewModel : BindableBase
    {
        private PisacAddWindow window;
        private PisacVal pisac;
        private List<string> spisakRadnika;
        private string izabranRadnik;
        private string izabranoGreska;

        private RadnikDao daoRad;
        private PisacDao daoPis;

        private bool daLiJeEdit = false;

        public PisacVal Pisac
        {
            get { return pisac; }
            set
            {
                pisac = value;
                OnPropertyChanged("Pisac");
            }
        }

        public List<string> SpisakRadnika { get => spisakRadnika; set { spisakRadnika = value; OnPropertyChanged("SpisakRadnika"); } }
        public string IzabranRadnik { get => izabranRadnik; set { izabranRadnik = value; OnPropertyChanged("IzabranRadnik"); } }
        public string IzabranoGreska { get => izabranoGreska; set { izabranoGreska = value; OnPropertyChanged("IzabranoGreska"); } }

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public PisacAddViewModel(PisacAddWindow window)
        {
            this.window = window;
            Pisac = new PisacVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddPisac, this.CanAddPisac);

            daoRad = new RadnikDao();
            daoPis = new PisacDao();
            UcitajRadnike();
            daLiJeEdit = false;
        }

        public PisacAddViewModel(PisacAddWindow window,Pisac p)
        {
            this.window = window;
            Pisac = new PisacVal(true);
            Pisac.Pisac = p;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddPisac, this.CanAddPisac);

            daoRad = new RadnikDao();
            daoPis = new PisacDao();
            UcitajRadnike();
            daLiJeEdit = true;
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddPisac()
        {
            return true;
        }

        public void AddPisac()
        {
            Pisac.Validate();

            if (string.IsNullOrEmpty(IzabranRadnik))
            {
                IzabranoGreska = "Morate izabrati radnika!";
            }
            else
            {
                IzabranoGreska = "";
            }

            if (Pisac.IsValid && !string.IsNullOrEmpty(IzabranRadnik))
            {
                PisacDao k = new PisacDao();
                OdrediRadnika();

                if(daLiJeEdit)
                {
                    k.Update(Pisac.Pisac.Jmbg, Pisac.Pisac);
                }
                else
                {
                    k.Insert(Pisac.Pisac, Pisac.Pisac.Jmbg);
                }
                
                window.Close();
            }
        }

        public void UcitajRadnike()
        {
            SpisakRadnika = new List<string>();

            List<long> pisci = new List<long>();
            foreach (Pisac item in daoPis.GetList())
            {
                pisci.Add(item.Jmbg);
            }

            foreach (Radnik item in daoRad.GetList())
            {
                if (!pisci.Contains(item.Jmbg))
                {
                    SpisakRadnika.Add("JMBG:" + item.Jmbg.ToString() + " - " + item.Ime + " " + item.Prezime);
                }
            }
        }

        public void OdrediRadnika()
        {
            string[] niz = IzabranRadnik.Split('-');
            string[] nizTemp = niz[0].Split(':');

            Int64 broj = Int64.Parse(nizTemp[1]);
            Pisac.Pisac.Jmbg = broj;
            Pisac.Pisac.Radnik = broj;
        }
    }
}
