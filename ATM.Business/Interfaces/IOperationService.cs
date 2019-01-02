using ATM.Business.DTO;
using System.Collections.Generic;

namespace ATM.Business.Interfaces
{
    public interface IOperationService
    {
        IEnumerable<OperationDTO> GetAll();
    }
}
