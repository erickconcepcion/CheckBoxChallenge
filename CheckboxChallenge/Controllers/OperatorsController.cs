using CheckboxChallenge.Domains;
using CheckboxChallenge.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckboxChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly IOperationDomain _operationDomain;

        public OperatorsController(IOperationDomain operationDomain)
        {
            _operationDomain = operationDomain;
        }
        [HttpGet]
        public IEnumerable<Operation> Get()
        {
            return _operationDomain.AvailableOperations();
        }

        
    }
}
