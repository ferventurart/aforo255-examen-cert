using AFORO255.MS.TEST.Transaction.DTO;
using AFORO255.MS.TEST.Transaction.Model;
using AFORO255.MS.TEST.Transaction.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<bool> Add(TransactionInvoice transactionInvoice)
        {
            await _transactionRepository.Transaction.InsertOneAsync(transactionInvoice);
            return true;
        }

        public async Task<IEnumerable<TransactionResponse>> GetAll()
        {
            var data = await _transactionRepository.Transaction.Find(_ => true).ToListAsync();
            var response = new List<TransactionResponse>();
            foreach (var item in data)
            {
                response.Add(new TransactionResponse()
                {
                    Id_Transaction = item.Id_Transaccion,
                    Id_Invoice = item.Id_Invoice,
                    Amount = item.Amount,
                    Date = (DateTime) item.Date
                });
            }
            return response;
        }
    }
}
