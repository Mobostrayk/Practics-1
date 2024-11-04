using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// IRepository с CRUD операциями
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Операция вывода всего списка элементов
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ReadAll();
        /// <summary>
        /// Операция поиска одного элемента по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Read(int id);
        /// <summary>
        /// Операция добавление элемента в бд
        /// </summary>
        /// <param name="entity"></param>
        void Create(T item);
        /// <summary>
        /// Операция обновления элемента в бд
        /// </summary>
        /// <param name="entity"></param>
        void Update(T item);
        /// <summary>
        /// Операция удаления элемента в бд
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

    }
}
