using MS.AFORO255.Cross.RabbitMQ.Src.Commands;
using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Commands
{
    public class TransactionCommand : Command
    {
        public int Id_Transaction { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
