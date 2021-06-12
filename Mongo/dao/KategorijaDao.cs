using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class KategorijaDao : MongoCRUD<Kategorija>
    {
        public KategorijaDao() : base("Kategorija")
        {

        }

        public bool DaLiMozeDaSeObrise(int id)
        {

            Kategorija kategorija = base.FindById(id);

            if (kategorija.Knjigas != null)
            {
                if (kategorija.Knjigas.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Kategorija> GetList()
        {
            
                List<Kategorija> kategorije = new List<Kategorija>();

            kategorije = base.GetList();

            foreach (Kategorija item in kategorije)
            {
                KnjigaDao knjigaDao = new KnjigaDao();

                if (item.Knjigas == null)
                {
                    item.Knjigas = new List<int>();
                }

                item.KnjigasObjekti = new List<Knjiga>();

                foreach (int k in item.Knjigas)
                {
                    item.KnjigasObjekti.Add(knjigaDao.FindById(k));
                }
            }

            return kategorije;
            
        }

        public void DodajKategorijiKnjige(int idKategorije, int idKnjige)
        {
            Kategorija kategorija = base.FindById(idKategorije);

            if (kategorija.Knjigas == null)
            {
                kategorija.Knjigas = new List<int>();
            }

            kategorija.Knjigas.Add(idKnjige);
            
            base.Update(kategorija.KategorijaId, kategorija);
        }

        public void ObrisiKategorijiKnjigu(int idKategorije, int idKnjige)
        {
            Kategorija kategorija = base.FindById(idKategorije);

            kategorija.Knjigas.Remove(idKnjige);

            base.Update(kategorija.KategorijaId, kategorija);
        }
    }
}
