
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
    class KategorijaAddViewModel : BindableBase
    {
        private KategorijaAddWindow window;
        private KategorijaVal kategorija;
        private bool daLiJeIzmena;

        private bool daLiJeEdit = false;

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public KategorijaVal Kategorija
        {
            get { return kategorija; }
            set
            {
                kategorija = value;
                OnPropertyChanged("Kategorija");
            }
        }

        public bool DaLiJeIzmena { get => daLiJeIzmena; set { daLiJeIzmena = value; OnPropertyChanged("DaLiJeIzmena"); } }

        public KategorijaAddViewModel(KategorijaAddWindow window)
        {
            this.window = window;
            Kategorija = new KategorijaVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddKategorija, this.CanAddKategorija);
            DaLiJeIzmena = false;
        }

        public KategorijaAddViewModel(KategorijaAddWindow window, Kategorija k)
        {
            this.window = window;
            Kategorija = new KategorijaVal(true);
            Kategorija.Kategorija = k;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddKategorija, this.CanAddKategorija);
            daLiJeEdit = true;
            DaLiJeIzmena = true;
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddKategorija()
        {
            return true;
        }

        public void AddKategorija()
        {
            Kategorija.Validate();
            if (Kategorija.IsValid)
            {
                KategorijaDao k = new KategorijaDao();

                if (daLiJeEdit)
                {
                    k.Update(Kategorija.Kategorija.KategorijaId, Kategorija.Kategorija);
                }
                else
                {
                    k.Insert(Kategorija.Kategorija);
                }
                window.Close();
            }
        }
    }
}