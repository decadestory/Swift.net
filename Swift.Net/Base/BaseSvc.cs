using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Swift.Net.API;
using Swift.Net.Core;

namespace Swift.Net.Base
{
    public class BaseSvc<TEntity> where TEntity : BaseEntity
    {
        private SContext EfContext
        {
            get
            {
                return SDbSession.Current();
            }
        }

        protected virtual IQueryable<TEntity> Entities
        {
            get
            {
                return EfContext.Set<TEntity>();
            }
        }

        protected int Commit()
        {
            return EfContext.SaveChanges();
        }

        protected int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, bool isSave = true)
        {
            List<TEntity> list = this.EfContext.Set<TEntity>().Where<TEntity>(predicate).ToList<TEntity>();
            return ((list.Count > 0) ? this.Delete((IEnumerable<TEntity>)list, isSave) : 0);
        }

        protected int Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            this.RegisterDeleted<TEntity>(entities);
            return (isSave ? this.EfContext.SaveChanges() : 0);
        }

        protected int Delete(object id, bool isSave = true)
        {
            TEntity entity = this.EfContext.Set<TEntity>().Find(new object[] { id });
            return ((entity != null) ? this.Delete(entity, isSave) : 0);
        }

        protected int Delete(TEntity entity, bool isSave = true)
        {
            RegisterDeleted<TEntity>(entity);
            return (isSave ? this.EfContext.SaveChanges() : 0);
        }

        protected IEnumerable<TEntity> GetAll()
        {
            return this.EfContext.Set<TEntity>().ToList<TEntity>();
        }

        protected TEntity Get(params object[] key)
        {
            return this.EfContext.Set<TEntity>().Find(key);
        }

        protected TEntity GetFirst(Func<TEntity, bool> where)
        {
            return this.EfContext.Set<TEntity>().FirstOrDefault(where);
        }

        protected int Add(IEnumerable<TEntity> entities, bool isSave = true)
        {
            this.RegisterNew<TEntity>(entities);
            return (isSave ? this.EfContext.SaveChanges() : 0);
        }

        protected int Add(TEntity entity, bool isSave = true)
        {
            this.RegisterNew<TEntity>(entity);
            return (isSave ? this.EfContext.SaveChanges() : 0);
        }

        protected int Update(IEnumerable<TEntity> entities, bool isSave = true)
        {
            if (!isSave) return 0;
            this.RegisterModified<TEntity>(entities);
            return this.Commit();
        }

        protected int Update(TEntity entity, bool isSave = true)
        {
            if (!isSave) return 0;
            this.RegisterModified<TEntity>(entity);
            return this.Commit();
        }
        
        public int RowsCount(Func<TEntity, bool> where = null)
        {
            return where == null ?
                this.EfContext.Set<TEntity>().Count() :
                 this.EfContext.Set<TEntity>().Where(where).Count();
        }

        /// <summary>
        /// 实体分页：不可自定义排序，些方法为时间倒序排
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">分页条件</param>
        /// <returns>PaginationResult</returns>
        protected PaginationResult<TEntity> GetPageList(int pageIndex, int pageSize, Func<TEntity, bool> where=null)
        {
            var total = where == null ? Entities.Count() : Entities.Where(where).Count();
            var result = where == null ? Entities.OrderByDescending(v => v.AddTime).Skip((pageIndex - 1)*pageSize).Take(pageSize).AsQueryable()
            : Entities.Where(where).OrderByDescending(v => v.AddTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();
            return new PaginationResult<TEntity> { Total = total, Rows = result.ToList() };
        }

        /// <summary>
        /// 实体分页：可自定义升序排序
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">分页条件</param>
        /// <param name="order">排序字段</param>
        /// <returns>PaginationResult</returns>
        protected PaginationResult<TEntity> GetPageListOrderAsc<T>(int pageIndex, int pageSize, Func<TEntity, T> order, Func<TEntity, bool> where=null)
        {
            var total = where == null ? Entities.Count() : Entities.Where(where).Count();
                var result =where == null ?  Entities.Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderBy(order) 
                    : Entities.Where(where).Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderBy(order);
            return new PaginationResult<TEntity>{Total = total,Rows = result.ToList()};
        }

        /// <summary>
        /// 实体分页：可自定义降序排序
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">分页条件</param>
        /// <param name="order">排序字段</param>
        /// <returns>PaginationResult</returns>
        protected PaginationResult<TEntity> GetPageListOrderDesc<T>(int pageIndex, int pageSize, Func<TEntity, T> order, Func<TEntity, bool> where = null)
        {
            var total = where == null ? Entities.Count() : Entities.Where(where).Count();
            var result = where == null ? Entities.Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderBy(order)
                : Entities.Where(where).Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(order);
            return new PaginationResult<TEntity> { Total = total, Rows = result.ToList() };
        }

        #region 修改实体状态
        private void RegisterDeleted<TEt>(TEt entity) where TEt : BaseEntity
        {
            this.EfContext.Entry<TEt>(entity).State = EntityState.Deleted;
        }
        private void RegisterDeleted<TEt>(IEnumerable<TEt> entities) where TEt : BaseEntity
        {
            try
            {
                this.EfContext.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEt local in entities)
                {
                    this.RegisterDeleted<TEt>(local);
                }
            }
            finally
            {
                this.EfContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        private void RegisterModified<TEt>(TEt entity) where TEt : BaseEntity
        {
            if (this.EfContext.Entry<TEt>(entity).State == EntityState.Detached)
            {
                this.EfContext.Set<TEt>().Attach(entity);
            }
            this.EfContext.Entry<TEt>(entity).State = EntityState.Modified;
        }
        private void RegisterModified<TEt>(IEnumerable<TEt> entities) where TEt : BaseEntity
        {
            try
            {
                this.EfContext.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEt local in entities)
                {
                    this.RegisterModified<TEt>(local);
                }
            }
            finally
            {
                this.EfContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        private void RegisterNew<TEt>(TEt entity) where TEt : BaseEntity
        {
            if (this.EfContext.Entry<TEt>(entity).State == EntityState.Detached)
            {
                this.EfContext.Entry<TEt>(entity).State = EntityState.Added;
            }
        }
        private void RegisterNew<TEt>(IEnumerable<TEt> entities) where TEt : BaseEntity
        {
            try
            {
                this.EfContext.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEt local in entities)
                {
                    this.RegisterNew<TEt>(local);
                }
            }
            finally
            {
                this.EfContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        #endregion

    }
}
