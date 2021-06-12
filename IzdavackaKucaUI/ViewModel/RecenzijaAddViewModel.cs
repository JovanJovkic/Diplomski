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
    public class RecenzijaAddViewModel : BindableBase
    {

        private RecenzijaAddWindow window;
        private RecenzijaVal recenzija;
        private List<string> spisakKnjiga;
        private string izabranaKnjiga;
        private List<string> spisakKriticara;
        private string izabranKriticar;
        private string izabranKriticarGreska;
        private string izabranaKnjigaGreska;
        private bool daLiJeIzmena;

        private long kriticarStari = 0;
        private int knjigaStara = 0;

        private RecenzijaDao daoRec = new RecenzijaDao();
        private KnjigaDao daoKnj = new KnjigaDao();
        private KriticarDao daoKri = new KriticarDao();

        private bool daLiJeEdit = false;

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public RecenzijaVal Recenzija
        {
            get { return recenzija; }
            set
            {
                recenzija = value;
                OnPropertyChanged("Recenzija");
            }
        }

        public List<string> SpisakKnjiga { get => spisakKnjiga; set{ spisakKnjiga = value; OnPropertyChanged("SpisakKnjiga");} }
        public string IzabranaKnjiga { get => izabranaKnjiga; set {izabranaKnjiga = value; OnPropertyChanged("IzabranaKnjiga"); } }
        public List<string> SpisakKriticara { get => spisakKriticara; set { spisakKriticara = value; OnPropertyChanged("SpisakKriticara"); } }
        public string IzabranKriticar { get => izabranKriticar; set { izabranKriticar = value; OnPropertyChanged("IzabranKriticar"); } }
        public string IzabranKriticarGreska { get => izabranKriticarGreska; set { izabranKriticarGreska = value; OnPropertyChanged("IzabranKriticarGreska"); } }
        public string IzabranaKnjigaGreska { get => izabranaKnjigaGreska; set { izabranaKnjigaGreska = value; OnPropertyChanged("IzabranaKnjigaGreska"); } }

        public bool DaLiJeIzmena { get => daLiJeIzmena; set { daLiJeIzmena = value; OnPropertyChanged("DaLiJeIzmena"); } }
        public RecenzijaAddViewModel(RecenzijaAddWindow window)
        {
            this.window = window;
            Recenzija = new RecenzijaVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddRecenzija, this.CanAddRecenzija);
            UcitajKnjige();
            UcitajKriticare();
            DaLiJeIzmena = false;
        }

        public RecenzijaAddViewModel(RecenzijaAddWindow window,Recenzija r)
        { 
            daLiJeEdit = true;
            DaLiJeIzmena = true;
            this.window = window;
            Recenzija = new RecenzijaVal(true);
            Recenzija.Recenzija = r;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddRecenzija, this.CanAddRecenzija);
            UcitajKnjige();
            UcitajKriticare();
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddRecenzija()
        {
            return true;
        }

        public void AddRecenzija()
        {
            Recenzija.Validate();

            if (string.IsNullOrEmpty(IzabranaKnjiga))
            {
                IzabranaKnjigaGreska = "Morate izabrati knjigu!";
            }
            else
            {
                IzabranaKnjigaGreska = "";
            }

            if (string.IsNullOrEmpty(IzabranKriticar))
            {
                IzabranKriticarGreska = "Morate izabrati kriticara!";
            }
            else
            {
                IzabranKriticarGreska = "";
            }

            if (Recenzija.IsValid && !string.IsNullOrEmpty(IzabranaKnjiga) && !string.IsNullOrEmpty(IzabranKriticar))
            {
                OdrediKnjigu();
                OdrediKriticara();
                RecenzijaDao k = new RecenzijaDao();

                if (daLiJeEdit)
                {
                    k.Update(Recenzija.Recenzija.RecenzijaId, Recenzija.Recenzija, kriticarStari, knjigaStara);
                }
                else
                {
                    k.Insert(Recenzija.Recenzija, OdrediKriticara(), OdrediKnjigu());
                }

                window.Close();
            }
        }

        public int OdrediKnjigu()
        {
            string[] niz = IzabranaKnjiga.Split('-');
            string[] nizTemp = niz[0].Split(':');

            int broj = Int32.Parse(nizTemp[1]);
            knjigaStara = Recenzija.Recenzija.Knjiga;
            Recenzija.Recenzija.KnjigaKnjigaId = broj;
            return broj;
        }

        public Int64 OdrediKriticara()
        {
            string[] niz = IzabranKriticar.Split('-');
            string[] nizTemp = niz[0].Split(':');

            Int64 broj = Int64.Parse(nizTemp[1]);
            kriticarStari = Recenzija.Recenzija.Kriticar;
            Recenzija.Recenzija.Kriticar = broj;
            return broj;
        }

        public void UcitajKnjige()
        {
            SpisakKnjiga = new List<string>();

            foreach (Knjiga item in daoKnj.GetList())
            {
                SpisakKnjiga.Add("ID:" + item.KnjigaId.ToString() + " - Naziv:" + item.Naziv);

                if (DaLiJeIzmena)
                {
                    if (item.KnjigaId == Recenzija.Recenzija.KnjigaKnjigaId)
                        IzabranaKnjiga = "ID:" + item.KnjigaId.ToString() + " - Naziv:" + item.Naziv;
                }
            }
        }

        public void UcitajKriticare()
        {
            SpisakKriticara = new List<string>();

            foreach (Kriticar item in daoKri.GetList())
            {
                SpisakKriticara.Add("JMBG:" + item.Jmbg.ToString() + " - " );

                if (DaLiJeIzmena)
                {
                    if (item.Jmbg == Recenzija.Recenzija.KriticarObjekat.Jmbg)
                        IzabranKriticar = "JMBG:" + item.Jmbg.ToString() + " - ";
                }
            }
        }
    }
}
