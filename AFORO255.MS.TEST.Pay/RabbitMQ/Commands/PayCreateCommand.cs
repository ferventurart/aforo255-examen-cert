using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Commands
{
    public class PayCreateCommand : PayCommand
    {
        public PayCreateCommand(int idOperation, int idInvoice, decimal amount, DateTime date)
        {
            Id_Operation = idOperation;
            Id_Invoice = idInvoice;
            Amount = amount;
            Date = date;
        }
    }
}
