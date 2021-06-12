using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public enum UlogaKorisnika
    {
        ADMIN,
        KNJIZARA,
        DIREKTOR
    }
    public class Korisnik
    {
        [BsonId]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UlogaKorisnika Uloga { get; set; }
    }
}
