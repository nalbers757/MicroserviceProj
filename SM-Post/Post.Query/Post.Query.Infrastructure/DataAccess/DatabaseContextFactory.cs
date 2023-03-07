using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Post.Query.Infrastructure.DataAccess
{
    public class DatabaseContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDBContext;

        public DatabaseContextFactory (Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDBContext = configureDbContext;
        }

        public DatabaseContext CreateDbContext()
        {
            DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new();
            _configureDBContext(optionsBuilder);

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}