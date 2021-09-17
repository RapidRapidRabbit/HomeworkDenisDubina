using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DAL.Entities
{
    public class Bank
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public List<Client> Clients { get; set; }
       
    }
}
