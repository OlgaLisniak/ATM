using ATM.Data.Models;
using System.Data.Entity;

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
