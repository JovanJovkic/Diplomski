using Mongo.entiteti;
using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mongo.dao;

namespace IzdavackaKucaUI.ViewModel
{
    public class ProdajeViewModel:BindableBase
    {
        private ProdajeWindow window;
        private string selektovanaKnjiga;
        private List<string> sveKnjige;
        private string selektovanaKnjizara;
        private List<string> sveKnjizare;

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        private KnjigaDao daoKnj = new KnjigaDao();
        private KnjizaraDao daoKnjizara = new KnjizaraDao();

        public List<string> SveKnjige { get => sveKnjige; set { sveKnjige = value; OnPropertyChanged("SveKnjige"); } }
        public string SelektovanaKnjiga { get => selektovanaKnjiga; set { selektovanaKnjiga = value; OnPropertyChanged("SelektovanaKnjiga"); } }
        public List<string> SveKnjizare { get => sveKnjizare; set { sveKnjizare = value; OnPropertyChanged("SveKnjizare"); } }
        public string SelektovanaKnjizara { get => selektovanaKnjizara; set { selektovanaKnjizara = value; OnPropertyChanged("SelektovanaKnjizara"); } }

    

        public ProdajeViewModel(ProdajeWindow window)
        {
            this.window = window;
            AddCommand = new MyICommand(this.Add, CanAdd);
            ExitCommand = new MyICommand(this.Exit);
            UcitajKnjige();
            UcitajKnjizare();
        }

        public void Exit()
        {
            window.Close();
        }

        public void UcitajKnjige()
        {
            SveKnjige = new List<string>();

            foreach (Knjiga item in daoKnj.GetList())
            {
                SveKnjige.Add("ID:" + item.KnjigaId.ToString() + " - Naziv:" + item.Naziv);
            }
        }

        public void UcitajKnjizare()
        {
            SveKnjizare = new List<string>();

            foreach (Knjizara item in daoKnjizara.GetList())
            {
                SveKnjizare.Add("ID:" + item.KnjizaraId.ToString() + " - Naziv:" + item.Naziv);
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            int knjigaId = OdrediKnjigu();
            int knjizareId = OdrediKnjizare();
            /////
        }

        public int OdrediKnjigu()
        {
            string[] niz = SelektovanaKnjiga.Split('-');
            string[] nizTemp = niz[0].Split(':');

            int broj = Int32.Parse(nizTemp[1]);
            return broj;
        }

        public int OdrediKnjizare()
        {
            string[] niz = SelektovanaKnjizara.Split('-');
            string[] nizTemp = niz[0].Split(':');

            int broj = Int32.Parse(nizTemp[1]);
            return broj;
        }

    }
}
