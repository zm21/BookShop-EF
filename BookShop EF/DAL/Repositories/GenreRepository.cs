using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class GenreRepository : IRepository<Genre>
    {
        private BookShopModel context;
        public GenreRepository(BookShopModel context)
        {
            this.context = context;
        }
        public void Create(Genre entity)
        {
            context.Genres.Add(entity);
        }

        public void Delete(Genre entity)
        {
            var genre = context.Genres.Find(entity.Id);
            if (genre != null)
                context.Genres.Remove(genre);
        }

        public void Edit(Genre entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Genre> Get(Predicate<Genre> predicate)
        {
            return context.Genres.Where(a => predicate(a)).ToList();
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return context.Genres.Find(id);
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
