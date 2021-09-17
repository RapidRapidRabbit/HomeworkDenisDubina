using Homework5.DAL.EF;
using Homework5.DAL.Entities;
using Homework5.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DAL.Repositories
{
     public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository (ApplicationDbContext context) : base(context)
        {

        }

        public void Update(int id, string firstname = null, string lastname = null, Bank bank = null)
        {
            Client client = context.Clients.Find(id);

            if (!String.IsNullOrEmpty(firstname))
                client.FirstName = firstname;
            if (!String.IsNullOrEmpty(lastname))
                client.LastName = lastname;
            if (bank != null)
                client.Bank = bank;


            context.Clients.Update(client);
            context.SaveChanges();
        }
    }
}
