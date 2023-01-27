using CheckboxChallenge.Models;
using CheckboxChallenge.Services;
using System.Linq;

namespace CheckboxChallenge.Domains.Implementations
{
    public class OperationDomain : IOperationDomain
    {
        private const string InvalidOperatorError = "One or more operators are invalid.";
        private const string MoreEqualsError = "Only one Equals is allowed.";
        private const string LastEqualError = "The last operator must be equals.";
        private new const string Equals = "=";

        private readonly IDictionary<string, IOperatorService> _operators;
        
        
        public OperationDomain(IServiceProvider serviceProvider)
        {
            _operators = serviceProvider.GetServices<IOperatorService>().ToDictionary(k=> k.Operation.Operator, v => v);
        }
        public IEnumerable<Operation> AvailableOperations()=> _operators.Values.Select(k => k.Operation);
        public OperationResult GetOperationResults(IEnumerable<Operand> operands)
        {
            var errors = validateOperands(operands);
            if (errors.Any())
            {
                return new OperationResult { Errors = errors };
            }

            Operand? currentResult = null;
            foreach (var operand in operands)
            {
                try
                {
                    currentResult = currentResult is null ? operand 
                        : new Operand
                        {
                            Operator = operand.Operator,
                            Parameter = _operators[currentResult.Operator].Operate(currentResult, operand)
                        };
                }
                catch (Exception e)
                {
                    currentResult= null;
                    errors.Add(e.Message);
                    break;
                }
            }

            return new OperationResult { 
                Result = currentResult?.Parameter,
                Errors = errors.Any() ? errors : null
            };
        }
        private ICollection<string> validateOperands(IEnumerable<Operand> operands)
        {
            var errors = new List<string>();
            var operators = operands.Select(o => o.Operator).Distinct();
            if (_operators.Keys.Append(Equals).Intersect(operators).Count() != operators.Count())
            {
                errors.Add(InvalidOperatorError);
            }
            if (operands.Where(o=> o.Operator==Equals).Count()>1)
            {
                errors.Add(MoreEqualsError);
            }
            if (operands.LastOrDefault()?.Operator!=Equals)
            {
                errors.Add(LastEqualError);
            }
            return errors;
        }
    }
}
