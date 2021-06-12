
using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using Mongo.dao;
using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IzdavackaKucaUI.ViewModel
{
    public class IzdajeViewModel:BindableBase
    {
        private IzdajeWindow window;
        private string selektovanaKnjiga;
        private List<string> sveKnjige;
        private string selektovanoOdeljenje;
        private List<string> svaOdeljenja;
        private string izabranaKnjigaGreska;
        private string izabranoOdeljenjeGreska;



        public ICommand AddCommand { get; set; }

        private KnjigaDao daoKnj = new KnjigaDao();
        private OdeljenjeDao daoOd = new OdeljenjeDao();

        public List<string> SveKnjige { get => sveKnjige; set { sveKnjige = value; OnPropertyChanged("SveKnjige"); } }
        public string SelektovanaKnjiga { get => selektovanaKnjiga; set { selektovanaKnjiga = value; OnPropertyChanged("SelektovanaKnjiga"); } }
        public List<string> SvaOdeljenja { get => svaOdeljenja; set { svaOdeljenja = value; OnPropertyChanged("SvaOdeljenja"); } }
        public string SelektovanoOdeljenje { get => selektovanoOdeljenje; set { selektovanoOdeljenje = value; OnPropertyChanged("SelektovanoOdeljenje"); } }

        public string IzabranaKnjigaGreska { get => izabranaKnjigaGreska; set { izabranaKnjigaGreska = value; OnPropertyChanged("IzabranaKnjigaGreska"); } }
        public string IzabranoOdeljenjeGreska { get => izabranoOdeljenjeGreska; set { izabranoOdeljenjeGreska = value; OnPropertyChanged("IzabranoOdeljenjeGreska"); } }
        public ICommand ExitCommand { get; set; }

        public IzdajeViewModel(IzdajeWindow window)
        {
            this.window = window;
            AddCommand = new MyICommand(this.Add, CanAdd);
            ExitCommand = new MyICommand(this.Exit);
            UcitajKnjige();
            UcitajOdeljenja();
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

        public void UcitajOdeljenja()
        {
            SvaOdeljenja = new List<string>();

            foreach (Odeljenje item in daoOd.GetList())
            {
                SvaOdeljenja.Add("ID:" + item.OdeljenjeId.ToString() + " - Naziv:" + item.Naziv);
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            if (!string.IsNullOrEmpty(SelektovanaKnjiga) && !string.IsNullOrEmpty(SelektovanoOdeljenje))
            {
                
                IzdajeDao dao = new IzdajeDao();
                Izdaje izdaje = new Izdaje();

                int knjigaId = OdrediKnjigu();
                int odeljenjeId = OdrediOdeljenje();

                izdaje.KnjigaKnjigaId = knjigaId;
                izdaje.OdeljenjeOdeljenjeId = odeljenjeId;
                
                if (dao.DaLiMozeDaSeIzda(knjigaId, odeljenjeId))
                {
                    dao.Insert(izdaje, knjigaId, odeljenjeId);
                    MessageBox.Show("Odabrana knjiga je uspesno izdata u okviru izabranog odeljenja!");
                    window.Close();
                }
                else
                {
                    MessageBox.Show("Odabrana knjiga je vec izdata u okviru izabranog odeljenja!");
                }
            }
            else
            {
                if(string.IsNullOrEmpty(SelektovanaKnjiga))
                {
                    IzabranaKnjigaGreska = "Morate odabrati knjigu!";
                }
                else
                {
                    IzabranaKnjigaGreska = "";
                }

                if(string.IsNullOrEmpty(SelektovanoOdeljenje))
                {
                    IzabranoOdeljenjeGreska = "Morate odabrati odeljenje!";
                }
                else
                {
                    IzabranoOdeljenjeGreska = "";
                }

            }
        }

        public int OdrediKnjigu()
        {
            string[] niz = SelektovanaKnjiga.Split('-');
            string[] nizTemp = niz[0].Split(':');

            int broj = Int32.Parse(nizTemp[1]);
            return broj;
        }

        public int OdrediOdeljenje()
        {
            string[] niz = SelektovanoOdeljenje.Split('-');
            string[] nizTemp = niz[0].Split(':');

            int broj = Int32.Parse(nizTemp[1]);
            return broj;
        }

    }
}
