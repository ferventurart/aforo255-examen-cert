using System.Collections.Generic;

namespace AFORO255.MS.TEST.Invoice.Service
{
    public interface IInvoiceService
    {
        IEnumerable<Model.Invoice> GetAll();
    }
}
