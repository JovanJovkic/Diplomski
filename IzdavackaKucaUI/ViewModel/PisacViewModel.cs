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
    public class PisacViewModel : BindableBase
    {
        private PisacWindow window;
        private Pisac selektovanPisac;
        private ObservableCollection<Pisac> sviPisci;

        private PisacDao dao = new PisacDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public Pisac SelektovanPisac { get => selektovanPisac; set { selektovanPisac = value; OnPropertyChanged("SelektovanPisac"); } }
        public ObservableCollection<Pisac> SviPisci { get => sviPisci; set { sviPisci = value; OnPropertyChanged("SviPisci"); } }

        public PisacViewModel(PisacWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanPisac = new Pisac();
            SviPisci = new ObservableCollection<Pisac>();

            Ucitaj();
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanPisac != null)
            {
                return SelektovanPisac.Jmbg != 0;
                //return true;
            }
            else
            {
                return false;
            }
        }

        public void Edit()
        {
            PisacAddWindow newWindow = new PisacAddWindow();
            newWindow.DataContext = new PisacAddViewModel(newWindow,SelektovanPisac);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanPisac = new Pisac();
        }

        public void Remove()
        {
            if (dao.DaLiMozeDaSeObrise(SelektovanPisac.Jmbg))
            {
                dao.Delete(SelektovanPisac.Jmbg);
                Ucitaj();
                SelektovanPisac = new Pisac();
            }
            else
            {
                MessageBox.Show("Ne mozete da obrisite selektovanog pisca, postoje knjige ili dogadjaji koji su vezani za njega!");
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            PisacAddWindow newWindow = new PisacAddWindow();
            newWindow.DataContext = new PisacAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SviPisci = new ObservableCollection<Pisac>();

            foreach (Pisac item in dao.GetList())
            {
                SviPisci.Add(item);
            }
        }
    }
}
