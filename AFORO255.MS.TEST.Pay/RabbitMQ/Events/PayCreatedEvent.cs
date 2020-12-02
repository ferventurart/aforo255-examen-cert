using MS.AFORO255.Cross.RabbitMQ.Src.Events;
using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Events
{
    public class PayCreatedEvent : Event
    {
        public PayCreatedEvent(int idOperation, int idInvoice, decimal amount, DateTime date)
        {
            Id_Operation = idOperation;
            Id_Invoice = idInvoice;
            Amount = amount;
            Date = date;
        }

        public int Id_Operation { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
