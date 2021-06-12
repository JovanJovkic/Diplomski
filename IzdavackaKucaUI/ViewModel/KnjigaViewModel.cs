
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
    public class KnjigaViewModel : BindableBase
    {
        private KnjigaWindow window;
        private Knjiga selektovanaKnjiga;
        private ObservableCollection<Knjiga> sveKnjige;

        private KnjigaDao dao = new KnjigaDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public Knjiga SelektovanaKnjiga { get => selektovanaKnjiga; set { selektovanaKnjiga = value; OnPropertyChanged("SelektovanaKnjiga"); } }
        public ObservableCollection<Knjiga> SveKnjige { get => sveKnjige; set { sveKnjige = value; OnPropertyChanged("SveKnjige"); } }

        public KnjigaViewModel(KnjigaWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanaKnjiga = new Knjiga();
            SveKnjige = new ObservableCollection<Knjiga>();

            Ucitaj();

        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanaKnjiga != null)
            {
                return SelektovanaKnjiga.Naziv != null;
            }
            else
            {
                return false;
            }
        }

        public void Edit()
        {
            KnjigaAddWindow newWindow = new KnjigaAddWindow();
            SelektovanaKnjiga = SveKnjige.Where(k => k.KnjigaId == SelektovanaKnjiga.KnjigaId).FirstOrDefault();
            newWindow.DataContext = new KnjigaAddViewModel(newWindow,SelektovanaKnjiga);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanaKnjiga = new Knjiga();
        }

        public void Remove()
        {
           
            if (dao.DaLiMozeDaSeObrise(SelektovanaKnjiga.KnjigaId))
            {
                dao.Delete(SelektovanaKnjiga.KnjigaId);
                Ucitaj();
                SelektovanaKnjiga = new Knjiga();
            }
            else
            {
                MessageBox.Show("Ne mozete da obrisite selektovanu nagradu, postoje pisci ili recenzije koji su vezani za njega!");
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            KnjigaAddWindow newWindow = new KnjigaAddWindow();
            newWindow.DataContext = new KnjigaAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SveKnjige = new ObservableCollection<Knjiga>();

            foreach (Knjiga item in dao.GetList())
            {
                SveKnjige.Add(item);
            }
        }
    }
}
