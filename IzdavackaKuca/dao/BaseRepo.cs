using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKuca.dao
{
    public abstract class BaseRepo<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public BaseRepo()
        {
           
        }

        public void Delete(object id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {

                //DbSet<TEntity> dbSet = db.Set<TEntity>;
                TEntity entityToDelete = db.Set<TEntity>().Find(id);
                db.Entry(entityToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public TEntity FindById(object Id)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                return db.Set<TEntity>().Find(Id);
            }
        }

        public List<TEntity> GetList()
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(TEntity entityToUpdate)
        {
            using (var db = new ModelIzdavackaKucaContainer())
            {
                db.Set<TEntity>().Attach(entityToUpdate);
                db.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
