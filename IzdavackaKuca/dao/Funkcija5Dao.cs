using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class Funkcija5Dao
    {
        public List<Funkcija9_Result> PozoviFunkciju(string knjRod)
        {
            List<Funkcija9_Result> lista = new List<Funkcija9_Result>();

            using (var db = new ModelIzdavackaKucaContainer())
            {
                try
                {
                    //Poziv funkcije
                    lista = db.Funkcija9(knjRod).ToList();
                }
                catch
                {
                    lista = new List<Funkcija9_Result>();
                }
            }

            return lista;
        }
    }
}
