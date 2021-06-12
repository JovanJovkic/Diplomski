using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class NagradaDao : MongoCRUD<Nagrada>
    {
        public NagradaDao() : base("Nagrada")
        {

        }
        /*
        public void InsertN(Nagrada entity)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                db.Set<Nagrada>().Add(entity);
                db.SaveChanges();
            }
        }*/

        public bool DaLiMozeDaSeObrise(int id)
        {
            Nagrada nagrada = base.FindById(id);

            if (nagrada.Izdajes != null)
            {
                if (nagrada.Izdajes.Count > 0)
                    return false;
            }

            return true;
        }
        
        public List<Nagrada> GetList()
        {
          
                List<Nagrada> nagrade = new List<Nagrada>();

            nagrade = base.GetList();

          // izdaje

            return nagrade;
            
        }
    }
}
