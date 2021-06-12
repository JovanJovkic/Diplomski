
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
    public class KategorijaViewModel : BindableBase
    {
        private KategorijaWindow window;
        private Kategorija selektovanaKategorija;
        private ObservableCollection<Kategorija> sveKategorije;

        private KategorijaDao dao = new KategorijaDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ObservableCollection<Kategorija> SveKategorije { get => sveKategorije; set { sveKategorije = value; OnPropertyChanged("SveKategorije"); } }
        public Kategorija SelektovanaKategorija { get => selektovanaKategorija; set { selektovanaKategorija = value; OnPropertyChanged("Kategorija"); } }

        public KategorijaViewModel(KategorijaWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanaKategorija = new Kategorija();
            SveKategorije = new ObservableCollection<Kategorija>();

            Ucitaj();
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanaKategorija != null)
            {
                return SelektovanaKategorija.Naziv != null;
            }
            else
            {
                return false;
            }

        }

        public void Edit()
        {
            KategorijaAddWindow newWindow = new KategorijaAddWindow();
            newWindow.DataContext = new KategorijaAddViewModel(newWindow,SelektovanaKategorija);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanaKategorija = new Kategorija();
        }

        public void Remove()
        {
            if (dao.DaLiMozeDaSeObrise(SelektovanaKategorija.KategorijaId))
            {
                dao.Delete(SelektovanaKategorija.KategorijaId);
                Ucitaj();
                SelektovanaKategorija = new Kategorija();
            }
            else
            {
                MessageBox.Show("Ne mozete da obrisite selektovanu kategoriju, postoje knjige koje su vezani za njega!");
            }

        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            KategorijaAddWindow newWindow = new KategorijaAddWindow();
            newWindow.DataContext = new KategorijaAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SveKategorije = new ObservableCollection<Kategorija>();

            foreach (Kategorija item in dao.GetList())
            {
                SveKategorije.Add(item);
            }
        }
    }
}
