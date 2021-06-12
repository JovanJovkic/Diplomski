using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class KriticarDao : BaseRepo<Kriticar>
    {
        public void Insert(Kriticar entity, long idRadnika)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                entity.Radnik = db.Radniks.Find(idRadnika);
                db.Kriticars.Add(entity);
                db.SaveChanges();
            }
        }

        public bool DaLiMozeDaSeObrise(Int64 id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Kriticar kriticar = db.Kriticars.Where(c => c.Jmbg.Equals(id)).FirstOrDefault();

                if (kriticar.Recenzijas.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Kriticar> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Kriticar> kriticari = new List<Kriticar>();

                foreach (Kriticar item in db.Kriticars.Include("Recenzijas").Include("Radnik"))
                { 
                    kriticari.Add(item);
                }

                return kriticari;
            }
        }
    }
}