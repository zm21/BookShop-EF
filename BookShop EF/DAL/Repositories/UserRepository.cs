using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class UserRepository : IRepository<User>
    {
        private BookShopModel context;
        public UserRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(User entity)
        {
            context.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            var user = context.Users.Find(entity.Id);
            if (user != null)
                context.Users.Remove(user);
        }

        public void Edit(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<User> Get(Predicate<User> predicate)
        {
            return context.Users.Where(a => predicate(a));
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
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
