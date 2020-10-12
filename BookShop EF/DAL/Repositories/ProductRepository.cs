using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ProductRepository : IRepository<Product>
    {
        private BookShopModel context;
        public ProductRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(Product entity)
        {
            context.Products.Add(entity);
        }

        public void Delete(Product entity)
        {
            var product = context.Products.Find(entity.BookId);
            if (product != null)
                context.Products.Remove(product);
        }

        public void Edit(Product entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Product> Get(Predicate<Product> predicate)
        {
            return context.Products.Where(a => predicate(a)).ToList();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
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
