using ATM.Data.Models;
using System;
using System.Collections.Generic;

namespace ATM.Data.Interfaces
{
    public interface IOperationRepository : IDisposable
    {
        IEnumerable<Operation> GetAll();
    }
}
