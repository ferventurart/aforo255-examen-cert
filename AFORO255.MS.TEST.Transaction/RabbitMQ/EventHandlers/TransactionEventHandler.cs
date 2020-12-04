using AFORO255.MS.TEST.Transaction.Model;
using AFORO255.MS.TEST.Transaction.RabbitMQ.Events;
using AFORO255.MS.TEST.Transaction.Service;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.RabbitMQ.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly ITransactionService _transactionService;

        public TransactionEventHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public Task Handle(TransactionCreatedEvent @event)
        {
            _transactionService.Add(new TransactionInvoice() {
                Id_Transaccion = @event.Id_Transaction,
                Id_Invoice = @event.Id_Invoice,
                Amount = @event.Amount,
                Date = @event.Date
            });

            return Task.CompletedTask;
        }
    }
}
