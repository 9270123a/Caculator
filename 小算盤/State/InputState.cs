using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    internal class secondoperator:IDisplayState
    {
        public void AppendDigit(Display context, string digit)
        {

     
            context.currentInput.Append(digit);
        }

        public void SetOperation(Display context, string operation)
        {

            context.operationset = true;
            context.equalSet = true;
            context.SetState(new ResultState());

        }

        public void Clear(Display context)
        {
            context.Reset();



        }

        public void SetResult(Display context, double result)
        {
            context.currentInput.Clear();
            context.currentInput.Append(result.ToString());
            context.equalSet = false;
        }
    }
}
