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
    public class KriticarAddViewModel : BindableBase
    {
        private KriticarAddWindow window;
        private KriticarVal kriticar;
        private List<string> spisakRadnika;
        private string izabranRadnik;
        private string izabranoGreska;

        private RadnikDao daoRad;
        private KriticarDao daoKri;

        private bool daLiJeEdit = false;

        public KriticarVal Kriticar
        {
            get { return kriticar; }
            set
            {
                kriticar = value;
                OnPropertyChanged("Kriticar");
            }
        }

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public List<string> SpisakRadnika { get => spisakRadnika; set { spisakRadnika = value; OnPropertyChanged("SpisakRadnika"); } }
        public string IzabranRadnik { get => izabranRadnik; set { izabranRadnik = value; OnPropertyChanged("IzabranRadnik"); } }
        public string IzabranoGreska { get => izabranoGreska; set { izabranoGreska = value; OnPropertyChanged("IzabranoGreska"); } }

        public KriticarAddViewModel(KriticarAddWindow window)
        {
            this.window = window;
            Kriticar = new KriticarVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddKriticar, this.CanAddKriticar);

            daoRad = new RadnikDao();
            daoKri = new KriticarDao();

            UcitajRadnike();
            daLiJeEdit = false;
        }

        public KriticarAddViewModel(KriticarAddWindow window, Kriticar k)
        {
            this.window = window;
            Kriticar = new KriticarVal(true);
            Kriticar.Kriticar = k;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddKriticar, this.CanAddKriticar);

            daoRad = new RadnikDao();
            daoKri = new KriticarDao();

            UcitajRadnike();
            daLiJeEdit = true;
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddKriticar()
        {
            return true;
        }

        public void AddKriticar()
        {
            Kriticar.Validate();

            if (string.IsNullOrEmpty(IzabranRadnik))
            {
                IzabranoGreska = "Morate izabrati radnika!";
            }
            else
            {
                IzabranoGreska = "";
            }

            if (Kriticar.IsValid && !string.IsNullOrEmpty(IzabranRadnik))
            {
                KriticarDao k = new KriticarDao();
                OdrediRadnika();

                if (daLiJeEdit)
                {
                    k.Update(Kriticar.Kriticar.Jmbg, Kriticar.Kriticar);
                }
                else
                {
                    k.Insert(Kriticar.Kriticar, Kriticar.Kriticar.Jmbg);
                }

                window.Close();
            }
        }

        public void UcitajRadnike()
        {
            SpisakRadnika = new List<string>();

            List<long> pisci = new List<long>();
            foreach (Kriticar item in daoKri.GetList())
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
            Kriticar.Kriticar.Jmbg = broj;
            Kriticar.Kriticar.Radnik = broj;
        }
    }
}