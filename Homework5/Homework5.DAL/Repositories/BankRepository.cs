using Homework5.DAL.EF;
using Homework5.DAL.Entities;
using Homework5.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DAL.Repositories
{
    public class BankRepository:BaseRepository<Bank>,IBankRepository
    {
        public BankRepository(ApplicationDbContext context) : base(context)
        {

        }

        public void Update(int id, string name = null)
        {
            Bank bank = context.Banks.Find(id);

            if (!String.IsNullOrEmpty(name))
                bank.Name = name;
        }
    }
}
