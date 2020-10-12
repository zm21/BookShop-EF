using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class BookRepository : IRepository<Book>
    {
        private BookShopModel context;
        public BookRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(Book entity)
        {
            context.Books.Add(entity);
        }

        public void Delete(Book entity)
        {
            var book = context.Books.Find(entity.Id);
            if (book != null)
                context.Books.Remove(book);
        }

        public void Edit(Book entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Book> Get(Predicate<Book> predicate)
        {
            return context.Books.Where(a => predicate(a)).ToList();
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return context.Books.Find(id);
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
