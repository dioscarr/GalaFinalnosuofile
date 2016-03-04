using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.UnitOfWork;
using DAL.Repositories;
using DAL.Models;

namespace BLL
{
    public class Manage<T, R>
        where T : class
        where R : GenericRepository<T>
    {
        private static readonly string _connectionString = "GalaDBEntities"; // Set the connection string
        private static readonly string _pwd = "DIJGKD%%^324234"; // Set the password

        #region Select methods

        public static List<T> GetAll()
        {
            IList<T> datas;
            using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
            {
                R repository = uow.RepositoryFactory<R>();
                datas = repository.GetAll();
            }
            return datas.ToList();
        }

        public static T GetById(int id)
        {
            T entity;
            using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
            {
                entity = uow.RepositoryFactory<R>().GetById(id);
            }
            return entity;
        }

        public static T GetById(string id)
        {
            T entity;
            using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
            {
                entity = uow.RepositoryFactory<R>().GetById(id);
            }
            return entity;
        }

        public static IList<T> GetBy(string name, string value)
        {
            IList<T> datas;

            using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
            {
                datas = uow.RepositoryFactory<R>().FindBy(name, value);
            }

            return datas.ToList();
        }

        public static IList<T> GetBy(Func<T, bool> where)
        {
            IList<T> datas;

            using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
            {
                datas = uow.RepositoryFactory<R>().FindBy(where);
            }

            return datas.ToList();
        }
        #endregion

        #region Insert method

        public static bool Add(T entity)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
                {
                    uow.RepositoryFactory<R>().Add(entity);
                   uow.Save();
                   
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Update method
        public static bool Update(T entity)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
                {
                    uow.RepositoryFactory<R>().Update(entity);
                    uow.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Delete methods

        // Delete by ID 
        public static bool Delete(int id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
                {
                    uow.RepositoryFactory<R>().Delete(id);
                    uow.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        // Delete by entity
        public static bool Delete(T entity)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork(_connectionString, _pwd))
                {
                    uow.RepositoryFactory<R>().Delete(entity);
                    uow.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

       
    }
}