using AFORO255.MS.TEST.Transaction.Model;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public interface ITransactionRepository
    {
        IMongoCollection<TransactionInvoice> Transaction { get; }
    }
}
