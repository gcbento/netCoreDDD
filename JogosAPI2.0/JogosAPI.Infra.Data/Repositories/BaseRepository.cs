using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using JogosAPI.Infra.Data.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, TFilter, TQuery> : IBaseRepository<TEntity, TFilter>, IDisposable
        where TEntity : BaseEntity
        where TFilter : BaseFilter
        where TQuery : BaseQuery<TEntity, TFilter>, new()
    {
        protected readonly JogosAPIContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected TQuery CreateQuery;

        public IQueryable<TEntity> Query
        {
            get { return DbSet.AsNoTracking(); }
        }

        public BaseRepository(JogosAPIContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
            CreateQuery = new TQuery();
        }

        public virtual TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return SaveChanges() > 0 ? entity : null;
        }

        public virtual bool Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            return SaveChanges() > 0;
        }

        public virtual IQueryable<TEntity> GetAll(TFilter filter)
        {
            return Query;
        }

        public virtual TEntity GetBy(int id)
        {
            return Query.FirstOrDefault(x => x.Id == id);
        }

        public virtual TEntity GetBy(TFilter filter)
        {
            return Query.FirstOrDefault(x => x.Id == filter.Id);
        }

        public virtual bool Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Detached;
            DbSet.Update(entity);
            return SaveChanges() > 0;
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}
