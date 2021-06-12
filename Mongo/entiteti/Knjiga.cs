using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Knjiga
    {
        [BsonId]
        public int KnjigaId { get; set; }
        public int BrojPoglavlja { get; set; }
        public int BrojStrana { get; set; }
        public string Naziv { get; set; }

        public  ICollection<int> Kategorijas { get; set; }
       
        public  ICollection<int> Recenzijas { get; set; }
        public  ICollection<long> Pisacs { get; set; }

        public  ICollection<int> Izdajes { get; set; }

        [BsonIgnore]
        public ICollection<Kategorija> KategorijasObjekti { get; set; }
        [BsonIgnore]
        public ICollection<Recenzija> RecenzijasObjekti { get; set; }
        [BsonIgnore]
        public ICollection<Pisac> PisacsObjekti { get; set; }
        [BsonIgnore]
        public ICollection<Izdaje> IzdajesObjekti { get; set; }
    }
}
