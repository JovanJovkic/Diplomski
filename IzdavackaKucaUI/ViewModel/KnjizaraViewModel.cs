
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
    public class KnjizaraViewModel: BindableBase
    {
        private KnjizaraWindow window;

        private Knjizara selektovanaKnjizara;
        private ObservableCollection<Knjizara> sveKnjizare;

        private KnjizaraDao dao = new KnjizaraDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ObservableCollection<Knjizara> SveKnjizare { get => sveKnjizare; set { sveKnjizare = value; OnPropertyChanged("SveKnjizare"); } }
        public Knjizara SelektovanaKnjizara { get => selektovanaKnjizara; set { selektovanaKnjizara = value; OnPropertyChanged("SelektovanaKnjizara"); } }

        public KnjizaraViewModel(KnjizaraWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanaKnjizara = new Knjizara();
            SveKnjizare = new ObservableCollection<Knjizara>();

            Ucitaj();
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanaKnjizara != null)
            {
                return SelektovanaKnjizara.Naziv != null;
            }
            else
            {
                return false;
            }

        }

        public void Edit()
        {
            KnjizaraAddWindow newWindow = new KnjizaraAddWindow();
            newWindow.DataContext = new KnjizaraAddViewModel(newWindow,SelektovanaKnjizara);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanaKnjizara = new Knjizara();
        }

        public void Remove()
        {

            if (dao.DaLiMozeDaSeObrise(SelektovanaKnjizara.KnjizaraId))
            {
                dao.Delete(SelektovanaKnjizara.KnjizaraId);
                Ucitaj();
                SelektovanaKnjizara = new Knjizara();
            }
            else
            {
                MessageBox.Show("Ne mozete da obrisite selektovanu nagradu, postoje ----- koji su vezani za njega!");
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            KnjizaraAddWindow newWindow = new KnjizaraAddWindow();
            newWindow.DataContext = new KnjizaraAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SveKnjizare = new ObservableCollection<Knjizara>();

            foreach (Knjizara item in dao.GetList())
            {
                SveKnjizare.Add(item);
            }
        }
    }
}
