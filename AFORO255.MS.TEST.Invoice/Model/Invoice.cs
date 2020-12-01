using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.Model
{
    [Table("invoice")]
    public class Invoice
    {
        [Key]
        [Column("id_invoice")]
        public int Id_Invoice { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("state")]
        public int State { get; set; }
    }
}
