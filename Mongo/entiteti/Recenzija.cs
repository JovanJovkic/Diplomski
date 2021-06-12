using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.entiteti
{
    public class Recenzija
    {
        [BsonId]
        public int RecenzijaId { get; set; }
        public int Ocena { get; set; }
        public int BrojStrana { get; set; }
        public int KnjigaKnjigaId { get; set; }

        public  int Knjiga { get; set; }
         public  long Kriticar { get; set; }

        [BsonIgnore]
        public Knjiga KnjigaObjekat { get; set; }

        [BsonIgnore]
        public Kriticar KriticarObjekat { get; set; }
    }
}
