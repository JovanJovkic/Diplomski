using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IzdavackaKucaUI.ViewModel
{
    class PocetnaViewModel : BindableBase
    {
        public ICommand KnjizaraCommand { get; set; }
        public ICommand OdeljenjeCommand { get; set; }
        public ICommand NagradaCommand { get; set; }
        public ICommand DogadjajCommand { get; set; }
        public ICommand RecenzijaCommand { get; set; }
        public ICommand KategorijaCommand { get; set; }
        public ICommand RadnikCommand { get; set; }
        public ICommand KnjigaCommand { get; set; }
        public ICommand PisacCommand { get; set; }
        public ICommand KriticarCommand { get; set; }
        public ICommand FunkcijaCommand { get; set; }
        public ICommand IzdajCommand { get; set; }
        public ICommand ProdajCommand { get; set; }
        public ICommand ProfilCommand { get; set; }

        public string username;
        

        public PocetnaViewModel(PocetnaWindow window,string username)
        {
            KnjizaraCommand = new MyICommand(OpenKnjizara, CanKnjizara);
            OdeljenjeCommand = new MyICommand(OpenOdeljenje, CanOdeljenje);
            NagradaCommand = new MyICommand(OpenNagrada, CanNagrada);
            DogadjajCommand = new MyICommand(OpenDogadjaj, CanDogadjaj);
            RecenzijaCommand = new MyICommand(OpenRecenzija, CanRecenzija);
            KategorijaCommand = new MyICommand(OpenKategorija, CanKategorija);
            RadnikCommand = new MyICommand(OpenRadnik, CanRadnik);
            KnjigaCommand = new MyICommand(OpenKnjiga, CanKnjiga);
            PisacCommand = new MyICommand(OpenPisac, CanPisac);
            KriticarCommand = new MyICommand(OpenKriticar, CanKriticar);
            FunkcijaCommand = new MyICommand(OpenFunkcija, CanFunkcija);
            IzdajCommand = new MyICommand(OpenIzdaj, CanIzdaj);
            ProdajCommand = new MyICommand(OpenProdaj, CanProdaj);
            ProfilCommand = new MyICommand(OpenProfil, CanProfil);
            this.username = username;
        }

        public bool CanKnjizara()
        {
            return true;
        }

        public void OpenKnjizara()
        {
            KnjizaraWindow newWindow = new KnjizaraWindow();
            newWindow.DataContext = new KnjizaraViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanOdeljenje()
        {
            return true;
        }

        public void OpenOdeljenje()
        {
            OdeljenjeWindow newWindow = new OdeljenjeWindow();
            newWindow.DataContext = new OdeljenjeViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanNagrada()
        {
            return true;
        }

        public void OpenNagrada()
        {
            NagradaWindow newWindow = new NagradaWindow();
            newWindow.DataContext = new NagradaViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanDogadjaj()
        {
            return true;
        }

        public void OpenDogadjaj()
        {
            DogadjajWindow newWindow = new DogadjajWindow();
            newWindow.DataContext = new DogadjajViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanRecenzija()
        {
            return true;
        }

        public void OpenRecenzija()
        {
            RecenzijaWindow newWindow = new RecenzijaWindow();
            newWindow.DataContext = new RecenzijaViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanKategorija()
        {
            return true;
        }

        public void OpenKategorija()
        {
            KategorijaWindow newWindow = new KategorijaWindow();
            newWindow.DataContext = new KategorijaViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanRadnik()
        {
            return true;
        }

        public void OpenRadnik()
        {
            RadnikWindow newWindow = new RadnikWindow();
            newWindow.DataContext = new RadnikViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanKnjiga()
        {
            return true;
        }

        public void OpenKnjiga()
        {
            KnjigaWindow newWindow = new KnjigaWindow();
            newWindow.DataContext = new KnjigaViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanPisac()
        {
            return true;
        }

        public void OpenPisac()
        {
            PisacWindow newWindow = new PisacWindow();
            newWindow.DataContext = new PisacViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanKriticar()
        {
            return true;
        }

        public void OpenKriticar()
        {
            KriticarWindow newWindow = new KriticarWindow();
            newWindow.DataContext = new KriticarViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanFunkcija()
        {
            return true;
        }

        public void OpenFunkcija()
        {
            FunkcijeWindow newWindow = new FunkcijeWindow();
            newWindow.DataContext = new FunkcijeViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanIzdaj()
        {
            return true;
        }

        public void OpenIzdaj()
        {
            IzdajeWindow newWindow = new IzdajeWindow();
            newWindow.DataContext = new IzdajeViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanProdaj()
        {
            return true;
        }

        public void OpenProdaj()
        {
            ProdajeWindow newWindow = new ProdajeWindow();
            newWindow.DataContext = new ProdajeViewModel(newWindow);
            newWindow.ShowDialog();
        }

        public bool CanProfil()
        {
            return true;
        }

        public void OpenProfil()
        {
            ProfilWindow newWindow = new ProfilWindow();
            newWindow.DataContext = new ProfilViewModel(newWindow,username);
            newWindow.ShowDialog();
        }
    }
}
