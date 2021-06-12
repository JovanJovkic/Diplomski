using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class NagradaDao : BaseRepo<Nagrada>
    {
        public void InsertN(Nagrada entity)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                db.Set<Nagrada>().Add(entity);
                db.SaveChanges();
            }
        }

        public bool DaLiMozeDaSeObrise(int id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Nagrada nagrada = db.Nagradas.Where(c => c.NagradaId.Equals(id)).FirstOrDefault();

                if (nagrada.Izdajes.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Nagrada> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Nagrada> nagrade = new List<Nagrada>();

                foreach (Nagrada item in db.Nagradas.Include("Izdajes"))
                {
                    nagrade.Add(item);
                }

                return nagrade;
            }
        }
    }
}
