using Mongo.entiteti;
using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Mongo.dao;

namespace IzdavackaKucaUI.ViewModel
{
    class MainViewModel : BindableBase
    {
        private string username;
        private string password;

        public MainViewModel()
        {
            LoginCommand = new MyICommand(Login, CanLogin);
            RegisterCommand = new MyICommand(Register, CanRegister);
            
        }

        private SecureString _password;
        public SecureString PasswordSecureString
        {
            get { return _password; }
            set
            {
                if (value != null)
                {
                    _password = value;
                    OnPropertyChanged("PasswordSecureString");
                }
            }
        }

        public string Username { get => username; set { username = value; OnPropertyChanged("Username"); } }
        public string Password { get => password; set { password = value; OnPropertyChanged("Password"); } }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) &&
                (PasswordSecureString!=null);
        }

        public bool CanRegister()
        {
            return true;
        }

        public void Login()
        {
            KorisnikDao dao = new KorisnikDao();

            String sifra = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;

            bool uspesno = dao.Login(Username, sifra);

            if (uspesno)
            {
                UlogaKorisnika uloga = dao.ulogaPoImenu(Username);

                if (uloga == UlogaKorisnika.ADMIN)
                {
                    PocetnaWindow newWindow = new PocetnaWindow();
                    newWindow.DataContext = new PocetnaViewModel(newWindow, Username);
                    newWindow.ShowDialog();
                }
                else if (uloga == UlogaKorisnika.KNJIZARA)
                {
                    KnjizaraPocetnaWindow newWindow = new KnjizaraPocetnaWindow();
                    newWindow.DataContext = new KnjizaraPocetnaViewModel(newWindow, Username);
                    newWindow.ShowDialog();
                }

                return;
            }

            MessageBox.Show("Niste uneli dobar username ili lozinku!");

            // Username = Password = String.Empty;

            //PasswordSecureString.Clear();
        }

        public void Register()
        {
            RegistracijaWindow newWindow = new RegistracijaWindow();
            newWindow.DataContext = new RegistracijaViewModel(newWindow);
            newWindow.ShowDialog();

            //Username = Password = String.Empty;

            //PasswordSecureString.Clear();
        }
    }
}
