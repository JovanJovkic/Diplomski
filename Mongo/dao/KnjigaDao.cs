using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class KnjigaDao : MongoCRUD<Knjiga>
    {
        public KnjigaDao() : base("Knjiga")
        {

        }

        public void Insert(Knjiga entity, List<long> pisci, List<int> kategorije)
        {
            PisacDao daoPisac = new PisacDao();
            KategorijaDao daoKategorija = new KategorijaDao();

            entity.Pisacs = new List<long>();

            foreach (long item in pisci)
            {
                entity.Pisacs.Add(item);
                daoPisac.DodajPiscuKnjigu(item, entity.KnjigaId);
            }

            entity.Kategorijas = new List<int>();

            foreach (int item in kategorije)
            {
                entity.Kategorijas.Add(item);
                daoKategorija.DodajKategorijiKnjige(item, entity.KnjigaId);
            }

            base.Insert(entity);
        }

        public void Update(int id, Knjiga entity, List<long> pisci, List<int> kategorije)
        {
            PisacDao daoPisac = new PisacDao();
            KategorijaDao daoKategorija = new KategorijaDao();

            if (entity.Pisacs != null)
            {
                foreach (long item in entity.Pisacs)
                {
                    daoPisac.ObrisiPiscuKnjigu(item, entity.KnjigaId);
                }
            }

            if (entity.Kategorijas != null)
            {
                foreach (int item in entity.Kategorijas)
                {
                    daoKategorija.ObrisiKategorijiKnjigu(item, entity.KnjigaId);
                }
            }

            entity.Pisacs = new List<long>();

            foreach (long item in pisci)
            {
                entity.Pisacs.Add(item);
                daoPisac.DodajPiscuKnjigu(item, entity.KnjigaId);
            }

            entity.Kategorijas = new List<int>();

            foreach (int item in kategorije)
            {
                entity.Kategorijas.Add(item);
                daoKategorija.DodajKategorijiKnjige(item, entity.KnjigaId);
            }

            base.Update(id, entity);
        }

        public bool DaLiMozeDaSeObrise(int id)
        {

            Knjiga knjiga = base.FindById(id);

            if (knjiga.Recenzijas != null)
            {
                if (knjiga.Recenzijas.Count > 0)
                    return false;
            }

            if (knjiga.Pisacs != null)
            {
                if (knjiga.Pisacs.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Knjiga> GetList()
        {

            List<Knjiga> knjige = new List<Knjiga>();

            knjige = base.GetList();

            foreach (Knjiga item in knjige)
            {
                if(item.Pisacs==null)
                {
                    item.Pisacs = new List<long>();
                }

                if (item.Recenzijas == null)
                {
                    item.Recenzijas = new List<int>();
                }

                if (item.Kategorijas == null)
                {
                    item.Kategorijas = new List<int>();
                }

                PisacDao pisacDao = new PisacDao();

                item.PisacsObjekti = new List<Pisac>();

                foreach (long p in item.Pisacs)
                {
                    item.PisacsObjekti.Add(pisacDao.FindById(p));
                }

                RecenzijaDao recenzijaDao = new RecenzijaDao();

                item.RecenzijasObjekti = new List<Recenzija>();

                foreach (long p in item.Recenzijas)
                {
                    item.RecenzijasObjekti.Add(recenzijaDao.FindById(p));
                }

                KategorijaDao kategorijaDao = new KategorijaDao();

                item.KategorijasObjekti = new List<Kategorija>();

                foreach (int kat in item.Kategorijas)
                {
                    item.KategorijasObjekti.Add(kategorijaDao.FindById(kat));
                }
            }

            return knjige;
        }

        public void DodajKnjiziRecenziju(int idKnjige, int idRecenzije)
        {
            Knjiga knjiga = base.FindById(idKnjige);

            if (knjiga.Recenzijas == null)
            {
                knjiga.Recenzijas = new List<int>();
            }

            knjiga.Recenzijas.Add(idRecenzije);

            base.Update(knjiga.KnjigaId, knjiga);
        }

        public void ObrisiKnjiziRecenziju(int idKnjige, int idRecenzije)
        {
            Knjiga knjiga = base.FindById(idKnjige);

            knjiga.Recenzijas.Remove(idRecenzije);

            base.Update(knjiga.KnjigaId, knjiga);
        }
    }
}