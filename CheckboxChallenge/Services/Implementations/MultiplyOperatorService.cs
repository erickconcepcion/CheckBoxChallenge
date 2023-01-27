using CheckboxChallenge.Models;

namespace CheckboxChallenge.Services.Implementations
{
    public class MultiplyOperatorService : IOperatorService
    {
        public Operation Operation => new Operation
        {
            Operator = "*",
            OperatorName = "Multiply"
        };

        public decimal Operate(Operand first, Operand second) => first.Parameter * second.Parameter;
    }
}
