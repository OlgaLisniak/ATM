﻿using ATM.Business.DTO;
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

        public IEnumerable<OperationDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Operation>, IEnumerable<OperationDTO>>(operationRepository.GetAll());
        }
    }
}
