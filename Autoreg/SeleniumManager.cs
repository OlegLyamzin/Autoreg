using Autoreg.SeleniumOperations;
using Autoreg.SeleniumOperations.OperationParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreg
{
    public class SeleniumManager
    {
        private OperationCreator _operations;

        public SeleniumManager(OperationCreator operations)
        {
            _operations = operations;
        }

        public void Action(IOperationParameters parameters)
        {
            _operations[parameters].Action(parameters);
        }
    }
}
