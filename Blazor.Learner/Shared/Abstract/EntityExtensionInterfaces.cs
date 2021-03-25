namespace BlazorCookies.Models
{
    using System;
    using System.Collections.Generic;
  //  using System.ComponentModel.DataAnnotations;

    using System.Linq;
  
    using System.Linq.Expressions;


    
        public interface IDBTable<TEntity> where TEntity : class
        {
            IQueryable<TEntity> Get(
               Expression<Func<TEntity, bool>> filter = null,
               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
               string includeProperties = "");
            IEnumerable<TEntity> GetList(
               Expression<Func<TEntity, bool>> filter = null,
               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
               string includeProperties = "");
            TEntity GetByID(object id);
            void Insert(TEntity entity);
            void Delete(object id);
            void Delete(TEntity entityToDelete);
            void Update(TEntity entityToUpdate);
            void Save();
        }

    public interface IViewExtensionData<TEntity>
    {
        TEntity GetEntity();
    }


}
