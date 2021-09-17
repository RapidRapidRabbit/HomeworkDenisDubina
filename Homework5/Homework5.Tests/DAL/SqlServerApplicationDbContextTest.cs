using Homework5.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.Tests.DAL
{
    public class SqlServerApplicationDbContextTest : ApplicationDbContextTestBase
    {
        public SqlServerApplicationDbContextTest()
            : base(
                 new DbContextOptionsBuilder<ApplicationDbContext>()                 
                 .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True") //.UseSqlite("Filename=Test.db")
                 .Options)
        {

        }
    }
}
