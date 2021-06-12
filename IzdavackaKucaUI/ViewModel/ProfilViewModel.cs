using Mongo.entiteti;
using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mongo.dao;

namespace IzdavackaKucaUI.ViewModel
{
    class ProfilViewModel : BindableBase
    {
        ProfilWindow window;

        private string username;
        private string password;
        private string greska;

        public ProfilViewModel(ProfilWindow windowReg,string username)
        {
            PromenaLozinkeCommand = new MyICommand(PromenaLozinke, CanPromenaLozinke);
            window = windowReg;
            Username = username;
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

        private SecureString _password2;
        public SecureString PasswordSecureString2
        {
            get { return _password2; }
            set
            {
                if (value != null)
                {
                    _password2 = value;
                    OnPropertyChanged("PasswordSecureString2");
                }
            }
        }

        private SecureString _password3;
        public SecureString PasswordSecureString3
        {
            get { return _password3; }
            set
            {
                if (value != null)
                {
                    _password3 = value;
                    OnPropertyChanged("PasswordSecureString3");
                }
            }
        }

        public string Greska { get => greska; set { greska = value; OnPropertyChanged("Greska"); } }
        public string Username { get => username; set { username = value; OnPropertyChanged("Username"); } }
        public string Password { get => password; set { password = value; OnPropertyChanged("Password"); } }
        public ICommand PromenaLozinkeCommand { get; set; }

        public bool CanPromenaLozinke()
        {
            return !string.IsNullOrEmpty(Username) &&
                PasswordSecureString != null && PasswordSecureString2 != null;
        }

        public void PromenaLozinke()
        {
            KorisnikDao dao = new KorisnikDao();

            Korisnik korisnik = new Korisnik();
            korisnik.Username = Username;
            korisnik.Password = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;
            string pass1 = new System.Net.NetworkCredential(string.Empty, PasswordSecureString2).Password;
            string pass2 = new System.Net.NetworkCredential(string.Empty, PasswordSecureString3).Password;

            if (pass1 != pass2)
            {
                Greska = "Morate uneti istu lozinku!";
                return;
            }
            
            if (!dao.PromeniLozinku(korisnik.Username,korisnik.Password,pass1))
            {
                Greska = "Niste uneli tacnu staru lozinku!";
            }
            else
            {
                window.Close();
            }
        }

    }
}
