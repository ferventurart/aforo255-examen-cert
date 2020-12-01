using AFORO255.MS.TEST.Pay.Model;
using System.Collections.Generic;

namespace AFORO255.MS.TEST.Pay.Repository
{
    public interface IOperationRepository
    {
        Operation Pay(Operation operation);
    }
}
