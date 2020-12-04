using AFORO255.MS.TEST.Transaction.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> Get(int invoiceId)
        {
            var result = await _transactionService.GetAll();
            var model = result.Where(x => x.Id_Invoice == invoiceId).ToList();

            return Ok(model);
        }
    }
}
