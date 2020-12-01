using AFORO255.MS.TEST.Invoice.Repository;
using System.Collections.Generic;

namespace AFORO255.MS.TEST.Invoice.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public IEnumerable<Model.Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }
    }
}
