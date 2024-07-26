using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    public interface IDisplayState
    {
        void AppendDigit(Display context,string digit);
        void SetOperation(Display context,string operation);
        void Clear(Display context);
        void SetResult(Display context,double result);

        
    }
}
