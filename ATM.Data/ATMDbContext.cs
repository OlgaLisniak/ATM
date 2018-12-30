using ATM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Data
{
    public class ATMDbContext : DbContext 
    {
        public ATMDbContext() : base("ATMDb")
        {}

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationResult> OperationResults { get; set; }


    }
}
