using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class SaleRepository : IRepository<Sale>
    {
        private BookShopModel context;
        public SaleRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(Sale entity)
        {
            context.Sales.Add(entity);
        }

        public void Delete(Sale entity)
        {
            var sale = context.Sales.Find(entity.Id);
            if (sale != null)
                context.Sales.Remove(sale);
        }

        public void Edit(Sale entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Sale> Get(Predicate<Sale> predicate)
        {
            return context.Sales.Where(a => predicate(a)).ToList();
        }

        public IEnumerable<Sale> GetAll()
        {
            return context.Sales.ToList();
        }

        public Sale GetById(int id)
        {
            return context.Sales.Find(id);
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
