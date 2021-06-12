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
    public class RadnikDao : MongoCRUD<Radnik>
    {
        public RadnikDao() : base("Radnik")
        {
        }

        public void Insert(Radnik radnik)
        {
            base.Insert(radnik);

            OdeljenjeDao dao = new OdeljenjeDao();
            dao.DodajRadnikaOdeljenju(radnik.OdeljenjeOdeljenjeId, radnik.Jmbg);
        }

        public void Update(long id, Radnik radnik, int staroOdeljenje)
        {
            Update(id, radnik);

            OdeljenjeDao dao = new OdeljenjeDao();
            dao.ObrisiRadnikaOdeljenju(staroOdeljenje, radnik.Jmbg);
            dao.DodajRadnikaOdeljenju(radnik.OdeljenjeOdeljenjeId, radnik.Jmbg);
        }

        public bool DaLiMozeDaSeObrise(long id)
        {
            Radnik radnik = base.FindById(id);

            if (radnik.Pisac != 0)
                return false;

            if (radnik.Kriticar != 0)
                return false;

            return true;
        }
        
        
        public List<Radnik> GetList()
        {
           
            List<Radnik> radnici = new List<Radnik>();

            radnici = base.GetList();

            foreach (Radnik item in radnici)
            {
                OdeljenjeDao odeljenjeDao = new OdeljenjeDao();
                item.OdeljenjeObjekat = odeljenjeDao.FindById(item.Odeljenje);

                PisacDao pisacDao = new PisacDao();
                item.PisacObjekat = pisacDao.FindById(item.Pisac);

                KriticarDao kriticarDao = new KriticarDao();
                item.KriticarObjekat = kriticarDao.FindById(item.Kriticar);
            }

            return radnici;
            
        }

        public void Update(long id, Radnik entityToUpdate)
        {
            IMongoDatabase db = base.MongoBaza();

            var collection = db.GetCollection<Radnik>("Radnik");

            var result = collection.ReplaceOne(new BsonDocument("_id", id), entityToUpdate, new UpdateOptions { IsUpsert = true });
        }


    }
}
