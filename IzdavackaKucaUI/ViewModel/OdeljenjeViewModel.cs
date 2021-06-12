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
    public class OdeljenjeViewModel : BindableBase
    {
        private OdeljenjeWindow window;
        private Odeljenje selektovanoOdeljenje;
        private ObservableCollection<Odeljenje> svaOdeljenja;


        private OdeljenjeDao dao = new OdeljenjeDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ObservableCollection<Odeljenje> SvaOdeljenja { get => svaOdeljenja; set { svaOdeljenja = value; OnPropertyChanged("SvaOdeljenja"); } }
        public Odeljenje SelektovanoOdeljenje { get => selektovanoOdeljenje; set { selektovanoOdeljenje = value; OnPropertyChanged("SelektovanoOdeljenje"); } }
       
        public OdeljenjeViewModel(OdeljenjeWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanoOdeljenje = new Odeljenje();
            SvaOdeljenja = new ObservableCollection<Odeljenje>();

            Ucitaj();
            
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanoOdeljenje != null)
            {
                return SelektovanoOdeljenje.Naziv != null;
            }
            else
            {
                return false;
            }
        }

        public void Edit()
        {
            OdeljenjeAddWindow newWindow = new OdeljenjeAddWindow();
            newWindow.DataContext = new OdeljenjeAddViewModel(newWindow,SelektovanoOdeljenje);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanoOdeljenje = new Odeljenje();
        }

        public void Remove()
        {
            if (dao.DaLiMozeDaSeObrise(SelektovanoOdeljenje.OdeljenjeId))
            {
                dao.Delete(SelektovanoOdeljenje.OdeljenjeId);
                Ucitaj();
                SelektovanoOdeljenje = new Odeljenje();
            }
            else
            {
                MessageBox.Show("Ne mozete da obrisite selektovano odeljenje, postoje radnici koji su vezani za njega!");
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            OdeljenjeAddWindow newWindow = new OdeljenjeAddWindow();
            newWindow.DataContext = new OdeljenjeAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SvaOdeljenja = new ObservableCollection<Odeljenje>();

            foreach (Odeljenje item in dao.GetList())
            {
                SvaOdeljenja.Add(item);
            }
        }
    }
}
