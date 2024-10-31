using BookingApp.Data.Context;
using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly BookingAppDbContext _context;

        private readonly DbSet<TEntity> _entities;
        public Repository(BookingAppDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
    
        public void Add(TEntity entity)
        {
            entity.CreatedDate= DateTime.Now;
            _entities.Add(entity);
            //_db.SaveChanges();
            
        }

        public void Delete(TEntity entity)
        {
            entity.ModifiedDate= DateTime.Now;
            entity.IsDeleted= true;
            _entities.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _entities.Find(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is null ? _entities: _entities.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _entities.Update(entity);
            //_db.SaveChanges();
        }
    }
}
// _db.SaveChanges()'lar transaction durumları göz onunda bulundurularak UnitOfWork denilen başka bir patter içerisinde yönetilecektir.