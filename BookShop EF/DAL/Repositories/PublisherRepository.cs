using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class PublisherRepository : IRepository<Publisher>
    {
        private BookShopModel context;
        public PublisherRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(Publisher entity)
        {
            context.Publishers.Add(entity);
        }

        public void Delete(Publisher entity)
        {
            var publisher = context.Publishers.Find(entity.Id);
            if (publisher != null)
                context.Publishers.Remove(publisher);
        }

        public void Edit(Publisher entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Publisher> Get(Predicate<Publisher> predicate)
        {
            return context.Publishers.Where(a => predicate(a)).ToList();
        }

        public IEnumerable<Publisher> GetAll()
        {
            return context.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return context.Publishers.Find(id);
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
