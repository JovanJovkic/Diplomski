using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Izdaje
    {
        [BsonId]
        public int Id { get; set; }
        public int KnjigaKnjigaId { get; set; }
        public int OdeljenjeOdeljenjeId { get; set; }

        public int Odeljenje { get; set; }

        public ICollection<int> Nagradas { get; set; }

        public ICollection<int> Knjizaras { get; set; }
        public int Knjiga { get; set; }

        [BsonIgnore]
        public Odeljenje OdeljenjeObjekat { get; set; }
        [BsonIgnore]
        public ICollection<Nagrada> NagradasObjekti { get; set; }
        [BsonIgnore]
        public ICollection<Knjizara> KnjizarasObjekti { get; set; }
        [BsonIgnore]
        public Knjiga KnjigaObjekat { get; set; }
       
  
    }
}
