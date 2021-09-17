using Homework5.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.Tests.DAL
{
    public class SqliteApplicationDbContextTest : ApplicationDbContextTestBase
    {
        public SqliteApplicationDbContextTest()
            : base(
                 new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseSqlite("Filename=Test.db")
                 .Options)
        {

        }
    }
}
