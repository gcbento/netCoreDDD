using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogosAPI.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, TFilter> : IBaseRepository<TEntity, TFilter>, IDisposable
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        protected readonly JogosAPIContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(JogosAPIContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return SaveChanges() > 0 ? entity : null;
        }

        public bool Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            return SaveChanges() > 0;
        }

        public virtual IQueryable<TEntity> GetAll(TFilter filter)
        {
            return DbSet;
        }

        public virtual TEntity GetBy(TFilter filter)
        {
            return DbSet.Find(filter.Id);
        }

        public bool Update(TEntity entity)
        {
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
