using Mongo.entiteti;
using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Mongo.dao;

namespace IzdavackaKucaUI.ViewModel
{
    public class RecenzijaViewModel : BindableBase
    {
        private RecenzijaWindow window;
        private Recenzija selektovanaRecenzija;
        private ObservableCollection<Recenzija> sveRecenzije;

        private RecenzijaDao dao = new RecenzijaDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public Recenzija SelektovanaRecenzija { get => selektovanaRecenzija; set { selektovanaRecenzija = value; OnPropertyChanged("SelektovanaRecenzija"); } }
        public ObservableCollection<Recenzija> SveRecenzije { get => sveRecenzije; set { sveRecenzije = value; OnPropertyChanged("SveRecenzije"); } }

        public RecenzijaViewModel(RecenzijaWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanaRecenzija = new Recenzija();
            SveRecenzije = new ObservableCollection<Recenzija>();

            Ucitaj();


        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanaRecenzija != null)
            {
                return SelektovanaRecenzija.BrojStrana != 0;
            }
            else
            {
                return false;
            }
        }

        public void Edit()
        {
            RecenzijaAddWindow newWindow = new RecenzijaAddWindow();
            newWindow.DataContext = new RecenzijaAddViewModel(newWindow,SelektovanaRecenzija);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanaRecenzija = new Recenzija();
        }

        public void Remove()
        {

            if (dao.DaLiMozeDaSeObrise(SelektovanaRecenzija.RecenzijaId))
            {
                dao.Delete(SelektovanaRecenzija.RecenzijaId);
                Ucitaj();
                SelektovanaRecenzija = new Recenzija();
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
            RecenzijaAddWindow newWindow = new RecenzijaAddWindow();
            newWindow.DataContext = new RecenzijaAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SveRecenzije = new ObservableCollection<Recenzija>();

            foreach (Recenzija item in dao.GetList())
            {
                SveRecenzije.Add(item);
            }
        }
    }
}
