using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Kriticar
    {
        [BsonId]
        public long Jmbg { get; set; }

          public  long Radnik { get; set; }

         public  ICollection<int> Recenzijas { get; set; }

        [BsonIgnore]
        public Radnik RadnikObjekat { get; set; }

        [BsonIgnore]
        public ICollection<Recenzija> RecenzijasObjekti { get; set; }
    }
}
