using Homework5.DAL.EF;
using Homework5.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Homework5.Tests.DAL
{
    public abstract class ApplicationDbContextTestBase
    {
        protected DbContextOptions<ApplicationDbContext> Options { get; }

        protected ApplicationDbContextTestBase(DbContextOptions<ApplicationDbContext> options)
        {
            Options = options;
            Seed();
        }

        private void Seed()
        {
            using (var context = new ApplicationDbContext(Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Bank bank = new Bank { Name = "AnyBank" };
                Client client = new Client { FirstName = "Denis", LastName = "Dubina", Bank = bank };

                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        [Fact]
        public void CanGetData()
        {
            using (var context = new ApplicationDbContext(Options))
            {
                var client = context.Clients.Include(x => x.Bank).First();

                Assert.NotNull(client);
                Assert.NotNull(client.Bank);
            }
        }

        [Fact]
        public void CanDeleteData()
        {
            using (var context = new ApplicationDbContext(Options))
            {
                Client client = context.Clients.Include(x => x.Bank).First();

                context.Clients.Remove(client);
                context.SaveChanges();

                Client deletedClient = context.Clients.Include(x => x.Bank).FirstOrDefault();

                Assert.Null(deletedClient);
            }
        }

        [Fact]
        public void CanUpdateData()
        {
            using (var context = new ApplicationDbContext(Options))
            {
                Client client = context.Clients.Include(x => x.Bank).First();

                client.FirstName = "AnyName";
                client.LastName = "AnyName";
                client.Bank.Name = "AnyBankName";

                context.Clients.Update(client);
                context.SaveChanges();

                Client updatedClient = context.Clients.Include(x => x.Bank).First();

                Assert.Equal("AnyName", updatedClient.FirstName);
                Assert.Equal("AnyName", updatedClient.LastName);
                Assert.Equal("AnyBankName", updatedClient.Bank.Name);
            }
        }
    }
}
