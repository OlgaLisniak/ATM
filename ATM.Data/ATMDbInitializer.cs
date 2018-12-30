using ATM.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ATM.Data
{
    public class ATMDbInitializer : DropCreateDatabaseAlways<ATMDbContext>
    {
        protected override void Seed(ATMDbContext context)
        {
            var creditCards = new List<CreditCard>()
            {
                new CreditCard{CardId = 1, Number = "1111111111111111", Balance = 500, IsActive = true, PINCode = "1234"},
                new CreditCard{CardId = 2, Number = "2222-2222-2222-2222", Balance = 1000, IsActive = false, PINCode = "0000"},
                new CreditCard{CardId = 2, Number = "3333-3333-3333-3333", Balance = 10, IsActive = true, PINCode = "1111"},
            };

            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();
        }
    }
}
