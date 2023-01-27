using CheckboxChallenge.Models;

namespace CheckboxChallenge.Services
{
    public interface IOperatorService
    {
        Operation Operation { get; }
        decimal Operate(Operand first, Operand second);
    }
}
