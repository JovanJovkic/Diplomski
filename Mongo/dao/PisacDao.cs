using Mongo.entiteti;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class PisacDao : MongoCRUD<Pisac>
    {
        public PisacDao() : base("Pisac")
        {
        }
        
        public void Insert(Pisac entity, long idRadnika)
        {
            entity.Radnik = idRadnika;
            base.Insert(entity);

            RadnikDao dao = new RadnikDao();
            Radnik radnik = dao.FindById(idRadnika);
            radnik.Pisac = entity.Jmbg;
            dao.Update(idRadnika, radnik);
        }

        public bool DaLiMozeDaSeObrise(long jmbg)
        {
            Pisac pisac = base.FindById(jmbg);

            if (pisac.Dogadjajs != null)
            {
                if (pisac.Dogadjajs.Count > 0)
                    return false;
            }

            if (pisac.Knjigas != null)
            {
                if (pisac.Knjigas.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Pisac> GetList()
        {
            List<Pisac> pisci = new List<Pisac>();

            pisci = base.GetList();

            foreach (Pisac item in pisci)
            {
                KnjigaDao knjigaDao = new KnjigaDao();

                if (item.Knjigas == null)
                {
                    item.Knjigas = new List<int>();
                }

                if (item.Dogadjajs == null)
                {
                    item.Dogadjajs = new List<int>();
                }

                item.KnjigasObjekti = new List<Knjiga>();

                foreach (long p in item.Knjigas)
                {
                    item.KnjigasObjekti.Add(knjigaDao.FindById(p));
                }

                DogadjajDao dogadjajDao = new DogadjajDao();

                item.DogadjajsObjekti = new List<Dogadjaj>();

                foreach (long p in item.Dogadjajs)
                {
                    item.DogadjajsObjekti.Add(dogadjajDao.FindById(p));
                }

                RadnikDao radnikDao = new RadnikDao();

                item.RadnikObjekat = radnikDao.FindById(item.Radnik);

            }

            return pisci;
        }

        public void Update(long id, Pisac entityToUpdate)
        {
            IMongoDatabase db = base.MongoBaza();

            var collection = db.GetCollection<Pisac>("Pisac");

            var result = collection.ReplaceOne(new BsonDocument("_id", id), entityToUpdate, new UpdateOptions { IsUpsert = true });
        }

        public void DodajPiscuKnjigu(long jmbg, int idKnjige)
        {
            Pisac pisac = base.FindById(jmbg);

            if (pisac.Knjigas == null)
            {
                pisac.Knjigas = new List<int>();
            }

            pisac.Knjigas.Add(idKnjige);

            Update(pisac.Jmbg, pisac);
        }

        public void DodajPiscuDogadjaj(long jmbg, int idDogadjaja)
        {
            Pisac pisac = base.FindById(jmbg);

            if (pisac.Dogadjajs == null)
            {
                pisac.Dogadjajs = new List<int>();
            }

            pisac.Dogadjajs.Add(idDogadjaja);

            Update(pisac.Jmbg, pisac);
        }

        public void ObrisiPiscuDogadjaj(long jmbg, int idDogadjaja)
        {
            Pisac pisac = base.FindById(jmbg);

            pisac.Dogadjajs.Remove(idDogadjaja);
   
            Update(pisac.Jmbg, pisac);
        }

        public void ObrisiPiscuKnjigu(long jmbg, int idKnjige)
        {
            Pisac pisac = base.FindById(jmbg);

            pisac.Knjigas.Remove(idKnjige);

            Update(pisac.Jmbg, pisac);
        }
    }
}
