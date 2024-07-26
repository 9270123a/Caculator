using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    internal class OperationState : IDisplayState
    {
        public void AppendDigit(Display context, string digit)
        {
            context.SetPrenumber(context.currentInput.ToString());
            context.ClearDisplay();
            context.currentInput.Clear();
            context.currentInput.Append(context.CurrentDisplay+digit);
            context.SetState(new secondoperator());
        }

        public void SetOperation(Display context, string operation)
        {


        }

        public void Clear(Display context)
        {

        }

        public void SetResult(Display context, double result)
        {

        }
    }
}
