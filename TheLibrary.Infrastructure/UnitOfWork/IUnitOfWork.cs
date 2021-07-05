﻿using Microsoft.EntityFrameworkCore;
using TheLibrary.Core.Entities;
using TheLibrary.Infrastructure.Repository;

namespace TheLibrary.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : EntityBase;
    }
}
