using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class RadnikDao : BaseRepo<Radnik>
    {
        public bool DaLiMozeDaSeObrise(Int64 id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Radnik radnik = db.Radniks.Where(c => c.Jmbg.Equals(id)).FirstOrDefault();

                if (radnik.Pisac != null)
                    return false;

                if (radnik.Kriticar != null)
                    return false;
            }

            return true;
        }

        public List<Radnik> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Radnik> radnici = new List<Radnik>();

                foreach (Radnik item in db.Radniks)
                {
                    radnici.Add(item);
                }

                return radnici;
            }
        }
    }
}
