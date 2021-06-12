using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Kategorija
    {
        [BsonId]
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public string KnjizevniRod { get; set; }

        public ICollection<int> Knjigas { get; set; }

        [BsonIgnore]
        public ICollection<Knjiga> KnjigasObjekti { get; set; }
    }
}
