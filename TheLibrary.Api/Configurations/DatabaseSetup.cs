﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheLibrary.Infrastructure.Data.Context;

namespace TheLibrary.Api.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
