using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutomaticEntity
{
    /// <summary>
    /// The class contains the following context operations: Add, Retrieve, Remove, and Update
    /// </summary>
    public class DbOperation
    {
        private InternalContext dbContext;

        /// <summary>
        /// Initialize the Context operation
        /// </summary>
        /// <param name="connString"></param>
        public DbOperation(string connString)
        {
            dbContext = new InternalContext(connString);
            dbContext.Database.EnsureCreated();
        }

        #region Add Entity
        /// <summary>
        /// Add and Save a new entity
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="entity">Object to add</typeparam>
        public void AddEntity<T>(T entity)
        {
            dbContext.EnsureEntityExists(typeof(T));
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Add and Save a new entity async
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="entity">Object to add</typeparam>
        public async Task AddEntityAsync<T>(T entity)
        {
            dbContext.EnsureEntityExists(typeof(T));
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        #endregion

        #region Update entity
        /// <summary>
        /// Update and Save existing entity
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="entity">Object to add</typeparam>
        public void UpdateEntity<T>(T entity)
        {
            dbContext.EnsureEntityExists(typeof(T));
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Update and Save existing entity async
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="entity">Object to add</typeparam>
        public async Task UpdateEntityAsync<T>(T entity)
        {
            dbContext.EnsureEntityExists(typeof(T));
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }
        #endregion

        #region Get Entity
        /// <summary>
        /// Retrieve the entity with given primary key
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="key">primary key to retrieve</param>
        /// <returns>return the entity found</returns>
        public T GetEntity<T>(object key) where T : class
        {
            dbContext.EnsureEntityExists(typeof(T));
            T entity = dbContext.Find<T>(key);
            return entity;
        }

        /// <summary>
        /// Retrieve the entity with given primary key async
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="key">primary key to retrieve</param>
        /// <returns>return the entity found</returns>
        public async Task<T> GetEntityAsync<T>(object key) where T : class
        {
            dbContext.EnsureEntityExists(typeof(T));
            T entity = await dbContext.FindAsync<T>(key);
            return entity;
        }
        #endregion


        #region Get Entities

        /// <summary>
        /// Retrieve list of entities, either all entities or filtered one
        /// </summary>
        /// <typeparam name="T"> entity type</typeparam>
        /// <param name="filter">optional query filter </param>
        /// <returns>returns list of entities</returns>
        public async Task<List<T>> GetEntitiesAsync<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            dbContext.EnsureEntityExists(typeof(T));
            
            if (filter == null)
                return await dbContext.Set<T>().ToListAsync();
            else
                return await dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public List<T> GetEntities<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            dbContext.EnsureEntityExists(typeof(T));

            if (filter == null)
                return dbContext.Set<T>().ToList();
            else
                return dbContext.Set<T>().Where(filter).ToList();
        }
        #endregion

    }
}
