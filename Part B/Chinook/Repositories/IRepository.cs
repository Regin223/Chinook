using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Models;

namespace Chinook.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        bool Add(T entity);

        bool Edit(T entity);

    }
}
