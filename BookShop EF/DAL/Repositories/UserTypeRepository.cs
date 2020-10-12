using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class UserTypeRepository : IRepository<UserType>
    {
        private BookShopModel context;
        public UserTypeRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(UserType entity)
        {
            context.UserTypes.Add(entity);
        }

        public void Delete(UserType entity)
        {
            var usertypes = context.UserTypes.Find(entity.Id);
            if (usertypes != null)
                context.UserTypes.Remove(usertypes);
        }

        public void Edit(UserType entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<UserType> Get(Predicate<UserType> predicate)
        {
            return context.UserTypes.Where(a => predicate(a)).ToList();
        }

        public IEnumerable<UserType> GetAll()
        {
            return context.UserTypes.ToList();
        }

        public UserType GetById(int id)
        {
            return context.UserTypes.Find(id);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
