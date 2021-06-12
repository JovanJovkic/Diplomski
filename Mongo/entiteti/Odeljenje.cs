using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Odeljenje
    {
        [BsonId]
        public int OdeljenjeId { get; set; }
        public string ImeOsnivaca { get; set; }
        public string PrezimeOsnivaca { get; set; }
        public string Naziv { get; set; }
        public string Mesto { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string Telefon { get; set; }
        public string Pib { get; set; }
        public System.DateTime DatumOsnivanja { get; set; }

        public  ICollection<long> Radniks { get; set; }

        public  ICollection<int> Izdajes { get; set; }

        [BsonIgnore]
        public ICollection<Radnik> RadniksObjekti { get; set; }

        [BsonIgnore]
        public ICollection<Izdaje> IzdajesObjekti { get; set; }
    }
}
