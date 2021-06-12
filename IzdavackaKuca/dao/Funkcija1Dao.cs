using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class Funkcija1Dao
    {
        public List<Funkcija1_Result> PozoviFunkciju(string knjRod)
        {
            List<Funkcija1_Result> lista = new List<Funkcija1_Result>();

            using (var db = new ModelIzdavackaKucaContainer())
            {
                try
                {
                    //Poziv funkcije
                    lista = db.Funkcija1(knjRod).ToList();
                }
                catch
                {
                    lista = new List<Funkcija1_Result>();
                }
            }

            return lista;
        }
    }
}
