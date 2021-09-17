using Homework5.DAL.EF;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.Tests.DAL
{
    class SqliteInMemoryApplicationDbContextTest : ApplicationDbContextTestBase
    {
        private readonly DbConnection connection;


        public SqliteInMemoryApplicationDbContextTest()
            : base(
                 new DbContextOptionsBuilder<ApplicationDbContext>()                 
                 .UseSqlite(CreateInMemoryDatabase())
                 .Options)
        {
            connection = RelationalOptionsExtension.Extract(DbContextOptions).Connection;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
