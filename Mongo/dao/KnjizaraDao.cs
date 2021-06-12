using Mongo.entiteti;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class KnjizaraDao : MongoCRUD<Knjizara>
    {
        public KnjizaraDao() : base("Knjizara")
        {

        }

        public bool DaLiMozeDaSeObrise(int id)
        {
            Knjizara knjizara = base.FindById(id);

            if (knjizara.Izdajes != null)
            {
                if (knjizara.Izdajes.Count > 0)
                    return false;
            }

            return true;
        }

        public void Update(int id, Knjizara knjizara, int izdaje)
        {
            if (knjizara.Izdajes == null)
            {
                knjizara.Izdajes = new List<int>();
            }

            knjizara.Izdajes.Add(izdaje);

            base.Update(id, knjizara);
        }

        public Knjizara OdrediNaOsnovuImena(string naziv)
        {
            IMongoDatabase db = base.MongoBaza();

            var collection = db.GetCollection<Knjizara>("Knjizara");
            var filter = Builders<Knjizara>.Filter.Eq("Naziv", naziv);

            Knjizara knjizara = collection.Find(filter).FirstOrDefault();

            return knjizara;
        }

        /*
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
        }*/
    }
}
