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

    class RegistracijaViewModel : BindableBase
    {
        RegistracijaWindow window;

        private string username;
        private string password;
        private string greska;

        public RegistracijaViewModel(RegistracijaWindow windowReg)
        {
            RegistracijaCommand = new MyICommand(Registracija, CanRegistracija);
            window = windowReg;
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

        public string Greska { get => greska; set { greska = value; OnPropertyChanged("Greska"); } }
        public string Username { get => username; set { username = value; OnPropertyChanged("Username"); } }
        public string Password { get => password; set { password = value; OnPropertyChanged("Password"); } }
        public ICommand RegistracijaCommand { get; set; }

        public bool CanRegistracija()
        {
            return !string.IsNullOrEmpty(Username) &&
                PasswordSecureString!=null && PasswordSecureString2!=null;
        }

        public void Registracija()
        {
            KorisnikDao dao = new KorisnikDao();

            Korisnik korisnik = new Korisnik();
            korisnik.Username = Username;
            korisnik.Password = new System.Net.NetworkCredential(string.Empty, PasswordSecureString).Password;
            string pass = new System.Net.NetworkCredential(string.Empty, PasswordSecureString2).Password;

            if(pass!=korisnik.Password)
            {
                Greska = "Morate uneti istu lozinku!";
                return;
            }
            
            if (dao.DaLiPostojiUsername(korisnik.Username))
            {
                Greska = "Postoji korisnik sa istim username-mom!";
            }
            else
            {
                korisnik.Uloga = UlogaKorisnika.ADMIN;
                dao.Insert(korisnik);
                Username = Password = String.Empty;

                window.Close();
            }
        }
    }

}