using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class AuthorRepository : IRepository<Author>
    {
        private BookShopModel context;
        public AuthorRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(Author entity)
        {
            context.Authors.Add(entity);
        }

        public void Delete(Author entity)
        {
            var author = context.Authors.Find(entity.Id);
            if (author != null)
                context.Authors.Remove(author);
        }

        public void Edit(Author entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Author> Get(Predicate<Author> predicate)
        {
            return context.Authors.Where(a => predicate(a)).ToList();
        }

        public IEnumerable<Author> GetAll()
        {
            return context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return context.Authors.Find(id);
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
