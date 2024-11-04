using Dapper;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static Dapper.SqlMapper;

namespace DataAccessLayer
{
    public class RepositoryDapper<T>: IRepository<T> 
        where T : class, IDomainObject, new()
    {
        static string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MobiBobi\Desktop\Bobi\3semestr\Practics-1\DataAccessLayer\Database1.mdf;Integrated Security=True";

        public void Create(T obj)
        {
            var sqlQuery = "INSERT INTO Students (Name, [Group], Speciality) VALUES(@Name, @Group, @Speciality);";
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();
                db.Execute(sqlQuery, obj);
            }
        }
        
        public IEnumerable<T> ReadAll()
        {
            var sqlQuery = "SELECT * FROM Students";
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<T>(sqlQuery).ToList();
            }
        }
        public T Read(int id)
        {

            var sqlQuery = "SELECT * FROM Students WHERE Id = @Id";

            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<T>(sqlQuery, new { id }).FirstOrDefault();
            }
        }

        public void Update(T obj)
        {
            var sqlQuery = "UPDATE Students SET Name = @Name, [Group] = @Group, Speciality = @Speciality WHERE Id = @Id";
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute(sqlQuery, obj);
            }
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Students WHERE Id = @Id";

            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute(sqlQuery, new { id });
            }

        }
    }
}
