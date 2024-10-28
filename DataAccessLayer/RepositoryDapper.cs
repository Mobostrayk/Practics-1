using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RepositoryDapper<T>: IRepository<T> 
        where T : class, IDomainObject, new()
    {
        private bool disposed = false; // Флаг для проверки, был ли уже вызван метод Dispose
        static string connectionString = "data source =(localdb)" +
            "\\MSSQLLocalDB;Initial Catalog =DbConnection;Integrated Security=True";
        IDbConnection db = new SqlConnection(connectionString);

        public void Create(T obj)
        {
            var sqlQuery = "INSERT INTO Students (Name, [Group], Speciality) " +
                "VALUES(@Name, @Group, @Speciality); SELECT CAST(SCOPE_IDENTITY() as int)";
            int studentId = db.Query<int>(sqlQuery,obj).FirstOrDefault();
            obj.Id = studentId;
        }
        
        public IEnumerable<T> GetBookList()
        {
            return db.Query<T>("SELECT * FROM Students").ToList();
        }
        public T GetBook(int id)
        {
            var sqlQuery = "SELECT * FROM Students WHERE Id = @Id";
            return db.QuerySingleOrDefault<T>(sqlQuery, new { Id = id });
        }

        public void Update(T obj)
        {
            var query = "UPDATE Students SET Name = @Name, [Group] = @Group, Speciality = @Speciality WHERE Id = @Id";
            db.Execute(query, obj);
        }

        public void Delete(T obj)
        {
            var query = "DELETE FROM Students WHERE Id = @Id";
            db.Execute(query, new { Id = obj.Id });
        }

        public void Save()
        {
            
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Предотвращаем вызов финализатора
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    db?.Close();
                    db?.Dispose();
                }

                // Освобождаем неуправляемые ресурсы здесь (если есть)

                disposed = true; // Устанавливаем флаг
            }
        }

        ~RepositoryDapper()
        {
            Dispose(false); // Вызываем Dispose для финализатора
        }
    }
}
