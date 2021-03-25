using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BlazorTemplate.Server.Data;





namespace BlazorTemplate.Models
{
   

    public class DBView<TEntity, TViewExtensionEntity> : DBTable<TEntity> where TEntity : class where TViewExtensionEntity : class
    {
        protected IQueryable vwQuery;
        public DBView(ApplicationDbContext dbContext, IQueryable vwquery=null) : base(dbContext)
        {
            vwQuery = vwquery;
        }

        public bool SetQuery(IQueryable _query)
        {
            if (vwQuery != null)
            {
                vwQuery = null;
            }
            vwQuery = _query;
            return vwQuery != null;
        }
               

         public IQueryable<TViewExtensionEntity> GetView()
        {
            return (IQueryable<TViewExtensionEntity>)vwQuery;
        }


        public virtual IQueryable<TViewExtensionEntity> GetView(
           Expression<Func<TViewExtensionEntity, bool>> filter = null,
           Func<IQueryable<TViewExtensionEntity>, IOrderedQueryable<TViewExtensionEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TViewExtensionEntity> query = (IQueryable < TViewExtensionEntity > )vwQuery;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        

    }
}