using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Interfaces.Services;
using SistemaBancario.Domain.Models;

namespace SistemaBancario.Domain.Services
{
    public class BaseService<T> : IService<T> where T : BaseModel
    {
        private readonly IRepository<T> _baseRepository;

        public BaseService(IRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        private bool disposedValue;

        public async Task<T> GetAsync(Guid id)
        {
            var item = await _baseRepository.SelectAsync(id);
            return item;
        }
        public async Task<IList<T>> GetAllAsync()
        {
            return await _baseRepository.SelectAllAsync();
        }
        public async Task<bool> CreateAsync(T model)
        {
            await _baseRepository.InsertAsync(model);
            var result = await _baseRepository.SaveChangesAsync();
            return result;
        }
        public async Task<bool> RemoveAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
            var result = await _baseRepository.SaveChangesAsync();

            return result;
        }
        public async Task<bool> UpdateAsync(T model)
        {
            await _baseRepository.UpdateAsync(model);
            var result = await _baseRepository.SaveChangesAsync();

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BaseService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
