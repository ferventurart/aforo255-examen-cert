using MS.AFORO255.Cross.RabbitMQ.Src.Events;
using System;

namespace AFORO255.MS.TEST.Transaction.RabbitMQ.Events
{
    public class TransactionCreatedEvent : Event
    {
        public TransactionCreatedEvent(int idTransaction, int idInvoice, decimal amount, DateTime date)
        {
            Id_Transaction = idTransaction;
            Id_Invoice = idInvoice;
            Amount = amount;
            Date = date;
        }

        public int Id_Transaction { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
