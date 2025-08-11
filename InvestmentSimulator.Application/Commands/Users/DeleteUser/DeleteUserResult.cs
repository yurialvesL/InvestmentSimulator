using InvestmentSimulator.Application.Commands.Users.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentSimulator.Application.Commands.Users.DeleteUser;

public class DeleteUserResult
{
    public bool Deleted { get; set; }
}
