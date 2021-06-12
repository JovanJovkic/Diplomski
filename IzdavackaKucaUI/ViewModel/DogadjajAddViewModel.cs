
using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IzdavackaKucaUI.ViewModel
{
    public class DogadjajAddViewModel : BindableBase
    {
        private DogadjajAddWindow window;
        private DogadjajVal dogadjaj;
        private string pisacIzabranGreska;
        private bool daLiJeIzmena;

        private PisacDao daoPis = new PisacDao();

        private List<ElementCheckBox> sviPisci;

        private bool daLiJeEdit = false;

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public DogadjajVal Dogadjaj
        {
            get { return dogadjaj; }
            set
            {
                dogadjaj = value;
                OnPropertyChanged("Dogadjaj");
            }
        }

        public List<ElementCheckBox> SviPisci { get => sviPisci; set { sviPisci = value; OnPropertyChanged("SviPisci"); } }

        public string PisacIzabranGreska { get => pisacIzabranGreska; set { pisacIzabranGreska = value; OnPropertyChanged("PisacIzabranGreska"); } }
        public bool DaLiJeIzmena { get => daLiJeIzmena; set { daLiJeIzmena = value; OnPropertyChanged("DaLiJeIzmena"); } }
        public DogadjajAddViewModel(DogadjajAddWindow window)
        {
            this.window = window;
            Dogadjaj = new DogadjajVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddDogadjaj, this.CanAddDogadjaj);

            SviPisci = new List<ElementCheckBox>();
            UcitajPisce();
            DaLiJeIzmena = false;
        }

        public DogadjajAddViewModel(DogadjajAddWindow window, Dogadjaj d)
        {
            daLiJeEdit = true;
            DaLiJeIzmena = true;
            this.window = window;
            Dogadjaj = new DogadjajVal(true);
            Dogadjaj.Dogadjaj = d;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddDogadjaj, this.CanAddDogadjaj);

            SviPisci = new List<ElementCheckBox>();
            UcitajPisce();
           
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddDogadjaj()
        {
            return true;
        }

        public void AddDogadjaj()
        {
            Dogadjaj.Validate();
            if (Dogadjaj.IsValid && DaLiJeIzabrano())
            {
                DogadjajDao k = new DogadjajDao();

                List<long> pisci = new List<long>();

                foreach (var item in SviPisci)
                {
                    if (item.IsSelected)
                    {
                        Pisac p = new Pisac();
                        pisci.Add(item.Id);
                    }
                }

                if (daLiJeEdit)
                {
                    k.Update(Dogadjaj.Dogadjaj.DogadjajId, Dogadjaj.Dogadjaj, pisci);
                }
                else
                {
                    k.Insert(Dogadjaj.Dogadjaj,pisci);
                }

                window.Close();
            }
        }
        

        public void UcitajPisce()
        {
            foreach (Pisac item in daoPis.GetList())
            {
                string s = item.Jmbg + " ";// + item.Radnik.Ime + " " + item.Radnik.Prezime;
                ElementCheckBox temp = new ElementCheckBox(item.Jmbg, s, false);
                SviPisci.Add(temp);

                if (DaLiJeIzmena)
                {
                    foreach (long p in Dogadjaj.Dogadjaj.Pisacs)
                    {
                        if (item.Jmbg == p)
                        {
                            temp.IsSelected = true;
                        }
                    } 
                }
            }
        }

        public bool DaLiJeIzabrano()
        {
            bool izabrano = false;

            foreach (var item in SviPisci)
            {
                if (item.IsSelected)
                {
                    izabrano = true;
                    break;
                }
            }

            if (!izabrano)
            {
                PisacIzabranGreska = "Morate odabrati bar jednu kategoriju!";
            }
            else
            {
                PisacIzabranGreska = "";
            }


            return izabrano;
        }
    }
}