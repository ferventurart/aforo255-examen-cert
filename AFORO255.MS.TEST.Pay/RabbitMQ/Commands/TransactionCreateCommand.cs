using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Commands
{
    public class TransactionCreateCommand : TransactionCommand
    {
        public TransactionCreateCommand(int idTransaction, int idInvoice, decimal amount, DateTime date)
        {
            Id_Transaction = idTransaction;
            Id_Invoice = idInvoice;
            Amount = amount;
            Date = date;
        }
    }
}
