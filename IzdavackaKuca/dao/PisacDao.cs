using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class PisacDao : BaseRepo<Pisac>
    {
        public void Insert(Pisac entity, long idRadnika)
        { 
            using (var db = new ModelIzdavackaKucaContainer())
            {
                entity.Radnik = db.Radniks.Find(idRadnika);
                db.Pisacs.Add(entity);
                db.SaveChanges();
            }
        }

        public bool DaLiMozeDaSeObrise(Int64 jmbg)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Pisac pisac = db.Pisacs.Where(c => c.Jmbg.Equals(jmbg)).FirstOrDefault();

                if (pisac.Dogadjajs.Count > 0)
                    return false;

                if (pisac.Knjigas.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Pisac> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                //db.Pisacs.Where(x => x.Dogadjajs.Any(y => x.Jmbg == value)).ToList()

                //db.Pisacs.Where(c => c.Jmbg == ).SelectMany(c => c.Dogadjajs)

                List<Pisac> pisci = new List<Pisac>();

                db.Pisacs.Include("Dogadjaj");

                foreach (Pisac item in db.Pisacs.Include("Dogadjajs").Include("Knjigas").Include("Radnik"))
                {
                    //IQueryable<Dogadjaj> s = db.Pisacs.Where(c => c.Jmbg == item.Jmbg).SelectMany(c => c.Dogadjajs);
                    //var query = from article in db.Dogadjajs
                    //            where article.Pisacs.Any(c => c.Jmbg == item.Jmbg)
                    //            select article;
                    pisci.Add(item);
                }

                return pisci;
            }
        }
    }
}