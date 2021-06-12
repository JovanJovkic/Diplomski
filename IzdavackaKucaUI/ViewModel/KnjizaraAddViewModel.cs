
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
    public class KnjizaraAddViewModel:BindableBase
    {
        private KnjizaraAddWindow window;
        private KnjizaraVal knjizara;

        private bool daLiJeEdit = false;
        private bool daLiJeIzmena;

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public KnjizaraVal Knjizara
        {
            get { return knjizara; }
            set
            {
                knjizara = value;
                OnPropertyChanged("Knjizara");
            }
        }

        public bool DaLiJeIzmena { get => daLiJeIzmena; set { daLiJeIzmena = value; OnPropertyChanged("DaLiJeIzmena"); } }

        public KnjizaraAddViewModel(KnjizaraAddWindow window)
        {
            this.window = window;
            Knjizara = new KnjizaraVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddKnjizara, this.CanAddKnjizara);
            DaLiJeIzmena = false;
        }

        public KnjizaraAddViewModel(KnjizaraAddWindow window, Knjizara k)
        {
            this.window = window;
            Knjizara = new KnjizaraVal(true);
            Knjizara.Knjizara = k;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddKnjizara, this.CanAddKnjizara);
            daLiJeEdit = true;
            DaLiJeIzmena = true;
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddKnjizara()
        {
            return true;
        }

        public void AddKnjizara()
        {
            Knjizara.Validate();
            if (Knjizara.IsValid)
            {
                KnjizaraDao k = new KnjizaraDao();

                if (daLiJeEdit)
                {
                    k.Update(Knjizara.Knjizara.KnjizaraId, Knjizara.Knjizara);
                }
                else
                {
                    k.Insert(Knjizara.Knjizara);
                    KorisnikDao daoKorisnik = new KorisnikDao();
                    daoKorisnik.DodajKnjizaru(Knjizara.Knjizara.Naziv);
                }

                window.Close();
            }
        }
    }
}
