using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class IzdajeDao : MongoCRUD<Izdaje>
    {
        public IzdajeDao() : base("Izdaje")
        {

        }

        public void Insert(Izdaje izdaje, int knjiga, int odeljenje)
        {
            izdaje.Knjiga = knjiga;
            izdaje.Odeljenje = odeljenje;

            bool pronasao = false;
            int id = 1;

            while (!pronasao)
            {
                Izdaje k = base.FindById(id);

                if (k == null)
                {
                    pronasao = true;
                }
                else
                {
                    id++;
                }
            }

            izdaje.Id = id;

            base.Insert(izdaje);
        }

        public void Update(int id, Izdaje izdaje, int idKnjizare)
        {
            izdaje.Knjizaras.Add(idKnjizare);

            base.Update(id, izdaje);
        }

        public bool DaLiMozeDaSeIzda(int knjiga, int odeljenje)
        {
            List<Izdaje> izdaje = base.GetList().ToList();

            foreach (Izdaje item in izdaje)
            {
                if (item.OdeljenjeOdeljenjeId == odeljenje && item.KnjigaKnjigaId == knjiga)
                {
                    return false;
                }
            }

            return true;
        }

        public List<Izdaje> GetList()
        {

            List<Izdaje> knjige = new List<Izdaje>();

            knjige = base.GetList();

            foreach (Izdaje item in knjige)
            {
                if (item.Knjizaras == null)
                {
                    item.Knjizaras = new List<int>();
                }

                if (item.Nagradas == null)
                {
                    item.Nagradas = new List<int>();
                }

                KnjizaraDao knjizaraDao = new KnjizaraDao();

                item.KnjizarasObjekti = new List<Knjizara>();

                foreach (int p in item.Knjizaras)
                {
                    item.KnjizarasObjekti.Add(knjizaraDao.FindById(p));
                }

                NagradaDao nagradaDao = new NagradaDao();

                item.NagradasObjekti = new List<Nagrada>();

                foreach (long p in item.Nagradas)
                {
                    item.NagradasObjekti.Add(nagradaDao.FindById(p));
                }

                KnjigaDao knjigaDao = new KnjigaDao();
                OdeljenjeDao odeljenjeDao = new OdeljenjeDao();

                item.KnjigaObjekat = knjigaDao.FindById(item.KnjigaKnjigaId);
                item.OdeljenjeObjekat = odeljenjeDao.FindById(item.OdeljenjeOdeljenjeId);
            }

            return knjige;
        }
    }
}

