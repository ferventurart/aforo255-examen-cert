using AFORO255.MS.TEST.Pay.DTO;
using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.RabbitMQ.Commands;
using AFORO255.MS.TEST.Pay.Service;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        private readonly IEventBus _bus;

        public OperationController(IOperationService operationService, IEventBus bus)
        {
            _operationService = operationService;
            _bus = bus;
        }


        [HttpPost("Pay")]
        public IActionResult Pay([FromBody] PayRequest request)
        {
            Operation pay = new Operation()
            {
                Id_Invoice = request.Id_Invoice,
                Amount = request.Amount,
                Date = DateTime.Now
            };

            pay = _operationService.Pay(pay);

            var payCommand = new PayCreateCommand(
                idOperation: pay.Id_Operation,
                idInvoice: pay.Id_Invoice,
                amount: pay.Amount,
                date: pay.Date
           );

            _bus.SendCommand(payCommand);

            return Ok();
        }
    }
}
