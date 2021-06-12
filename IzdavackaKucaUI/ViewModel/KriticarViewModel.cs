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
    public class KriticarViewModel : BindableBase
    {
        private KriticarWindow window;
        private Kriticar selektovanKriticar;
        private ObservableCollection<Kriticar> sviKriticari;

        private KriticarDao dao = new KriticarDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public Kriticar SelektovanKriticar { get => selektovanKriticar; set { selektovanKriticar = value; OnPropertyChanged("SelektovanKriticar"); } }
        public ObservableCollection<Kriticar> SviKriticari { get => sviKriticari; set { sviKriticari = value; OnPropertyChanged("SviKriticari"); } }

        public KriticarViewModel(KriticarWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanKriticar = new Kriticar();
            SviKriticari = new ObservableCollection<Kriticar>();

            Ucitaj();

        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanKriticar != null)
            {
                return SelektovanKriticar.Jmbg != 0;
            }
            else
            {
                return false;
            }

        }

        public void Edit()
        {
            KriticarAddWindow newWindow = new KriticarAddWindow();
            newWindow.DataContext = new KriticarAddViewModel(newWindow,SelektovanKriticar);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanKriticar = new Kriticar();
        }

        public void Remove()
        {
            if (dao.DaLiMozeDaSeObrise(SelektovanKriticar.Jmbg))
            {
                dao.Delete(SelektovanKriticar.Jmbg);
                Ucitaj();
                SelektovanKriticar = new Kriticar();
            }
            else
            {
                MessageBox.Show("Ne mozete da obrisite selektovanog pisca, postoje recenzije koje su vezane za njega!");
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public void Add()
        {
            KriticarAddWindow newWindow = new KriticarAddWindow();
            newWindow.DataContext = new KriticarAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SviKriticari = new ObservableCollection<Kriticar>();

            foreach (Kriticar item in dao.GetList())
            {
                SviKriticari.Add(item);
            }
        }
    }
}
