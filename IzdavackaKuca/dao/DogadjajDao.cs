using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class DogadjajDao:BaseRepo<Dogadjaj>
    {
        public void Insert(Dogadjaj dogadjaj,List<long> pisci)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                foreach (long item in pisci)
                {
                    dogadjaj.Pisacs.Add(db.Pisacs.Find(item));
                }

                db.Dogadjajs.Add(dogadjaj);
                db.SaveChanges();
            }
        }

        public bool DaLiMozeDaSeObrise(int id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Dogadjaj dogadjaj = db.Dogadjajs.Where(c => c.DogadjajId.Equals(id)).FirstOrDefault();

                if (dogadjaj.Pisacs.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Dogadjaj> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Dogadjaj> dogadjaji = new List<Dogadjaj>();
                
                foreach (Dogadjaj item in db.Dogadjajs.Include("Pisacs"))
                {
                    dogadjaji.Add(item);
                }

                return dogadjaji;
            }
        }
    }
}
