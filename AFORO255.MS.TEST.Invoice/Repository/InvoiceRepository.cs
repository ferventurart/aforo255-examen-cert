﻿using AFORO255.MS.TEST.Invoice.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.MS.TEST.Invoice.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public InvoiceRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public IEnumerable<Model.Invoice> GetAll()
        {
            return _contextDatabase.Invoice.AsNoTracking().ToList();
        }

        public Model.Invoice GetById(int id)
        {
            return _contextDatabase.Invoice.AsNoTracking().Where(x => x.Id_Invoice.Equals(id)).FirstOrDefault();
        }

        public Model.Invoice Pay(Model.Invoice invoice)
        {
            _contextDatabase.Invoice.Update(invoice);
            _contextDatabase.SaveChanges();
            return invoice;
        }
    }
}
