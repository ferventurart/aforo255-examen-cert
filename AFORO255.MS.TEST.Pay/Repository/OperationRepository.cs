using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.MS.TEST.Pay.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public OperationRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public Operation Pay(Operation operation)
        {
            _contextDatabase.Operation.Add(operation);
            _contextDatabase.SaveChanges();
            return operation;
        }
    }
}
