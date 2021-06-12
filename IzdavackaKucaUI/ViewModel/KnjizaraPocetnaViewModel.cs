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
using System.Windows.Input;

namespace IzdavackaKucaUI.ViewModel
{
    public class KnjizaraPocetnaViewModel : BindableBase
    {
        private KnjizaraPocetnaWindow window;
        private Izdaje selektovanaKnjiga;
        private ObservableCollection<Izdaje> sveKnjige;

        private Izdaje selektovanaKnjigaKupljena;
        private ObservableCollection<Izdaje> sveKnjigeKupljene;

        private IzdajeDao dao = new IzdajeDao();

        private string username;

        public ICommand ExitCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ProfilCommand { get; set; }

        public ObservableCollection<Izdaje> SveKnjige { get => sveKnjige; set { sveKnjige = value; OnPropertyChanged("SveKnjige"); } }
        public Izdaje SelektovanaKnjiga { get => selektovanaKnjiga; set { selektovanaKnjiga = value; OnPropertyChanged("SelektovanaKnjiga"); } }

        public ObservableCollection<Izdaje> SveKnjigeKupljene { get => sveKnjigeKupljene; set { sveKnjigeKupljene = value; OnPropertyChanged("SveKnjigeKupljene"); } }
        public Izdaje SelektovanaKnjigaKupljena { get => selektovanaKnjigaKupljena; set { selektovanaKnjigaKupljena = value; OnPropertyChanged("SelektovanaKnjigaKupljena"); } }

        public string Username { get => username; set => username = value; }

        public KnjizaraPocetnaViewModel(KnjizaraPocetnaWindow window,string username)
        {
            this.window = window;
            Username = username;

            ExitCommand = new MyICommand(this.Exit);
            EditCommand = new MyICommand(this.Edit, CanEditRemove);
            RemoveCommand = new MyICommand(this.Remove, CanEditRemove);
            AddCommand = new MyICommand(this.Add, CanAdd);
            ProfilCommand = new MyICommand(OpenProfil, CanProfil);

            SelektovanaKnjiga = new Izdaje();
            SveKnjige = new ObservableCollection<Izdaje>();

            SelektovanaKnjigaKupljena = new Izdaje();
            SveKnjigeKupljene = new ObservableCollection<Izdaje>();

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
                return SelektovanaKnjiga.Id != 0;
            }
            else
            {
                return false;
            }

        }

        public void Edit()
        {
            /*
            DogadjajAddWindow newWindow = new DogadjajAddWindow();
            SelektovanDogadjaj = SviDogadjaji.Where(k => k.DogadjajId == SelektovanDogadjaj.DogadjajId).FirstOrDefault();
            newWindow.DataContext = new DogadjajAddViewModel(newWindow, SelektovanDogadjaj);
            newWindow.ShowDialog();
            Ucitaj();
            SelektovanDogadjaj = new Dogadjaj();*/
        }

        public void Remove()
        {/*
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
            */
        }

        public bool CanAdd()
        {
            if (SelektovanaKnjiga != null)
            {
                return SelektovanaKnjiga.Id != 0;
            }
            else
            {
                return false;
            }
        }

        public void Add()
        {
            KnjizaraDao knjizaraDao = new KnjizaraDao();
            Knjizara knjizara = knjizaraDao.OdrediNaOsnovuImena(username);

            knjizaraDao.Update(knjizara.KnjizaraId, knjizara, SelektovanaKnjiga.Id);

            dao.Update(SelektovanaKnjiga.Id, SelektovanaKnjiga, knjizara.KnjizaraId);

            Ucitaj();
        }

        public void Ucitaj()
        {
            SveKnjige = new ObservableCollection<Izdaje>();
            SveKnjigeKupljene = new ObservableCollection<Izdaje>();

            KnjizaraDao knjizaraDao = new KnjizaraDao();
            Knjizara knjizara = knjizaraDao.OdrediNaOsnovuImena(username);

            List<int> Kupljeni = new List<int>();

            if(knjizara.IzdajesObjekti==null)
            {
                knjizara.IzdajesObjekti = new List<Izdaje>();
            }

            if(knjizara.Izdajes==null)
            {
                knjizara.Izdajes = new List<int>();
            }

            foreach (int item in knjizara.Izdajes)
            {
                Kupljeni.Add(item);
            }

            foreach (Izdaje item in dao.GetList())
            {
                if (!Kupljeni.Contains(item.Id))
                {
                    SveKnjige.Add(item);
                }
                else
                {
                    SveKnjigeKupljene.Add(item);
                }
            }
        }

        public bool CanProfil()
        {
            return true;
        }

        public void OpenProfil()
        {
            ProfilWindow newWindow = new ProfilWindow();
            newWindow.DataContext = new ProfilViewModel(newWindow, username);
            newWindow.ShowDialog();
        }
    }
}