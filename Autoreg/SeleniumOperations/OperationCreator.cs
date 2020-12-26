using Autoreg.SeleniumOperations.OperationParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreg.SeleniumOperations
{
    public class OperationCreator
    {
        private Dictionary<IOperationParameters, IOperation> _operations;
        public IOperation this[IOperationParameters parameters]
        {
            get
            {
                return _operations[parameters];
            }
            private set
            {
            }
        }
    }
}
