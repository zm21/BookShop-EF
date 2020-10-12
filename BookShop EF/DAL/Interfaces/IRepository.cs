using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> Get(Predicate<TEntity> predicate);
        IEnumerable<TEntity> GetAll();
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        void Create(TEntity entity);
        void Save();
    }
}
