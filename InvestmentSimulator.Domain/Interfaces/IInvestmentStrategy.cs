using InvestmentSimulator.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentSimulator.Domain.Interfaces;

public interface IInvestmentStrategy
{
    Task<decimal> SimulateInvestment(decimal initialAmount, decimal monthlyAmount, int months);
    InvestmentType Type {get;}
}
