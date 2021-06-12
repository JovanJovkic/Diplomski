using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class RecenzijaDao : BaseRepo<Recenzija>
    {
        public void Insert(Recenzija entity, long idKriticara, int idKnjige)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                entity.Kriticar = db.Kriticars.Find(idKriticara);
                entity.Knjiga = db.Knjigas.Find(idKnjige);
                db.Recenzijas.Add(entity);
                db.SaveChanges();
            }
        }

        public bool DaLiMozeDaSeObrise(int id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Recenzija recenzija = db.Recenzijas.Where(c => c.RecenzijaId.Equals(id)).FirstOrDefault();

                //if (recenzija..Count > 0)
                //    return false;
            }

            return true;
        }

        public List<Recenzija> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Recenzija> recenzije = new List<Recenzija>();

                foreach (Recenzija item in db.Recenzijas.Include("Kriticar"))
                {
                    recenzije.Add(item);
                }

                return recenzije;
            }
        }
    }
}