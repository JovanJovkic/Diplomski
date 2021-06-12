using Mongo.entiteti;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    public class KorisnikDao : MongoCRUD<Korisnik>
    {
        public KorisnikDao() : base("Korisnik")
        {

        }

        public bool Login(string username, string password)
        {
            IMongoDatabase db = base.MongoBaza();

            var collection = db.GetCollection<Korisnik>("Korisnik");
            var filter = Builders<Korisnik>.Filter.Eq("Username", username);

            Korisnik korisnik = collection.Find(filter).FirstOrDefault();

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


        public bool DaLiPostojiUsername(string username)
        {
            IMongoDatabase db = base.MongoBaza();

            var collection = db.GetCollection<Korisnik>("Korisnik");
            var filter = Builders<Korisnik>.Filter.Eq("Username", username);

            Korisnik korisnik = collection.Find(filter).FirstOrDefault();

            if (korisnik != null)
            {
                return true;
            }

            return false;

        }

        public bool PromeniLozinku(string username, string staraLozinka, string novaLozinka)
        {
            IMongoDatabase db = base.MongoBaza();

            var collection = db.GetCollection<Korisnik>("Korisnik");
            var filter = Builders<Korisnik>.Filter.Eq("Username", username);

            Korisnik korisnik = collection.Find(filter).FirstOrDefault();

            if (korisnik.Password != staraLozinka)
            {
                return false;
            }

            korisnik.Password = novaLozinka;

            base.Update(korisnik.Id, korisnik);

            return true;
        }

        public void DodajKnjizaru(string naziv)
        {
            if(!DaLiPostojiUsername(naziv))
            {
                Korisnik korisnik = new Korisnik();
                korisnik.Username = naziv;
                korisnik.Password = naziv;
                korisnik.Uloga = UlogaKorisnika.KNJIZARA;

                bool pronasao = false;
                int id = 1;

                while (!pronasao)
                {
                    Korisnik k = base.FindById(id);

                    if (k == null)
                    {
                        pronasao = true;
                    }
                    else
                    {
                        id++;
                    }
                }

                korisnik.Id = id;

                base.Insert(korisnik);
            }
        }

        public UlogaKorisnika ulogaPoImenu(string username)
        {
            IMongoDatabase db = base.MongoBaza();

            var collection = db.GetCollection<Korisnik>("Korisnik");
            var filter = Builders<Korisnik>.Filter.Eq("Username", username);

            Korisnik korisnik = collection.Find(filter).FirstOrDefault();

            return korisnik.Uloga;
        }
    }
}
