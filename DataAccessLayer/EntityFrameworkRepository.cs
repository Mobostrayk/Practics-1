using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<T> GetBookList()
        {
            return _context.Set<T>();
        }
        public T GetBook(int id)
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
            _context.Set<T>().Attach(obj);

            // Обновляем состояние сущности
            _context.Entry(obj).State = EntityState.Modified;

            _context.SaveChanges();
        }
        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }
        public void Save() 
        { 
            _context.SaveChanges();
        }

        
    }
}
