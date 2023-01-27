using CheckboxChallenge.Models;

namespace CheckboxChallenge.Services.Implementations
{
    public class DivideOperatorService: IOperatorService
    {
        public Operation Operation => new Operation
        {
            Operator = "/",
            OperatorName = "Divide"
        };

        public decimal Operate(Operand first, Operand second) => first.Parameter / second.Parameter;
    }
}
