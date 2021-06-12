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
    public class RadnikViewModel : BindableBase
    {
        private RadnikWindow window;
        private Radnik selektovanRadnik;
        private ObservableCollection<Radnik> sviRadnici;

        private RadnikDao dao = new RadnikDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public Radnik SelektovanRadnik { get => selektovanRadnik; set { selektovanRadnik = value; OnPropertyChanged("SelektovanRadnik"); } }
        public ObservableCollection<Radnik> SviRadnici { get => sviRadnici; set { sviRadnici = value; OnPropertyChanged("SviRadnici"); } }

        public RadnikViewModel(RadnikWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanRadnik = new Radnik();
            SviRadnici = new ObservableCollection<Radnik>();

            Ucitaj();

        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanRadnik != null)
            {
                return SelektovanRadnik.Jmbg != 0;
                //return true;
            }
            else
            {
                return false;
            }
        }

        public void Edit()
        {
            RadnikAddWindow newWindow = new RadnikAddWindow();
            newWindow.DataContext = new RadnikAddViewModel(newWindow,SelektovanRadnik);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanRadnik = new Radnik();
        }

        public void Remove()
        {
            if (dao.DaLiMozeDaSeObrise(SelektovanRadnik.Jmbg))
            {
                dao.Delete(SelektovanRadnik.Jmbg);
                Ucitaj();
                SelektovanRadnik = new Radnik();
            }
            else
            {
                MessageBox.Show("Ne mozete da obrisite selektovanog radnika, postoje pisci ili kriticari koji su vezani za njega!");
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            RadnikAddWindow newWindow = new RadnikAddWindow();
            newWindow.DataContext = new RadnikAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SviRadnici = new ObservableCollection<Radnik>();

            foreach (Radnik item in dao.GetList())
            {
                SviRadnici.Add(item);
            }
        }
    }
}
