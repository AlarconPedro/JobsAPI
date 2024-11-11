using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Core.Interfaces;

public interface IGenericService<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
    //Task Delete(T entity);
}
