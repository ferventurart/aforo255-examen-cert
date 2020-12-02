using AFORO255.MS.TEST.Invoice.Model;
using AFORO255.MS.TEST.Invoice.RabbitMQ.Events;
using AFORO255.MS.TEST.Invoice.Service;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoice.RabbitMQ.EventHandlers
{
    public class PayEventHandler : IEventHandler<PayCreatedEvent>
    {
        private readonly IInvoiceService _invoiceService;

        public PayEventHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public Task Handle(PayCreatedEvent @event)
        {
            var invoice = _invoiceService.GetById(@event.Id_Invoice);
            if (invoice != null && invoice.State.Equals((int) StateInvoice.Pendiente))
            {
                if (@event.Amount >= invoice.Amount)
                    invoice.State = (int)StateInvoice.Pagada;
                else
                    invoice.State = (int)StateInvoice.Pendiente;

                _invoiceService.Pay(invoice);
            }
            return Task.CompletedTask;
        }
    }
}
