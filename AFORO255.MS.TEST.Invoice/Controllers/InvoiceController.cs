﻿using AFORO255.MS.TEST.Invoice.Service;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_invoiceService.GetAll());
        }
    }
}
