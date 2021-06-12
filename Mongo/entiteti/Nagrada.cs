using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Nagrada
    {
        [BsonId]
        public int NagradaId { get; set; }
        public string Naziv { get; set; }
        public int NovcanaNagrada { get; set; }
        public bool Drzavna { get; set; }

         public ICollection<int> Izdajes { get; set; }

        [BsonIgnore]
        public ICollection<Izdaje> IzdajesObjekti { get; set; }
    }
}
