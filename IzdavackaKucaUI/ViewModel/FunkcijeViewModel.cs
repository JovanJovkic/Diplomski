
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
    public class FunkcijeViewModel:BindableBase
    {
        private FunkcijeWindow window;
        private string izabranKnjizevniRod;
        private List<FunkcijaRez> listaRezultata;

        public ICommand ExitCommand { get; set; }
        public ICommand PronadjiCommand { get; set; }
        public string IzabranKnjizevniRod { get => izabranKnjizevniRod; set { izabranKnjizevniRod = value; OnPropertyChanged("IzabranKnjizevniRod"); } }

        public List<FunkcijaRez> ListaRezultata { get => listaRezultata; set { listaRezultata = value; OnPropertyChanged("ListaRezultata"); } }
        public FunkcijeViewModel(FunkcijeWindow window)
        {
            this.window = window;
            ExitCommand = new MyICommand(this.Exit);
            PronadjiCommand = new MyICommand(this.Pronadji, CanPronadji);
            listaRezultata = new List<FunkcijaRez>();
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanPronadji()
        {
            return !string.IsNullOrEmpty(IzabranKnjizevniRod);
        }

        public void Pronadji()
        {
            Funkcija5Dao dao = new Funkcija5Dao();
            string s = IzabranKnjizevniRod.Split(':')[1];
            s = s.Trim();
            List<FunkcijaRez> rezultat = dao.PozoviFunkciju(s);
            ListaRezultata = rezultat;
        }
    }
}
