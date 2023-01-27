using CheckboxChallenge.Models;

namespace CheckboxChallenge.Domains
{
    public interface IOperationDomain
    {
        IEnumerable<Operation> AvailableOperations();
        OperationResult GetOperationResults(IEnumerable<Operand> operands);
    }
}
