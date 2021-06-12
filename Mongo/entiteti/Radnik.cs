using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Radnik
    {
        [BsonId]
        public long Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Plata { get; set; }
        public string Mesto { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string Telefon { get; set; }
        public int OdeljenjeOdeljenjeId { get; set; }

        public  int Odeljenje { get; set; }
        public  long Pisac { get; set; }
        public  long Kriticar { get; set; }

        [BsonIgnore]
        public Odeljenje OdeljenjeObjekat { get; set; }
        [BsonIgnore]
        public Pisac PisacObjekat { get; set; }
        [BsonIgnore]
        public Kriticar KriticarObjekat { get; set; }
    }
}
