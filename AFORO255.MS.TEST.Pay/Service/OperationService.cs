using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.Repository;

namespace AFORO255.MS.TEST.Pay.Service
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public Operation Pay(Operation operation)
        {
            return _operationRepository.Pay(operation);
        }
    }
}
