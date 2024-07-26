using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    public interface IDisplay
    {
        string CurrentDisplay { get; }
     
        string PreNumber { get;}
        string CurrentNumber { get; }
        string CurrentOperation { get; }

        bool OperationSet { get; }
        bool EqualSet {  get; }
        IDisplayState CurrentState { get; }

        void AppendDigit(string digit);
        void SetOperation(string operation);
        void Clear();
        void SetResult(double result);
        void SetPrenumber(string number);


        void Reset();

    }
}
