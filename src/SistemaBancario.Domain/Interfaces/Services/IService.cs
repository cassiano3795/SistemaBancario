using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Interfaces.Services
{
    public interface IService<T> : IDisposable where T : BaseModel
    {
         Task<T> GetAsync(Guid id);
         Task<IList<T>> GetAllAsync();

         Task<T> Create(T model);
         Task<T> Update(T model);
         Task<T> Remove(Guid id);
    }
}
