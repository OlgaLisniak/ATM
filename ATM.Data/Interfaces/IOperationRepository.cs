using ATM.Data.Models;
using System;
using System.Collections.Generic;

namespace ATM.Data.Interfaces
{
    public interface IOperationRepository : IDisposable
    {
        IEnumerable<Operation> GetAll();
        void AddRecordToOperationResult(int cardId, int operationId, DateTime date);
        void AddRecordToOperationResult(int cardId, int operationId, int withdrawnAmount, DateTime date);
    }
}
