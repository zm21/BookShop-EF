using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ReservRepository : IRepository<Reserv>
    {
        private BookShopModel context;
        public ReservRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(Reserv entity)
        {
            context.Reservs.Add(entity);
        }

        public void Delete(Reserv entity)
        {
            var reserv = context.Reservs.Find(entity.Id);
            if (reserv != null)
                context.Reservs.Remove(reserv);
        }

        public void Edit(Reserv entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Reserv> Get(Predicate<Reserv> predicate)
        {
            return context.Reservs.Where(a => predicate(a)).ToList();
        }

        public IEnumerable<Reserv> GetAll()
        {
            return context.Reservs.ToList();
        }

        public Reserv GetById(int id)
        {
            return context.Reservs.Find(id);
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
