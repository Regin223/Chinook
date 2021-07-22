using System.Collections.Generic;

namespace Chinook.Repositories
{
    /// <summary>
    /// Generic interface <c>IRepository</c> with methods to add, edit, and get.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        bool Add(T entity);

        bool Edit(T entity);

    }
}
