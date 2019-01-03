using ATM.Business.DTO;
using ATM.Business.Interfaces;
using ATM.Data.Interfaces;
using ATM.Data.Models;
using System.Collections.Generic;

namespace ATM.Business.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository operationRepository;
        private readonly IATMMapper mapper;

        public OperationService(IOperationRepository _operationRepository, IATMMapper _mapper)
        {
            operationRepository = _operationRepository;
            mapper = _mapper;
        }

        //gets all operations
        public IEnumerable<OperationDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Operation>, IEnumerable<OperationDTO>>(operationRepository.GetAll());
        }

        //add record about balance operation
        public void AddRecordToOperationResult(OperationResultBalance resultBalance)
        {
            operationRepository.AddRecordToOperationResult(resultBalance.CardId, resultBalance.OperationId, resultBalance.Date);
        }

        //add record about cash withdrawal operation
        public void AddRecordToOperationResult(OperationResultCashWithdrawal resultCashWithdrawal)
        {
            operationRepository.AddRecordToOperationResult(resultCashWithdrawal.CardId, resultCashWithdrawal.OperationId, resultCashWithdrawal.WithdrawnAmount, resultCashWithdrawal.Date);
        }
    }
}
