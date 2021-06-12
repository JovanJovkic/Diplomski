
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
    public class KnjigaAddViewModel:BindableBase
    {
        private KnjigaAddWindow window;
        private KnjigaVal knjiga;
        private List<ElementCheckBox> sveKategorije;
        private List<ElementCheckBox> sviPisci;
        private string kategorijaIzabranaGreska;
        private string pisacIzabranGreska;

        private PisacDao daoPis = new PisacDao();
        private KategorijaDao daoKat = new KategorijaDao();

        private bool daLiJeEdit = false;
        private bool daLiJeIzmena;

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public KnjigaVal Knjiga { get => knjiga; set => knjiga = value; }
        public List<ElementCheckBox> SveKategorije { get => sveKategorije; set { sveKategorije = value; OnPropertyChanged("SveKategorije"); } }
        public List<ElementCheckBox> SviPisci { get => sviPisci; set { sviPisci = value; OnPropertyChanged("SviPisci"); } }
        public string KategorijaIzabranaGreska { get => kategorijaIzabranaGreska; set { kategorijaIzabranaGreska = value; OnPropertyChanged("KategorijaIzabranaGreska"); } }
        public string PisacIzabranGreska { get => pisacIzabranGreska; set { pisacIzabranGreska = value; OnPropertyChanged("PisacIzabranGreska"); } }
        public bool DaLiJeIzmena { get => daLiJeIzmena; set { daLiJeIzmena = value; OnPropertyChanged("DaLiJeIzmena"); } }

        public KnjigaAddViewModel(KnjigaAddWindow window)
        {
            this.window = window;
            Knjiga = new KnjigaVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddKnjiga, this.CanAddKnjiga);
            SveKategorije = new List<ElementCheckBox>();
            SviPisci = new List<ElementCheckBox>();
            UcitajPisceIKategorije();
            DaLiJeIzmena = false;
        }

        public KnjigaAddViewModel(KnjigaAddWindow window, Knjiga k)
        {
            daLiJeEdit = true;
            DaLiJeIzmena = true;
            this.window = window;
            Knjiga = new KnjigaVal(true);
            Knjiga.Knjiga = k;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddKnjiga, this.CanAddKnjiga);
            SveKategorije = new List<ElementCheckBox>();
            SviPisci = new List<ElementCheckBox>();
            UcitajPisceIKategorije();
         
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddKnjiga()
        {
            return true;
        }

        public void AddKnjiga()
        {
            Knjiga.Validate();

            if (Knjiga.IsValid && DaLiJeIzabrano())
            {
                KnjigaDao k = new KnjigaDao();

                if (daLiJeEdit)
                {
                    k.Update(Knjiga.Knjiga.KnjigaId, Knjiga.Knjiga, odrediPisce(), odrediKategorije());
                }
                else
                {
                    k.Insert(Knjiga.Knjiga,odrediPisce(),odrediKategorije());
                }

                window.Close();
            }
        }

        public void UcitajPisceIKategorije()
        {
            foreach (Kategorija item in daoKat.GetList())
            {
                string str = "id: " + item.KategorijaId + " " + item.Naziv;
                ElementCheckBox el = new ElementCheckBox(item.KategorijaId, str, false);
                SveKategorije.Add(el);

                if (DaLiJeIzmena)
                {
                    foreach (int p in Knjiga.Knjiga.Kategorijas)
                    {
                        if (item.KategorijaId == p)
                        {
                            el.IsSelected = true;
                        }
                    }
                }
            }

            foreach (Pisac item in daoPis.GetList())
            {
                string str = item.Jmbg + "";
                ElementCheckBox el = new ElementCheckBox(item.Jmbg, str, false);
                SviPisci.Add(el);

                if (DaLiJeIzmena)
                {
                    foreach (long p in Knjiga.Knjiga.Pisacs)
                    {
                        if (item.Jmbg == p)
                        {
                            el.IsSelected = true;
                        }
                    }
                }
            }
        }

        public List<long> odrediPisce()
        {
            List<long> lista = new List<long>();

            foreach (var item in SviPisci)
            {
                if (item.IsSelected)
                {
                    lista.Add(item.Id);
                }
            }

            return lista;
        }

        public List<int> odrediKategorije()
        {
            List<int> lista = new List<int>();

            foreach (var item in SveKategorije)
            {
                if (item.IsSelected)
                {
                    lista.Add((int)item.Id);
                }
            }

            return lista;
        }

        public bool DaLiJeIzabrano()
        {
            bool izabranoKat = false;
            bool izabranoPis = false;

            foreach (var item in SveKategorije)
            {
                if (item.IsSelected)
                {
                    izabranoKat = true;
                    break;
                }
            }

            foreach (var item in SviPisci)
            {
                if (item.IsSelected)
                {
                    izabranoPis = true;
                    break;
                }
            }

            if (!izabranoKat)
            {
                KategorijaIzabranaGreska = "Morate odabrati bar jednu kategoriju!";
            }
            else
            {
                KategorijaIzabranaGreska = "";
            }

            if (!izabranoPis)
            {
                PisacIzabranGreska = "Morate odabrati bar jednog pisca!";
            }
            else
            {
                PisacIzabranGreska = "";
            }



            return izabranoKat && izabranoPis;
        }
    }
}
