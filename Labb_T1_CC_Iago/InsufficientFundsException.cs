using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_T1_CC_Iago
{
    class InsufficientFundsException : Exception
    {
        InsufficientFundsException(string message) : base(message)
        {
            message = "Account had insufficient funds";
        }
    }
}
