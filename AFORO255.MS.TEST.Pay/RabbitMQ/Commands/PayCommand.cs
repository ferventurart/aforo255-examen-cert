using MS.AFORO255.Cross.RabbitMQ.Src.Commands;
using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Commands
{
    public class PayCommand : Command
    {
        public int Id_Operation { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
