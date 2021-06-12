using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Knjizara
    {
        [BsonId]
        public int KnjizaraId { get; set; }
        public string Naziv { get; set; }
        public string Mesto { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string Telefon { get; set; }
        public string Pib { get; set; }

         public  ICollection<int> Izdajes { get; set; }

        [BsonIgnore]
        public ICollection<Izdaje> IzdajesObjekti { get; set; }
    }
}