using FullStackDeveloperTask.App.ViewModel;
using FulStackDeveloperTask.App.Database;
using FulStackDeveloperTask.App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Operation
{
    public class BaseOperation<TEntity> : IDisposable where TEntity : BaseModel
    {
        internal CountryDbContext Context;
        internal DbSet<TEntity> DbSet;

        public BaseOperation(CountryDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }
        
        public List<TEntity> GetAllEntities()
        {
            return this.DbSet.ToList();
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Save(TEntity model, bool commit = true){
            DbSet.Add(model);
            if (commit)
                Context.SaveChanges();
        }
        public virtual void Update(TEntity model, bool commit = true)
        {
            var entry = Context.Entry<TEntity>(model);

            if (entry.State == EntityState.Detached)
            {
                var set = Context.Set<TEntity>();
                TEntity attachedEntity = set.Find(model.Id);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = Context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(model);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
            if (commit)
                Context.SaveChanges();
        }
        public virtual void Delete(TEntity model, bool commit = true)
        {
            if (Context.Entry(model).State == EntityState.Detached)
            {
                DbSet.Attach(model);
            }
            DbSet.Remove(model);
            if (commit)
                Context.SaveChanges();
        }

        public virtual void Delete(object id, bool commit = false)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete, commit);
        }

        public void Dispose()
        {
            Context.Dispose();
            Context = null;
        }
    }
}