using AFORO255.MS.TEST.Transaction.DTO;
using AFORO255.MS.TEST.Transaction.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionResponse>> GetAll();

        Task<bool> Add(TransactionInvoice transactionInvoice);
    }
}
