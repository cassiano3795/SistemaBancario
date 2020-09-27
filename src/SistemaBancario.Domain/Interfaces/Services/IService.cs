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

         Task<bool> CreateAsync(T model);
         Task<bool> UpdateAsync(T model);
         Task<bool> RemoveAsync(Guid id);
    }
}
