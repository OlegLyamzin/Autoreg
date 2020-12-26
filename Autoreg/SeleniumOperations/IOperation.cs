using Autoreg.SeleniumOperations.OperationParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreg.SeleniumOperations
{
    public interface IOperation
    {
        void Action(IOperationParameters parameters);
    }
}
