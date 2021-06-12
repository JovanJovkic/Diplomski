using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Dogadjaj
    {
        [BsonId]
        public int DogadjajId { get; set; }
        public string Mesto { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public int BrojMesta { get; set; }
        public string Tip { get; set; }
        public string Posveceno { get; set; }
        public  ICollection<long> Pisacs { get; set; }

        [BsonIgnore]
        public ICollection<Pisac> PisacsObjekti { get; set; }
    }
}
