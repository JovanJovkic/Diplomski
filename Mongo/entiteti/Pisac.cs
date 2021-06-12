using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Pisac
    {
        [BsonId]
        public long Jmbg { get; set; }

        public  long Radnik { get; set; }

        public  ICollection<int> Knjigas { get; set; }

        public  ICollection<int> Dogadjajs { get; set; }

        [BsonIgnore]
        public Radnik RadnikObjekat { get; set; }

        [BsonIgnore]
        public ICollection<Knjiga> KnjigasObjekti { get; set; }

        [BsonIgnore]
        public ICollection<Dogadjaj> DogadjajsObjekti { get; set; }
    }
}
