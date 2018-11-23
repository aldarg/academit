using System;
using System.Data.Entity;

namespace ShopEFRepositoryTask.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _db;
        private bool _disposed;

        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _db.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public T GetRepository<T>() where T : class, IRepository
        {
            if (typeof(T) == typeof(IProductRepository))
            {
                return new ProductRepository(_db) as T;
            }

            if (typeof(T) == typeof(ICategoryRepository))
            {
                return new CategoryRepository(_db) as T;
            }

            if (typeof(T) == typeof(IOrderRepository))
            {
                return new OrderRepository(_db) as T;
            }

            if (typeof(T) == typeof(IOrderProductRepository))
            {
                return new OrderProductRepository(_db) as T;
            }

            if (typeof(T) == typeof(ICustomerRepository))
            {
                return new CustomerRepository(_db) as T;
            }

            throw new Exception($"Неизвестный тип сущности: {typeof(T)}");
        }
    }
}
