using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class Funkcija5Dao
    {
        public List<FunkcijaRez> PozoviFunkciju(string knjRod)
        {
            List<FunkcijaRez> lista = new List<FunkcijaRez>();


            //Poziv funkcije
            KnjigaDao dao = new KnjigaDao();
            List<Knjiga> knjige = new List<Knjiga>();
            knjige = dao.GetList();

            foreach (Knjiga item in knjige)
            {
                bool sadrzi = false;

                foreach (Kategorija kat in item.KategorijasObjekti)
                {
                    if(kat.KnjizevniRod.ToLower() == knjRod.ToLower())
                    {
                        sadrzi = true;
                        break;
                    }
                }

                if(sadrzi)
                {
                    FunkcijaRez rez = new FunkcijaRez();
                    rez.Id = item.KnjigaId;
                    rez.Naziv = item.Naziv;

                    lista.Add(rez);
                }
            }



            return lista;
        }
    }
}
