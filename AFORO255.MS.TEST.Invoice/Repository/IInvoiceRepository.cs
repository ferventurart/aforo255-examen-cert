using System.Collections.Generic;

namespace AFORO255.MS.TEST.Invoice.Repository
{
    public interface IInvoiceRepository
    {
        IEnumerable<Model.Invoice> GetAll();
        Model.Invoice GetById(int id);
        Model.Invoice Pay(Model.Invoice invoice);
    }
}
