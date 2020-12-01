using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Pay.Model
{
    public class Operation
    {
        [Key]
        public int Id_Operation { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
