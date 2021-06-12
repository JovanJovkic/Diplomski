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
    public class NagradaViewModel : BindableBase
    {
        private NagradaWindow window;
        private Nagrada selektovanaNagrada;
        private ObservableCollection<Nagrada> sveNagrade;

        private NagradaDao dao = new NagradaDao();

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ObservableCollection<Nagrada> SveNagrade { get => sveNagrade; set { sveNagrade = value; OnPropertyChanged("SveNagrade"); } }
        public Nagrada SelektovanaNagrada { get => selektovanaNagrada; set { selektovanaNagrada = value; OnPropertyChanged("SelektovanaNagrada"); } }

        public NagradaViewModel(NagradaWindow window)
        {
            this.window = window;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);

            SelektovanaNagrada = new Nagrada();
            SveNagrade = new ObservableCollection<Nagrada>();

            Ucitaj();

        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanEditRemove()
        {
            if (SelektovanaNagrada != null)
            {
                return SelektovanaNagrada.Naziv != null;
            }
            else
            {
                return false;
            }
        }

        public void Edit()
        {
            NagradaAddWindow newWindow = new NagradaAddWindow();
            newWindow.DataContext = new NagradaAddViewModel(newWindow,SelektovanaNagrada);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanaNagrada = new Nagrada();
        }

        public void Remove()
        {
            if (dao.DaLiMozeDaSeObrise(SelektovanaNagrada.NagradaId))
            {
                dao.Delete(SelektovanaNagrada.NagradaId);
                Ucitaj();
                SelektovanaNagrada = new Nagrada();
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
            NagradaAddWindow newWindow = new NagradaAddWindow();
            newWindow.DataContext = new NagradaAddViewModel(newWindow);
            newWindow.ShowDialog();
            Ucitaj();
        }

        public void Ucitaj()
        {
            SveNagrade = new ObservableCollection<Nagrada>();

            foreach (Nagrada item in dao.GetList())
            {
                SveNagrade.Add(item);
            }
        }
    }
}
