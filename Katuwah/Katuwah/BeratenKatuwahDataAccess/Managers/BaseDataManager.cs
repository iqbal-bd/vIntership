using BeratenKatuwahDataAccess.DbModel;
using BeratenKatuwahDomain.Employee;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BeratenKatuwahDataAccess
{
    public abstract class BaseDataManager
    {
        protected EmployeeDbContext dbModel;


        public BaseDataManager(EmployeeDbContext model)
        {
            dbModel = model;
        }


        #region APIs

        protected T FindEntity<T>(int primaryKey) where T : class
        {
            try
            {
                return dbModel.Set<T>().Find(primaryKey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected T GetEntityFirstRowData<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return dbModel.Set<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected T GetEntityLastRowData<T>(Func<T, bool> predicate) where T : class
        {
            try
            {
                return dbModel.Set<T>().LastOrDefault(predicate);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected bool GetEntityAny<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return dbModel.Set<T>().Where(predicate).Any();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected IList<T> GetEntityListData<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return dbModel.Set<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected IList<T> GetEntityListData<T>() where T : class
        {
            try
            {
                return dbModel.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected T GetRowData<T>(string interpolatedStoredProc) where T : class
        {
            try
            {
                return dbModel.Set<T>().FromSqlRaw(interpolatedStoredProc).AsEnumerable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected IList<T> GetLookupCollection<T>() where T : class
        {
            try
            {
                return dbModel.Set<T>().AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected IList<T> GetListData<T>(string interpolatedStoredProc) where T : class
        {
            try
            {
                return dbModel.Set<T>().FromSqlRaw(interpolatedStoredProc).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                throw;
            }
        }

        protected async Task<bool> ExecuteSqlAsync(string interpolatedStoredProc)
        {
            try
            {
                await dbModel.Database.ExecuteSqlRawAsync(interpolatedStoredProc);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected bool MarkedForDelete(string interpolatedStoredProc)
        {
            try
            {
                dbModel.Database.ExecuteSqlRaw(interpolatedStoredProc);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected bool RemoveEntity<T>(int id) where T : class
        {
            try
            {
                var entity = dbModel.Set<T>().Find(id);
                dbModel.Remove<T>(entity);
                dbModel.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected async Task<bool> AddUpdateEntityAsync<T>(T entity, bool keepDettached = true) where T : class
        {
            try
            {
                if (dbModel.Entry<T>(entity).IsKeySet)
                    dbModel.Update<T>(entity);
                else
                    dbModel.Add<T>(entity);

                await dbModel.SaveChangesAsync();

                if (keepDettached)
                {
                    dbModel.Entry<T>(entity).State = EntityState.Detached;
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected bool AddUpdateEntity<T>(T entity, bool keepDettached = true) where T : class
        {
            try
            {
                if (dbModel.Entry<T>(entity).IsKeySet)
                    dbModel.Update<T>(entity);
                else
                    dbModel.Add<T>(entity);

                dbModel.SaveChanges();

                if (keepDettached)
                {
                    dbModel.Entry<T>(entity).State = EntityState.Detached;
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString()); 
                throw;
            }
        }
        #endregion
    }

}
