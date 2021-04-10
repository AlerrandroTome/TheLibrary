using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TheLibrary.Core.Entities;
using TheLibrary.Infrastructure.Repository;

namespace TheLibrary.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected Dictionary<Type, object> handlers;

        public IRepository<T> Repository<T>(DbContext context) where T : EntityBase
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
