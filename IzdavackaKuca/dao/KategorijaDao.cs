using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class KategorijaDao : BaseRepo<Kategorija>
    {
        public bool DaLiMozeDaSeObrise(int id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Kategorija kategorija = db.Kategorijas.Where(c => c.KategorijaId.Equals(id)).FirstOrDefault();

                if (kategorija.Knjigas.Count > 0)
                    return false;
            }

            return true;
        }/*
        public List<Kategorija> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Kategorija> kategorije = new List<Kategorija>();

                foreach (Kategorija item in db.Kategorijas.Include("Knjigas"))
                {
                    kategorije.Add(item);
                }

                return kategorije;
            }
        }

        public void Insert(Kategorija kategorija)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                //db.Procedure1(kategorija.KategorijaId, kategorija.Naziv, kategorija.KnjizevniRod);
                db.Set<Kategorija>().Add(kategorija);
                db.SaveChanges();
            }
        }*/
    }
}
