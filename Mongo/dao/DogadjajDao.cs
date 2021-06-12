using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class DogadjajDao : MongoCRUD<Dogadjaj>
    {
        public DogadjajDao() : base("Dogadjaj")
        {
        }

        public void Insert(Dogadjaj dogadjaj, List<long> pisci)
        {
            dogadjaj.Pisacs = new List<long>();

             PisacDao dao = new PisacDao();

            foreach (long item in pisci)
            {
                dogadjaj.Pisacs.Add(item);
                dao.DodajPiscuDogadjaj(item, dogadjaj.DogadjajId);
            }

            base.Insert(dogadjaj);
        }

        public void Update(int id, Dogadjaj dogadjaj, List<long> pisci)
        {
            PisacDao dao = new PisacDao();

            if (dogadjaj.Pisacs != null)
            {
                foreach (long item in dogadjaj.Pisacs)
                {
                    dao.ObrisiPiscuDogadjaj(item, dogadjaj.DogadjajId);
                }
            }

            dogadjaj.Pisacs = new List<long>();

            foreach (long item in pisci)
            {
                dogadjaj.Pisacs.Add(item);
                dao.DodajPiscuDogadjaj(item, dogadjaj.DogadjajId);
            }

            base.Update(id, dogadjaj);
        }

        public bool DaLiMozeDaSeObrise(int id)
        {
            Dogadjaj dogadjaj = base.FindById(id);

            if (dogadjaj.Pisacs != null)
            {
                if (dogadjaj.Pisacs.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Dogadjaj> GetList()
        {

            List<Dogadjaj> dogadjaji = new List<Dogadjaj>();

            dogadjaji = base.GetList();

            foreach (Dogadjaj item in dogadjaji)
            {
                PisacDao pisacDao = new PisacDao();

                item.PisacsObjekti = new List<Pisac>();

                foreach (long p in item.Pisacs)
                {
                    item.PisacsObjekti.Add(pisacDao.FindById(p));
                }
            }

            return dogadjaji;

        }
    }
}
