using JogosAPI.Domain.Entities;
using JogosAPI.Domain.Filters;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace JogosAPI.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, TFilter> : IBaseRepository<TEntity, TFilter>, IDisposable
        where TEntity : BaseEntity
        where TFilter : BaseFilter
    {
        protected readonly JogosAPIContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public IQueryable<TEntity> Query
        {
            get { return DbSet.AsNoTracking(); }
        }

        public BaseRepository(JogosAPIContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                return SaveChanges() > 0 ? entity : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public virtual bool Delete(int id)
        {
            try
            {
                DbSet.Remove(DbSet.Find(id));
                return SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public virtual IQueryable<TEntity> GetAll(TFilter filter, bool contains = false)
        {
            try
            {
                return Query;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public virtual bool Update(TEntity entity)
        {
            try
            {
                Db.Entry(entity).State = EntityState.Detached;
                DbSet.Update(entity);
                return SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"message: {ex.Message} | stackTrace: {ex.StackTrace}");
            }
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}
