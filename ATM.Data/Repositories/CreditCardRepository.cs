using ATM.Data.Interfaces;
using ATM.Data.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace ATM.Data.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly DbSet<CreditCard> db;
        private readonly ATMDbContext context;

        public CreditCardRepository(ATMDbContext _context)
        {
            context = _context;
            db = _context.Set<CreditCard>();
        }

        public int GetCardIdByNumber(string number)
        {
            var card = GetCreditCard(number);
            if (card != null)
            {
                return card.CardId;
            }
            return 0;
        }

        public CreditCard GetCreditCard(int id)
        {
            return db.FirstOrDefault(x => x.CardId == id);
        }

        public CreditCard GetCreditCard(string number)
        {
            return db.FirstOrDefault(c => c.Number == number);
        }

        public bool IsActive(int id)
        {
            return GetCreditCard(id).IsActive;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        
    }
}
