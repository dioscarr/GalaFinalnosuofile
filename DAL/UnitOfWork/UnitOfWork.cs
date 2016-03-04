using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Repositories;
using System.Data.Entity;
using System.Reflection;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private DbContext _context;

        public UnitOfWork(string connectionString, string psw)
        {
            _context = new DbContext(GetConnectionString(connectionString, psw));
        }

        public T RepositoryFactory<T>()
        {
            T GRepository = default(T);
            try
            {
                GRepository = (T)Activator.CreateInstance(typeof(T), _context);
            }
            catch (TypeLoadException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            return GRepository;

        }


        public void Save()
        {
           _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Private Functions -- GetConnectionString
        private string GetConnectionString(string name, string psw)
        {
            var originalConnectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            var entityBuilder = new EntityConnectionStringBuilder(originalConnectionString);
            var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
            var providerBuilder = factory.CreateConnectionStringBuilder();

            providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;

            providerBuilder.Add("Password", psw);

            entityBuilder.ProviderConnectionString = providerBuilder.ToString();

            return entityBuilder.ToString();
        }
        #endregion
    }
}