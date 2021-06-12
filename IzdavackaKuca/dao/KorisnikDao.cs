using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public class KorisnikDao : BaseRepo<Korisnik>
    {
        public bool Login(string username, string password)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Korisnik korisnik = db.Korisniks.Where(kor => kor.Username == username).FirstOrDefault();

                if (korisnik == null)
                {
                    return false;
                }

                if (korisnik.Password != password)
                {
                    return false;
                }

                return true;
            }
        }

        public bool DaLiPostojiUsername(string username)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Korisnik korisnik = db.Korisniks.Where(kor => kor.Username == username).FirstOrDefault();

                if (korisnik != null)
                {
                    return true;
                }

                return false;
            }
        }

        public bool PromeniLozinku(string username, string staraLozinka, string novaLozinka)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                Korisnik korisnik = db.Korisniks.Where(kor => kor.Username == username).FirstOrDefault();

                if(korisnik.Password!=staraLozinka)
                {
                    return false;
                }

                korisnik.Password = novaLozinka;

                db.Set<Korisnik>().Attach(korisnik);
                db.Entry(korisnik).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
        }
    }
}
