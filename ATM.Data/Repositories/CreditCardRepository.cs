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

        public int GetCreditCardIdByNumber(string number)
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
            var card = GetCreditCard(id);
            if(card != null)
            {
                return card.IsActive;
            }
            return false;
        }

        public string GetPINCode(int id)
        {
            var card = GetCreditCard(id);
            if (card != null)
            {
                return card.PINCode;
            }
            return null;
        }

        public void BlockCreditCard(int id)
        {
            var card = GetCreditCard(id);
            if (card != null)
            {
                card.IsActive = false;
                context.SaveChanges();
            }
        }

        public double GetBalance(int id)
        {
            var card = GetCreditCard(id);
            if (card != null)
            {
                return card.Balance;
            }
            return 0;
        }

        public void ChangeBalance(int id, int withdrawnAmount)
        {
            var card = GetCreditCard(id);
            if (card != null)
            {
                card.Balance-= withdrawnAmount;
                context.SaveChanges();
            }
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
