using ATM.Data.Interfaces;
using ATM.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ATM.Data.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly DbSet<Operation> db;
        private readonly ATMDbContext context;

        public OperationRepository(ATMDbContext _context)
        {
            context = _context;
            db = _context.Set<Operation>();
        }

        public IEnumerable<Operation> GetAll()
        {
            return db;
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
