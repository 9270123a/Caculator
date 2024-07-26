using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    internal class ResultState:IDisplayState
    {
        public void AppendDigit(Display context, string digit)
        {
            
            context.SetPrenumber(context.currentInput.ToString());
            context.currentInput.Clear();
            context.UpdateDisplay(digit); 
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
            context.operationset = false;
            context.equalSet = false;
            context.SetPrenumber(result.ToString());
            context.currentInput.Clear();
            context.currentInput .Append(result.ToString());

        }
    }
}
