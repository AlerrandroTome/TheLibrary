using System;
using System.Collections.Generic;
using TheLibrary.Core.Entities;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.Repository;

namespace TheLibrary.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected Dictionary<Type, object> handlers;
        private readonly LibraryContext context;

        public UnitOfWork(LibraryContext context)
        {
            this.context = context;
        }

        public IRepository<T> Repository<T>() where T : EntityBase
        {
            var type = typeof(T);

            if (handlers == null)
            {
                handlers = new Dictionary<Type, object>();
            }

            if (handlers.ContainsKey(type) == false)
            {
                handlers.Add(type, new Repository<T>(context));
            }

            return (IRepository<T>)handlers[type];
        }
    }
}
