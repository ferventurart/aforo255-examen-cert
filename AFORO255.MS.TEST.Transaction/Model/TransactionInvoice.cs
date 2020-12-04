using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AFORO255.MS.TEST.Transaction.Model
{
    public class TransactionInvoice
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int Id_Operation { get; set; }
        public int Id_Invoice { get; set; }
        public decimal Amount { get; set; }
        public BsonDateTime Date { get; set; }
    }
}
