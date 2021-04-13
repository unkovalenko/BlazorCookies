using System;
using System.Linq;
using BlazorCookies.Models;
using BlazorCookies.Shared;
using BlazorCookies.Server.Data;
namespace BlazorCookies.DAL
{   
    public  class EUnitOfWork : IDisposable
    {
        private ApplicationDBContext _context;
       // private DBView<USERS, UserExtensionData> viewUsers;
        private DBTable<EXCHCHECK> tblExchcheck;
        public EUnitOfWork (ApplicationDBContext dbcontext )
        {
            _context = dbcontext;
        }

        #region DATASET 



       

      

        public DBTable<EXCHCHECK> TblExchcheck
        {
            get
            {
                if (this.tblExchcheck == null)
                {
                    this.tblExchcheck = new DBTable<EXCHCHECK>(this._context);
                }
                return tblExchcheck;
            }
        }
        #endregion
        #region MANIPULATION
        public void Save()
        {
            _context.SaveChanges();
            
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public bool Commit()
        {
            try
            {
                _context.Database.CommitTransaction();
                return true;

            }
            catch 
            {
                return false;
            }
        }
        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
        #endregion
        #region DISPOSE
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}