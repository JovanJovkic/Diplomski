using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class OdeljenjeDao : BaseRepo<Odeljenje>
    {
        public bool DaLiMozeDaSeObrise(int id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Odeljenje odeljenje = db.Odeljenjes.Where(c => c.OdeljenjeId.Equals(id)).FirstOrDefault();

                if (odeljenje.Radniks.Count > 0)
                    return false;

                if (odeljenje.Izdajes.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Odeljenje> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Odeljenje> odeljenja = new List<Odeljenje>();

                foreach (Odeljenje item in db.Odeljenjes.Include("Izdajes"))
                {
                    odeljenja.Add(item);
                }

                return odeljenja;
            }
        }
    }
}
