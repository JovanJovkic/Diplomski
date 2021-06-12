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

namespace IzdavackaKucaUI.ViewModel
{
    public class NagradaAddViewModel:BindableBase
    {
        private NagradaAddWindow window;
        private NagradaVal nagrada;

        private bool daLiJeEdit = false;
        private bool daLiJeIzmena;

        public ICommand ExitCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public NagradaVal Nagrada
        {
            get { return nagrada; }
            set
            {
                nagrada = value;
                OnPropertyChanged("Nagrada");
            }
        }

        public bool DaLiJeIzmena { get => daLiJeIzmena; set { daLiJeIzmena = value; OnPropertyChanged("DaLiJeIzmena"); } }

        public NagradaAddViewModel(NagradaAddWindow window)
        {
            this.window = window;
            Nagrada = new NagradaVal(false);

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddNagrada, this.CanAddNagrada);
            DaLiJeIzmena = false;
        }

        public NagradaAddViewModel(NagradaAddWindow window, Nagrada n)
        { daLiJeEdit = true;
            DaLiJeIzmena = true;
            this.window = window;
            Nagrada = new NagradaVal(true);
            Nagrada.Nagrada = n;

            ExitCommand = new MyICommand(this.Exit);
            AddCommand = new MyICommand(this.AddNagrada, this.CanAddNagrada);
           
        }

        public void Exit()
        {
            window.Close();
        }

        public bool CanAddNagrada()
        {
            return true;
        }

        public void AddNagrada()
        {
            Nagrada.Validate();
            if (Nagrada.IsValid)
            {
                NagradaDao k = new NagradaDao();

                if(daLiJeEdit)
                {
                    k.Update(Nagrada.Nagrada.NagradaId, Nagrada.Nagrada);
                }
                else
                {
                    k.Insert(Nagrada.Nagrada);
                }
                
                window.Close();
            }
        }
    }
}
