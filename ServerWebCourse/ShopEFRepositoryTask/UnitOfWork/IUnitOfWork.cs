﻿using System;

namespace ShopEFRepositoryTask
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        T GetRepository<T>() where T : class, IRepository;
    }
}
