using System;
using System.Collections.Generic;
using System.Text;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService:ITransferService
    {
        private ITransferLogRepository _transferLogRepository;
        private IEventBus _bus;

        public TransferService(ITransferLogRepository transferLogRepository, IEventBus bus)
        {
            _transferLogRepository = transferLogRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferLogRepository.GetTransferLogs();
        }      
    }
}
