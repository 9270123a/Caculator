using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    internal class preoperator:IDisplayState
    {

        public void AppendDigit(Display context, string digit)
        {
            context.UpdateDisplay(digit);

        }

        public void SetOperation(Display context, string operation)
        {
            context.currentOperation = operation;
            context.SetState(new OperationState());
        }

        public void Clear(Display context)
        {
           context.Reset();
        }

        public void SetResult(Display context, double result)
        {

        }
    }
}
