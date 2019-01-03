using ATM.Business.DTO;
using System.Collections.Generic;

namespace ATM.Business.Interfaces
{
    public interface IOperationService
    {
        IEnumerable<OperationDTO> GetAll();
        void AddRecordToOperationResult(OperationResultBalance resultBalance);
        void AddRecordToOperationResult(OperationResultCashWithdrawal resultCashWithdrawal);
    }
}
