using System.Collections.Generic;

namespace AFORO255.MS.TEST.Invoice.Repository
{
    public interface IInvoiceRepository
    {
        IEnumerable<Model.Invoice> GetAll();
    }
}
