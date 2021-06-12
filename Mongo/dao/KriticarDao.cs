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
    public class KriticarDao : MongoCRUD<Kriticar>
    {
        public KriticarDao() : base("Kriticar")
        {

        }
        
        public void Insert(Kriticar entity, long idRadnika)
        {
            entity.Radnik = idRadnika;
            base.Insert(entity);

            RadnikDao dao = new RadnikDao();
            Radnik radnik = dao.FindById(idRadnika);
            radnik.Kriticar = entity.Jmbg;
            dao.Update(idRadnika, radnik);
        }

        public bool DaLiMozeDaSeObrise(long id)
        {

            Kriticar kriticar = base.FindById(id);

            if (kriticar.Recenzijas != null)
            {
                if (kriticar.Recenzijas.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Kriticar> GetList()
        {
            List<Kriticar> kriticari = new List<Kriticar>();

            kriticari = base.GetList();

            foreach (Kriticar item in kriticari)
            {
                RecenzijaDao recenzijaDao = new RecenzijaDao();

                if (item.Recenzijas == null)
                {
                    item.Recenzijas = new List<int>();
                }

                item.RecenzijasObjekti = new List<Recenzija>();

                foreach (long p in item.Recenzijas)
                {
                    item.RecenzijasObjekti.Add(recenzijaDao.FindById(p));
                }

                RadnikDao radnikDao = new RadnikDao();

                item.RadnikObjekat = radnikDao.FindById(item.Radnik);
            }

            return kriticari;
        }

        public void Update(long id, Kriticar entityToUpdate)
        {
            IMongoDatabase db = base.MongoBaza();

            var collection = db.GetCollection<Kriticar>("Kriticar");

            var result = collection.ReplaceOne(new BsonDocument("_id", id), entityToUpdate, new UpdateOptions { IsUpsert = true });
        }

        public void DodajKriticaruRecenziju(long jmbg, int idRecenzije)
        {
            Kriticar kriticar = base.FindById(jmbg);

            if (kriticar.Recenzijas == null)
            {
                kriticar.Recenzijas = new List<int>();
            }

            kriticar.Recenzijas.Add(idRecenzije);

            Update(kriticar.Jmbg, kriticar);
        }

        public void ObrisiKriticaruRecenziju(long jmbg, int idRecenzije)
        {
            Kriticar kriticar = base.FindById(jmbg);

            kriticar.Recenzijas.Remove(idRecenzije);

            Update(kriticar.Jmbg, kriticar);
        }
    }
}