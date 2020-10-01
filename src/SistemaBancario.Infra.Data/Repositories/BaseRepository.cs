using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Interfaces.Repositories;
using SistemaBancario.Domain.Models;
using SistemaBancario.Infra.Data.Context;

namespace SistemaBancario.Infra.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private bool disposedValue;
        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<T> _set;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _set = appDbContext.Set<T>();
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var model = await _set.FindAsync(id);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IList<T>> SelectAllAsync()
        {
            try
            {
                var models = await _set.ToListAsync();
                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task InsertAsync(T model)
        {
            try
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedAt = model.CreatedAt == DateTime.MinValue ? DateTime.UtcNow : model.CreatedAt;

                await _set.AddAsync(model);
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateAsync(T model)
        {
            try
            {
                var modelDb = await SelectAsync(model.Id);
                // _set.Update(model);

                model.CreatedAt = modelDb.CreatedAt;
                model.UpdatedAt = DateTime.UtcNow;

                _appDbContext.Entry(modelDb).CurrentValues.SetValues(model);
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var modelDb = await SelectAsync(id);

                _set.Remove(modelDb);
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _appDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                return _appDbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        // ~BaseRepository()
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
