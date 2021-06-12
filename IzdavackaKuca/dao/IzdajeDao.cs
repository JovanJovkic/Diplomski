using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class IzdajeDao : BaseRepo<Izdaje>
    {
        public void Insert(Izdaje izdaje, int knjiga, int odeljenje)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                //entity.Knjiga = db.Radniks.Find(idRadnika);


                izdaje.Knjiga = db.Knjigas.Find(knjiga);
                izdaje.Odeljenje = db.Odeljenjes.Find(odeljenje);


                db.Izdajes.Add(izdaje);
                db.SaveChanges();
            }
        }

        public bool DaLiMozeDaSeIzda(int knjiga, int odeljenje)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                List<Izdaje> izdaje = db.Izdajes.ToList();

                foreach (Izdaje item in izdaje)
                {
                    if(item.OdeljenjeOdeljenjeId==odeljenje && item.KnjigaKnjigaId==knjiga)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
