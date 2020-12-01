using AFORO255.MS.TEST.Pay.DTO;
using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
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

            return Ok(pay);
        }
    }
}
