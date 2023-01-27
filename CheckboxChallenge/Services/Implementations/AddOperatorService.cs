using CheckboxChallenge.Models;

namespace CheckboxChallenge.Services.Implementations
{
    public class AddOperatorService : IOperatorService
    {
        public Operation Operation => new Operation
        {
            Operator = "+",
            OperatorName = "Plus"
        };

        public decimal Operate(Operand first, Operand second) => first.Parameter + second.Parameter;
    }
}
