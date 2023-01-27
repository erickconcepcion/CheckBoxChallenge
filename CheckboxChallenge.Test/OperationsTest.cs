using CheckboxChallenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using CheckboxChallenge.Services;
using CheckboxChallenge.Services.Implementations;
using System;
using System.Linq;
using CheckboxChallenge.Domains;
using CheckboxChallenge.Domains.Implementations;

namespace CheckboxChallenge.Test;

[TestClass]
public class OperationsTest
{
    private IServiceProvider? serviceProvider;
    private IOperationDomain? operationDomain;
    [TestInitialize]
    public void Initialize()
    {
        serviceProvider = new ServiceCollection()
            .AddTransient<IOperatorService, AddOperatorService>()
            .AddTransient<IOperatorService, MinusOperatorService>()
            .AddTransient<IOperatorService, MultiplyOperatorService>()
            .AddTransient<IOperatorService, DivideOperatorService>()
            .AddTransient<IOperationDomain, OperationDomain>()
            .BuildServiceProvider();
        operationDomain = serviceProvider?.GetService<IOperationDomain>();
    }
    [TestMethod]
    public void Testadd()
    {
        var addService = serviceProvider?.GetServices<IOperatorService>().Where(s => s.GetType() == typeof(AddOperatorService)).FirstOrDefault();
        var should = 10;
        var operand1 = new Operand
        {
            Parameter = 5,
            Operator = "+"
        };
        var operand2 = new Operand
        {
            Parameter = 5,
            Operator = "="
        };
        var result = addService?.Operate(operand1, operand2);
        Assert.AreEqual(should, result);
    }
    [TestMethod]
    public void TestaCompleteOperations()
    {
        var should = 9;
        var operationCompletePipeline = new Operand[]
        {
            new Operand{
                Parameter = 3,
                Operator = "+"
            },
            new Operand{
                Parameter = 3,
                Operator = "*"
            },
            new Operand{
                Parameter = 3,
                Operator = "/"
            },
            new Operand{
                Parameter = 2,
                Operator = "="
            }
        };
        var result = operationDomain?.GetOperationResults(operationCompletePipeline);
        Assert.AreEqual(should, result?.Result);
    }

    [TestMethod]
    public void TestaEqualsErrors ()
    {
        var errors = 2;
        var operationCompletePipeline = new Operand[]
        {
            new Operand{
                Parameter = 5,
                Operator = "+"
            },
            new Operand{
                Parameter = 7,
                Operator = "="
            },
            new Operand{
                Parameter = 8,
                Operator = "="
            },
            new Operand{
                Parameter = 7,
                Operator = "+"
            }
        };
        var result = operationDomain?.GetOperationResults(operationCompletePipeline);
        Assert.AreEqual(errors, result?.Errors?.Count());
    }

    [TestMethod]
    public void TestaDivideZeroError()
    {
        var operationCompletePipeline = new Operand[]
        {
            new Operand{
                Parameter = 5,
                Operator = "/"
            },
            new Operand{
                Parameter = 0,
                Operator = "="
            }
        };
        var result = operationDomain?.GetOperationResults(operationCompletePipeline);
        Assert.IsTrue(result?.Errors?.Any());
    }
}