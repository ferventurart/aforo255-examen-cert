using System;

namespace AFORO255.MS.TEST.Transaction.DTO
{
    public class TransactionResponse
    {
        public int Id_Operation { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
