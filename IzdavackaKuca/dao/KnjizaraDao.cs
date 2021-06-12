using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class KnjizaraDao : BaseRepo<Knjizara>
    {
        public bool DaLiMozeDaSeObrise(int id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Knjizara knjizara = db.Knjizaras.Where(c => c.KnjizaraId.Equals(id)).FirstOrDefault();

                if (knjizara.Izdajes.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Knjizara> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Knjizara> knjizarae = new List<Knjizara>();

                foreach (Knjizara item in db.Knjizaras.Include("Izdajes"))
                {
                    knjizarae.Add(item);
                }

                return knjizarae;
            }
        }
    }
}
