using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class RecenzijaDao : MongoCRUD<Recenzija>
    {
        public RecenzijaDao() : base("Recenzija")
        {
        }

        
        public void Insert(Recenzija entity, long idKriticara, int idKnjige)
        {
            entity.Kriticar = idKriticara;
            entity.Knjiga = idKnjige;

            base.Insert(entity);

            KriticarDao kriticarDao = new KriticarDao();
            KnjigaDao knjigaDao = new KnjigaDao();

            kriticarDao.DodajKriticaruRecenziju(idKriticara, entity.RecenzijaId);
            knjigaDao.DodajKnjiziRecenziju(idKnjige, entity.RecenzijaId);
        }

        public void Update(int id,Recenzija recenzija, long idKriticaraStari, int idKnjigeStari)
        {
            base.Update(id, recenzija);

            KriticarDao kriticarDao = new KriticarDao();
            kriticarDao.ObrisiKriticaruRecenziju(idKriticaraStari, recenzija.RecenzijaId);
            kriticarDao.DodajKriticaruRecenziju(recenzija.Kriticar, recenzija.RecenzijaId);

            KnjigaDao knjigaDao = new KnjigaDao();
            knjigaDao.ObrisiKnjiziRecenziju(idKnjigeStari, recenzija.RecenzijaId);
            knjigaDao.DodajKnjiziRecenziju(recenzija.Knjiga, recenzija.RecenzijaId);
        }
        
        public bool DaLiMozeDaSeObrise(int id)
        {
            Recenzija recenzija = base.FindById(id);

            if (recenzija.Knjiga != 0)
                return false;

            return true;
        }

        public List<Recenzija> GetList()
        {

            List<Recenzija> recenzije = new List<Recenzija>();

            recenzije = base.GetList();

            foreach (Recenzija item in recenzije)
            {
                KriticarDao kriticarDao = new KriticarDao();

                item.KriticarObjekat = kriticarDao.FindById(item.Kriticar);

                KnjigaDao knjigaDao = new KnjigaDao();

                item.KnjigaObjekat = knjigaDao.FindById(item.Knjiga);

            }

            return recenzije;
        }
    }
}