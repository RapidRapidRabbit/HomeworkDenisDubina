using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Bank Bank { get; set; }
    }
}
