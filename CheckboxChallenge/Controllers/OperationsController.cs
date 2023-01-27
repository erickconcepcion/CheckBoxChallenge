using CheckboxChallenge.Domains;
using CheckboxChallenge.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckboxChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationDomain _operationDomain;

        public OperationsController(IOperationDomain operationDomain)
        {
            _operationDomain = operationDomain;
        }
        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<Operand> operands)
        {
            var result = _operationDomain.GetOperationResults(operands);
            if (result?.Errors?.Any() ?? false)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
