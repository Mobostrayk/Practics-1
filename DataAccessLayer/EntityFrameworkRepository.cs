using System;
using System.Collections.Generic;
using System.Data.Entity;
using Model;


namespace DataAccessLayer
{
    public class EntityFrameworkRepository<T>: 
        IRepository<T> where T : class, IDomainObject, new()
    {
        public Context _context;

        public EntityFrameworkRepository() 
        {  
            _context = new Context();
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>();
        }
        public T Read(int id)
        {
           return _context.Set<T>().Find(id);
        }
        public void Create(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }
        public void Update(T obj)
        {
            // Прикрепляем сущность к контексту
            //_context.Set<T>().Attach(obj);

            // Обновляем состояние сущности
            _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var item = _context.Set<T>().Find(id);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
            }
        }
        
    }
}
