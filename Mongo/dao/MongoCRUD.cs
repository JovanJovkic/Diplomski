using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.dao
{
    //public class MongoCRUD
    public abstract class MongoCRUD<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IMongoDatabase db;
        private string table="";
        public MongoCRUD(string tableName)
        {
            string database = "IzdavackaKuca";
            var client = new MongoClient();
            db = client.GetDatabase(database);
            table = tableName;
        }

        public IMongoDatabase MongoBaza()
        {
            return db;
        }

        public TEntity FindById(object Id)
        {
                var collection = db.GetCollection<TEntity>(table);
                var filter = Builders<TEntity>.Filter.Eq("_id", Id);

                 return collection.Find(filter).FirstOrDefault();
        }

        public List<TEntity> GetList()
        {
            var collection = db.GetCollection<TEntity>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public void Insert(TEntity entuty)
        {
            var collection = db.GetCollection<TEntity>(table);
            collection.InsertOne(entuty);
        }

        public void Delete(object id)
        {
            var collection = db.GetCollection<TEntity>(table);
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }

        public void Update(int id, TEntity entityToUpdate)
        {
            var collection = db.GetCollection<TEntity>(table);

            var result = collection.ReplaceOne(new BsonDocument("_id", id), entityToUpdate, new UpdateOptions { IsUpsert = true });
        }
    }
}
