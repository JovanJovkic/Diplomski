
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
    public class DogadjajViewModel : BindableBase
    {
        private DogadjajWindow window;
        private Dogadjaj selektovanDogadjaj;
        private ObservableCollection<Dogadjaj> sviDogadjaji;

        private DogadjajDao dao = new DogadjajDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ObservableCollection<Dogadjaj> SviDogadjaji { get => sviDogadjaji; set { sviDogadjaji = value; OnPropertyChanged("SviDogadjaji"); } }
        public Dogadjaj SelektovanDogadjaj { get => selektovanDogadjaj; set { selektovanDogadjaj = value; OnPropertyChanged("SelektovanDogadjaj"); } }

        public DogadjajViewModel(DogadjajWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanDogadjaj = new Dogadjaj();
            SviDogadjaji = new ObservableCollection<Dogadjaj>();

            Ucitaj();
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanDogadjaj != null)
            {
                return SelektovanDogadjaj.Mesto != null;
            }
            else
            {
                return false;
            }

        }

        public void Edit()
        {
            DogadjajAddWindow newWindow = new DogadjajAddWindow();
            SelektovanDogadjaj = SviDogadjaji.Where(k => k.DogadjajId == SelektovanDogadjaj.DogadjajId).FirstOrDefault();
            newWindow.DataContext = new DogadjajAddViewModel(newWindow, SelektovanDogadjaj);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanDogadjaj = new Dogadjaj();
        }

        public void Remove()
        {
            if (dao.DaLiMozeDaSeObrise(SelektovanDogadjaj.DogadjajId))
            {
                dao.Delete(SelektovanDogadjaj.DogadjajId);
                Ucitaj();
                SelektovanDogadjaj = new Dogadjaj();
            }
            else
            {
                MessageBox.Show("Ne mozete da obrisite selektovan dogadjaj, postoji pisac koji je vezan za njega!");
            }

        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            DogadjajAddWindow newWindow = new DogadjajAddWindow();
            newWindow.DataContext = new DogadjajAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SviDogadjaji = new ObservableCollection<Dogadjaj>();

            foreach (Dogadjaj item in dao.GetList())
            {
                SviDogadjaji.Add(item);
            }
        }
    }
}
