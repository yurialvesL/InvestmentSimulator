﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentSimulator.CrossCutting.Common.Interfaces;

public interface IPasswordHasher
{
    string HashPassword(string password);  
    
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}
