using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class KnjigaDao : BaseRepo<Knjiga>
    {
        public void Insert(Knjiga entity, List<long> pisci, List<int> kategorije)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                //entity.Knjiga = db.Radniks.Find(idRadnika);

                foreach (long item in pisci)
                {
                    entity.Pisacs.Add(db.Pisacs.Find(item));
                }

                foreach (long item in kategorije)
                {
                    entity.Kategorijas.Add(db.Kategorijas.Find(item));
                }


                db.Knjigas.Add(entity);
                db.SaveChanges();
            }
        }

        public bool DaLiMozeDaSeObrise(int id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Knjiga knjiga = db.Knjigas.Where(c => c.KnjigaId.Equals(id)).FirstOrDefault();

                if (knjiga.Recenzijas.Count > 0)
                    return false;

                if (knjiga.Pisacs.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Knjiga> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Knjiga> knjige = new List<Knjiga>();

                foreach (Knjiga item in db.Knjigas.Include("Kategorijas").Include("Pisacs").Include("Recenzijas"))
                {
                    knjige.Add(item);
                }

                return knjige;
            }
        }
    }
}
