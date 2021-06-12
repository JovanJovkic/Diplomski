using Mongo.entiteti;
using IzdavackaKucaUI.Model;
using IzdavackaKucaUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mongo.dao;

namespace IzdavackaKucaUI
{
    public class OdeljenjeAddViewModel:BindableBase
    {
        private OdeljenjeAddWindow window;
        private OdeljenjeVal odeljenje;
        private bool daLiJeIzmena;

        private bool daLiJeEdit = false;

        public OdeljenjeVal Odeljenje
        {
            get { return odeljenje; }
            set
            {
                odeljenje = value;
                OnPropertyChanged("Odeljenje");
            }
        }
        public bool DaLiJeIzmena { get => daLiJeIzmena; set { daLiJeIzmena = value; OnPropertyChanged("DaLiJeIzmena"); } }
        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public OdeljenjeAddViewModel(OdeljenjeAddWindow window)
        {
            this.window = window;
            Odeljenje = new OdeljenjeVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddOdeljenje, this.CanAddOdeljenje);
            DaLiJeIzmena = false;
        }

        public OdeljenjeAddViewModel(OdeljenjeAddWindow window, Odeljenje o)
        {
            this.window = window;
            Odeljenje = new OdeljenjeVal(true);
            Odeljenje.Odeljenje = o;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddOdeljenje, this.CanAddOdeljenje);
            daLiJeEdit = true;
            DaLiJeIzmena = true;
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddOdeljenje()
        {
            return true;
        }

        public void AddOdeljenje()
        {
            Odeljenje.Validate();
            if (Odeljenje.IsValid)
            {
                OdeljenjeDao k = new OdeljenjeDao();
                Odeljenje.Odeljenje.DatumOsnivanja = DateTime.Now;

                if(daLiJeEdit)
                {
                    k.Update(Odeljenje.Odeljenje.OdeljenjeId, Odeljenje.Odeljenje);
                }
                else
                {
                    k.Insert(Odeljenje.Odeljenje);
                }
                
                window.Close();
            }
        }
    }
}
