using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyDoc.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Get all entities in this dataset.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Get a single entity by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(Guid id);
        /// <summary>
        /// Creates new entity and returns it's Id once created.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Guid Add(TEntity entity);
        /// <summary>
        /// Finds the existing entity and then updates it with new values.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
    }
}
