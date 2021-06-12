using Mongo.entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class OdeljenjeDao : MongoCRUD<Odeljenje>
    {
        public OdeljenjeDao() : base("Odeljenje")
        {
        }

        public bool DaLiMozeDaSeObrise(int id)
        {

            Odeljenje odeljenje = base.FindById(id);

            if (odeljenje.Radniks != null)
            {
                if (odeljenje.Radniks.Count > 0)
                    return false;
            }

            if (odeljenje.Izdajes != null)
            {
                if (odeljenje.Izdajes.Count > 0)
                    return false;
            }

            return true;
        }

        public List<Odeljenje> GetList()
        {

            List<Odeljenje> odeljenja = new List<Odeljenje>();

            odeljenja = base.GetList();

            foreach (Odeljenje item in odeljenja)
            {
                RadnikDao radnikDao = new RadnikDao();

                if (item.Radniks == null)
                {
                    item.Radniks = new List<long>();
                }

                item.RadniksObjekti = new List<Radnik>();

                foreach (long p in item.Radniks)
                {
                    item.RadniksObjekti.Add(radnikDao.FindById(p));
                }
            }

            return odeljenja;
        }

        public void DodajRadnikaOdeljenju(int idOdeljenja, long jmbgRadnika)
        {
            Odeljenje odeljenje = base.FindById(idOdeljenja);

            if (odeljenje.Radniks == null)
            {
                odeljenje.Radniks = new List<long>();
            }

            odeljenje.Radniks.Add(jmbgRadnika);

            base.Update(odeljenje.OdeljenjeId, odeljenje);
        }

        public void ObrisiRadnikaOdeljenju(int idOdeljenja, long jmbgRadnika)
        {
            Odeljenje odeljenje = base.FindById(idOdeljenja);

            odeljenje.Radniks.Remove(jmbgRadnika);

            base.Update(odeljenje.OdeljenjeId, odeljenje);
        }
    }
}
