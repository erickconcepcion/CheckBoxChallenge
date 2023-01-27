using CheckboxChallenge.Models;

namespace CheckboxChallenge.Services.Implementations
{
    public class MinusOperatorService : IOperatorService
    {
        public Operation Operation => new Operation
        {
            Operator = "-",
            OperatorName = "Minus"
        };

        public decimal Operate(Operand first, Operand second) => first.Parameter - second.Parameter;
    }
}
